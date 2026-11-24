-- Practice table: Vente. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE Vente(idvente NUMBER(5) PRIMARY KEY,produit VARCHAR2(60) NOT NULL,quantite NUMBER(6) NOT NULL CHECK(quantite>0),prixunitaire NUMBER(12,2) NOT NULL CHECK(prixunitaire>=0));
INSERT INTO Vente VALUES(1,'Stylo',3,125.50);
INSERT INTO Vente VALUES(2,'Stylo',2,125.50);
INSERT INTO Vente VALUES(3,'Cahier',5,80.25);
COMMIT;
-- Verification queries
SELECT quantite*prixunitaire AS montant FROM Vente;
