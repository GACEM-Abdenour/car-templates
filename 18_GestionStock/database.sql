-- Isolated practice schema only. DEFAULT supplies initial values; NOT NULL and CHECK protect stock.
CREATE TABLE ProduitStock(idproduit NUMBER(5) PRIMARY KEY,designation VARCHAR2(60) NOT NULL,quantite NUMBER(8) DEFAULT 0 NOT NULL CHECK(quantite>=0),seuilalerte NUMBER(8) DEFAULT 5 NOT NULL CHECK(seuilalerte>=0));
INSERT INTO ProduitStock VALUES(10001,'Produit A',10,5);
INSERT INTO ProduitStock VALUES(10002,'Produit B',0,5);
INSERT INTO ProduitStock VALUES(10003,'Produit C',3,5);
INSERT INTO ProduitStock VALUES(10004,'Produit D',5,5);
INSERT INTO ProduitStock VALUES(10005,'Produit E',25,10);
INSERT INTO ProduitStock VALUES(10006,'Produit F',2,3);
COMMIT;
SELECT * FROM ProduitStock WHERE quantite<=seuilalerte;
