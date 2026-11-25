# Scenario 01 — Gestion des produits

## Difficulty
Easy

## Main trick
CRUD with `long`, `int` and `decimal`.

## Exam clues
- Code-barres
- Prix unitaire
- Quantité

## Énoncé
Gérer les produits d’une supérette.

## Database
`database.sql` creates the isolated practice table `Produit`.

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
The commented `TRICK 01` methods are the quick source reference. All user values are Oracle parameters with `BindByName = true`.

## How to adapt to another table
Replace table/column names, parameter types and relevant controls; retain the three projects, Remoting URI and Server-only Oracle access.

## Verification
Add code 1234567890, quantity 20, price 125.50; find it, modify it, then delete it.

## Exam reuse

Use `AjouterProduit` in `Server/RemoteOperation.cs` for typed product CRUD; reject negative values and adapt the barcode and price types to the new table.
