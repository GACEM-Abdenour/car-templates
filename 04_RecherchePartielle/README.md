# Scenario 04 — Recherche partielle

## Difficulty
Easy

## Main trick
Oracle LIKE patterns: prefix, substring and suffix.

## Exam clues
- Commence par
- Contient
- Se termine par

## Énoncé
Rechercher des étudiants à partir d’une partie du nom.

## Database
`database.sql` creates the isolated practice table `EtudiantLike`.

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
The commented `TRICK 04` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
Ben prefix, ali contains and ari suffix each produce their expected rows.

CRUD uses matricule, nom and prénom. `Echappe` protects literal backslash, `%` and `_` using Oracle `ESCAPE`; the methods add only the intended prefix/suffix wildcards. Verify literal wildcard searches using isolated sample names containing these characters.
