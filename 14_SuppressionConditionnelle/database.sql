-- Use an isolated practice schema; this script does not drop tables.
CREATE TABLE ProduitSuppression(idproduit NUMBER(5) PRIMARY KEY,designation VARCHAR2(60) NOT NULL,categorie VARCHAR2(40) NOT NULL,quantite NUMBER(6) NOT NULL CHECK(quantite>=0));
INSERT INTO ProduitSuppression VALUES(10001,'Produit A','Alimentaire',0);
INSERT INTO ProduitSuppression VALUES(10002,'Produit B','Alimentaire',10);
INSERT INTO ProduitSuppression VALUES(10003,'Produit C','Cosmetique',0);
INSERT INTO ProduitSuppression VALUES(10004,'Produit D','Cosmetique',5);
INSERT INTO ProduitSuppression VALUES(10005,'Produit E','Detergent',0);
INSERT INTO ProduitSuppression VALUES(10006,'Produit F','Detergent',20);
INSERT INTO ProduitSuppression VALUES(10007,'Produit G','Vestimentaire',0);
INSERT INTO ProduitSuppression VALUES(10008,'Produit H','Vestimentaire',3);
COMMIT;
SELECT * FROM ProduitSuppression WHERE quantite=0 ORDER BY categorie,designation;
