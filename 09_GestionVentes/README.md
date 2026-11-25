# Scenario 09 — Gestion des ventes

## Difficulty
Easy

## Main trick
Calculated SQL fields, SUM, NVL and decimal monetary values.

## Exam clues
- Chiffre d’affaires
- Montant total
- Somme

## Énoncé
Calculer les montants et le chiffre d’affaires des ventes.

## Database
`database.sql` creates the isolated practice table `Vente`.

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
The commented `TRICK 09` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
Quantity 3 × 125.50 produces 376.50; unknown product produces 0.

Use the sale ID for search and deletion; addition and modification also require product, positive quantity and nonnegative price. Decimal input uses the Windows decimal separator. `GetVentes` and `RechercherVente` calculate `montant` in SQL.

## Exam reuse

Use `CalculerChiffreAffaires` in `Server/RemoteOperation.cs` for revenue; keep money as decimal and handle an empty SUM before adapting the amount expression.
