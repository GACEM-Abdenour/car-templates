# 14 — Suppression conditionnelle

## Difficulty and main trick
Easy. DELETE with a server-enforced stock condition, confirmation and affected-row counts.

## Exam clues and énoncé
Supprimer uniquement si, stock nul, produits épuisés, par catégorie, confirmer : gérer les produits et interdire la suppression quand le stock est positif.

## Database
`ProduitSuppression` has primary key `idproduit`, designation, category and nonnegative quantity. Use `database.sql` only in an isolated schema.

## Files and adaptation from aaa-tp4
Declare the conditional methods in `Interfaces/IRemoteOperation.cs`; implement `GetProduitsEpuises`, `SupprimerProduitSiStockNul`, `SupprimerProduitsEpuises`, `SupprimerProduitsEpuisesParCategorie` in `Server/RemoteOperation.cs`; add confirmation handlers in `ClientForm/Form1.cs` and controls in `Form1.Designer.cs`. Change the schema script; Program and Remoting setup remain unchanged.

## Reusable pattern and common mistakes
`DELETE FROM ProduitSuppression WHERE idproduit=:id AND quantite=0` applies both the key and rule atomically. A preliminary SELECT alone is unsafe when stock can change concurrently. `ExecuteNonQuery` returns affected rows; zero means missing OR nonzero stock, not necessarily a missing product. Bulk deletion may affect multiple rows. Yes/No confirmation does not replace the server rule.

## Verification
In an isolated schema, cancel a deletion; try ID 10002 with stock 10 (zero rows); delete 10001 (one row); delete exhausted Cosmetique products and verify 10004 remains; delete remaining exhausted items and verify every positive-stock item remains. Reject a blank category.

## Exam reuse

For another conditional deletion, keep the business condition in the DELETE itself and interpret zero affected rows carefully.
