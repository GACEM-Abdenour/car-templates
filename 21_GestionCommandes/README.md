# 21 — Gestion des commandes

## Advanced: relations, JOIN and transactions
Gérer clients, produits et commandes avec lignes multiples, stock et prix historique. `Client_Commande` → `Commande` is one-to-many; `Ligne_Commande` links commands and products many-to-many with composite key `(idcommande,idproduit)`.

## Files and adaptation
Use `database.sql` in an isolated schema. Inspect `Interfaces/IRemoteOperation.cs`, `Server/RemoteOperation.cs` (`AjouterCommande`, `GetLignesCommande`, `GetChiffreAffairesParClient`, `GetProduitsDeuxBases`) and `ClientForm/Form1.cs`. Adapt table names, keys, SQL, UI and interface from aaa-tp4; Program and Remoting transport remain recognizable. Client and product CRUD, draft lines and master/detail grids are on separate tabs. To find a composite-key line, enter command ID on Nouvelle commande and product ID on Clients / produits, then choose Chercher ligne.

## Patterns and cautions
INNER JOIN retrieves related rows; LEFT JOIN plus IS NULL finds missing relationships. `COUNT(DISTINCT c.idcommande)` prevents a multiple-line order from being counted repeatedly. `AjouterCommande` validates the draft, inserts its header, atomically decrements stock and stores the current server-side price for each line, then commits; failures roll back. A line's stored price preserves historical amounts when the product price changes. Duplicate draft products are rejected. ORA-02291 means a missing parent; ORA-02292 means dependent records prevent deletion. ON DELETE CASCADE is an alternative only when explicitly required; it is not enabled here.

Two independent connections are optional: configure OraclePrincipale and OracleSecondaire in Server/App.config and use `database_secondaire.sql` in a separate practice schema or database. Two schemas are not necessarily two database instances. An administrator-configured database link could use `SELECT * FROM Produit_Commande@autre_base`; this example does not require one. Transactions across databases are outside this example.

## Verification
In an isolated schema create a multi-line order and check its total, historical prices and stock. Repeat with insufficient stock or a duplicate command ID and verify that no header, lines or stock changes persist. Check clients/products without orders, composite-key lookup and the master-detail display. Oracle, rollback and UI runtime tests remain pending.

## Exam reuse

For another master-detail exercise, adapt both foreign keys and historical line values while keeping all order writes in the same transaction.
