# Scenario 03 — Recherche par nom

## Difficulty
Easy

## Main trick
Case-insensitive exact non-primary-key search returning many rows.

## Exam clues
- Rechercher par nom
- Sans distinction majuscules/minuscules

## Énoncé
Afficher tous les étudiants qui portent le même nom ou prénom.

## Database
`database.sql` creates the isolated practice table `EtudiantNom`.

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
The commented `TRICK 03` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
Search Benali and benali; both return every matching row. An unknown name gives an empty grid.
