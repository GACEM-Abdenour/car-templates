-- Optional separate practice schema/database; do not run in the primary schema.
CREATE TABLE Produit_Commande(idproduit NUMBER(5) PRIMARY KEY,designation VARCHAR2(60) NOT NULL,prix NUMBER(12,2) NOT NULL CHECK(prix>=0),stock NUMBER(8) NOT NULL CHECK(stock>=0));
INSERT INTO Produit_Commande VALUES(1,'Produit secondaire',100,25);
COMMIT;
SELECT idproduit,designation,stock FROM Produit_Commande;
