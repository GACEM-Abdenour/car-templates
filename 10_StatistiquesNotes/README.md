# Scenario 10 — Statistiques des notes

## Difficulty
Easy

## Main trick
AVG/MIN/MAX with nullable scalar values and a one-row statistics DataSet.

## Exam clues
- Moyenne
- Meilleure note
- Statistiques
- Admis

## Énoncé
Calculer les statistiques des résultats des étudiants.

## Database
`database.sql` creates the isolated practice table `EtudiantStatistique`.

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
The commented `TRICK 10` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
For an isolated dataset containing only 8, 10, 12 and 18: average 12, min 8, max 18, 3 admitted and 1 ajourné. The supplied seed has eight rows, so its aggregate values differ. For an empty table, average/min/max show N/A and counts are zero.

CRUD uses matricule, nom, prénom and note. `GetStatistiques` returns all five displayed indicators in one row; the individual buttons call separate nullable scalar methods. Decimal input uses the Windows decimal separator.
