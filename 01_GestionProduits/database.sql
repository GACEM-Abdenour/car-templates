-- Practice table: Produit. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE Produit (codebarre NUMBER(10) PRIMARY KEY, designation VARCHAR2(50) NOT NULL, quantite NUMBER(6) NOT NULL CHECK(quantite>=0), prix NUMBER(12,2) NOT NULL CHECK(prix>=0));
INSERT INTO Produit VALUES(1000000001,'Lait',12,95.50);
INSERT INTO Produit VALUES(1000000002,'Pain',30,15.00);
INSERT INTO Produit VALUES(1000000003,'Cafe',8,450.25);
INSERT INTO Produit VALUES(1000000004,'Riz',20,180.00);
INSERT INTO Produit VALUES(1000000005,'Huile',14,620.00);
INSERT INTO Produit VALUES(1000000006,'The',18,210.75);
COMMIT;
-- Verification queries
SELECT * FROM Produit ORDER BY codebarre;
