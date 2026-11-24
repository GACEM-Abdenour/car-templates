-- Practice table: EtudiantNom. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE EtudiantNom(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(20),prenom VARCHAR2(20));
INSERT INTO EtudiantNom VALUES(1,'Benali','Ali');
INSERT INTO EtudiantNom VALUES(2,'BENALI','Sara');
INSERT INTO EtudiantNom VALUES(3,'Benali','Amine');
INSERT INTO EtudiantNom VALUES(4,'Amari','Nadia');
COMMIT;
-- Verification queries
SELECT * FROM EtudiantNom WHERE UPPER(nom)=UPPER('benali');
