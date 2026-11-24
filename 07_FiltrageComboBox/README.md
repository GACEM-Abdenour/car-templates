# Scenario 07 — Filtrage par ComboBox

## Difficulty
Easy

## Main trick
Load DISTINCT values remotely, bind ComboBox and filter by SelectedValue.

## Exam clues
- Liste déroulante
- Département
- Filtrer selon sélection

## Énoncé
Afficher les employés du département sélectionné.

## Database
`database.sql` creates the isolated practice table `Employe`.

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
The commented `TRICK 07` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
Select Informatique, then Tous; add another department and refresh the list.

`ChargerDepartements` fetches distinct values, adds a separate Tous option and suppresses selection events during binding. Add, modify and delete refresh the list; the manual filter and selection-change handler both call `AppliquerFiltre`. Use the matricule field for search and CRUD.
