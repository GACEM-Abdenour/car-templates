-- Practice table: Employe. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE Employe(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(30) NOT NULL,prenom VARCHAR2(30) NOT NULL,departement VARCHAR2(40) NOT NULL,salaire NUMBER(12,2));
INSERT INTO Employe VALUES(1,'A','A','Informatique',90000);
INSERT INTO Employe VALUES(2,'B','B','Comptabilite',70000);
INSERT INTO Employe VALUES(3,'C','C','Ressources humaines',65000);
INSERT INTO Employe VALUES(4,'D','D','Commercial',75000);
COMMIT;
-- Verification queries
SELECT DISTINCT departement FROM Employe ORDER BY departement;
