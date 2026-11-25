# Scenario 06 — Gestion des notes

## Difficulty
Easy

## Main trick
Decimal comparisons, BETWEEN and client/server validation.

## Exam clues
- Admis
- Ajournés
- Compris entre

## Énoncé
Gérer les notes et filtrer les admis, ajournés et intervalles.

## Database
`database.sql` creates the isolated practice table `EtudiantNote`.

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
The commented `TRICK 06` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
10 is admitted, 9.99 is not; -1 and 21 are rejected.

## Exam reuse

Use `RechercherNotesEntre` in `Server/RemoteOperation.cs` for bounded grade searches; validate both endpoints and adapt the allowed range to the exercise.
