-- Isolated practice schema only; no existing tables are dropped.
CREATE TABLE VenteCategorie(idvente NUMBER(5) PRIMARY KEY,produit VARCHAR2(60) NOT NULL,categorie VARCHAR2(40) NOT NULL,quantite NUMBER(6) NOT NULL CHECK(quantite>0),prixunitaire NUMBER(12,2) NOT NULL CHECK(prixunitaire>=0));
INSERT INTO VenteCategorie VALUES(1,'Pain','Alimentaire',2,100);
INSERT INTO VenteCategorie VALUES(2,'Pain','Alimentaire',3,200);
INSERT INTO VenteCategorie VALUES(3,'Savon','Cosmetique',1,500);
INSERT INTO VenteCategorie VALUES(4,'Savon','Cosmetique',2,300);
INSERT INTO VenteCategorie VALUES(5,'Lessive','Detergent',1,100);
INSERT INTO VenteCategorie VALUES(6,'Riz','Alimentaire',4,150);
INSERT INTO VenteCategorie VALUES(7,'Creme','Cosmetique',2,250);
INSERT INTO VenteCategorie VALUES(8,'Chemise','Vestimentaire',1,800);
INSERT INTO VenteCategorie VALUES(9,'Pantalon','Vestimentaire',2,900);
INSERT INTO VenteCategorie VALUES(10,'Lessive','Detergent',3,120);
COMMIT;
SELECT categorie,COUNT(*),SUM(quantite*prixunitaire) FROM VenteCategorie GROUP BY categorie ORDER BY categorie;
