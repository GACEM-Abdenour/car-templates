# Scenario 08 — Comptage conditionnel

## Difficulty
Easy

## Main trick
COUNT and ExecuteScalar return an int from Oracle.

## Exam clues
- Combien
- Nombre total
- Dépassant 30 heures

## Énoncé
Compter les cours selon différents critères.

## Database
`database.sql` creates the isolated practice table `Cours`.

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
The commented `TRICK 08` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
30 hours is excluded by >30; unknown teacher gives zero.

CRUD and search use the ID, title, teacher and volume fields. The threshold and teacher count buttons use the corresponding fields; the scalar result appears in `lblResultat`. The controls and event associations are in `ClientForm/Form1.Designer.cs`.

## Exam reuse

Use `CompterCours` in `Server/RemoteOperation.cs` when one count is needed; read the scalar result and adapt the WHERE condition to the requested population.
