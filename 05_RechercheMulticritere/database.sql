-- Practice table: EtudiantMulticritere. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE EtudiantMulticritere(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(30) NOT NULL,prenom VARCHAR2(30) NOT NULL,groupe VARCHAR2(10) NOT NULL);
INSERT INTO EtudiantMulticritere VALUES(1,'Benali','Ali','G1');
INSERT INTO EtudiantMulticritere VALUES(2,'Benali','Sara','G2');
INSERT INTO EtudiantMulticritere VALUES(3,'Amari','Ali','G3');
COMMIT;
-- Verification queries
SELECT * FROM EtudiantMulticritere WHERE groupe='G1';
