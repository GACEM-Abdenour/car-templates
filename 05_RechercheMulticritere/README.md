# Scenario 05 — Recherche multicritère

## Difficulty
Easy

## Main trick
Optional dynamic AND conditions and keyword OR.

## Exam clues
- Plusieurs critères
- Et / Ou
- Critères facultatifs

## Énoncé
Rechercher selon nom, prénom et groupe.

## Database
`database.sql` creates the isolated practice table `EtudiantMulticritere`.

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
The commented `TRICK 05` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
Test only group, name+group, all filters, no filters and an OR keyword.

The matricule button searches by key; the ET button uses optional filters, and the OU button searches the keyword in either name. Reset clears all filters and displays every student.

## Exam reuse

Use `RechercherEtudiants` in `Server/RemoteOperation.cs` for optional AND filters; bind only supplied criteria and allow an unfiltered result.
