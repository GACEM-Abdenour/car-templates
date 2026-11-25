# 18 — Gestion du stock

## Difficulty and trick
Easy. Atomic stock movements, conditional UPDATE, thresholds and nullable scalar.

## Énoncé et indices
Entrée, sortie, stock insuffisant, seuil d'alerte : gérer les produits sans autoriser un stock négatif.

## Database and files
`ProduitStock` has a primary key, designation, quantity and alert threshold; DEFAULT, NOT NULL and CHECK protect the values. Use database.sql in an isolated schema. Inspect `Interfaces/IRemoteOperation.cs`, `Server/RemoteOperation.cs` (`AjouterEntreeStock`, `EnregistrerSortieStock`, `GetQuantiteStock`) and the Form1 client and Designer. Adapt table, columns and controls from aaa-tp4; Program and Remoting remain unchanged.

## Pattern and pitfalls
`SET quantite=quantite-:quantite WHERE idproduit=:id AND quantite>=:quantite` tests and updates atomically. Never replace stock based on a stale client read. Zero affected rows means missing product or insufficient stock. Nullable stock distinguishes absent product from stock zero. Deletion requires stock zero.

## Verification
Start with 10, add 5, remove 7, reject 9, remove 8; expected stock is 0. Test threshold equality, invalid movements and missing identifier. Test concurrency only with isolated practice data.

## Exam reuse

For another inventory table, adapt the key and quantity columns while keeping the availability check inside the UPDATE.
