# Scenario 02 — Gestion des articles scientifiques

## Difficulty
Easy

## Main trick
CRUD with many VARCHAR2 values and a unique DOI.

## Exam clues
- DOI unique
- Rechercher par DOI
- Article scientifique

## Énoncé
Gérer les articles publiés par des chercheurs.

## Database
`database.sql` creates the isolated practice table `ArticleScientifique`.

## Files to inspect
- `Interfaces/IRemoteOperation.cs`
- `Server/RemoteOperation.cs`
- `ClientForm/Form1.cs`

## What changes compared with TP4
1. Change the shared method signatures in `IRemoteOperation.cs`.
2. Put the table-specific parameterized SQL directly in `RemoteOperation.cs`.
3. Wire the listed WinForms buttons in `Form1.cs`; the value travels from a control to a remote method, then back as a `DataSet` or scalar.
4. Update the table and columns only when adapting to the examination statement.

## Reusable code
The commented `TRICK 02` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
Use a DOI search and verify that a duplicate DOI is rejected by the UNIQUE constraint.

## Exam reuse

Use `RechercherParDOI` in `Server/RemoteOperation.cs` for DOI lookup; bind text parameters to preserve apostrophes and retain a database uniqueness constraint.
