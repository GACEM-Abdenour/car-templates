-- Use an isolated practice schema.
CREATE TABLE EnseignantSelection(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(30) NOT NULL,prenom VARCHAR2(30) NOT NULL,specialite VARCHAR2(60));
INSERT INTO EnseignantSelection VALUES(10001,'Benali','Ahmed','Reseaux');
INSERT INTO EnseignantSelection VALUES(10002,'Benali','Ahmed','Bases de donnees');
INSERT INTO EnseignantSelection VALUES(10003,'Amari','Sara','Intelligence artificielle');
INSERT INTO EnseignantSelection VALUES(10004,'Hamadi','Yacine','Systemes distribues');
INSERT INTO EnseignantSelection VALUES(10005,'Kaci','Lina',NULL);
INSERT INTO EnseignantSelection VALUES(10006,'Ali','Sami','Securite');
COMMIT;
SELECT * FROM EnseignantSelection ORDER BY nom,prenom,matricule;
