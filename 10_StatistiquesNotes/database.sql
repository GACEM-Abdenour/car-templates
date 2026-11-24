-- Practice table: EtudiantStatistique. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE EtudiantStatistique(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(30) NOT NULL,prenom VARCHAR2(30) NOT NULL,note NUMBER(4,2) NOT NULL CHECK(note BETWEEN 0 AND 20));
INSERT INTO EtudiantStatistique VALUES(1,'A','A',8);
INSERT INTO EtudiantStatistique VALUES(2,'B','B',10);
INSERT INTO EtudiantStatistique VALUES(3,'C','C',12);
INSERT INTO EtudiantStatistique VALUES(4,'D','D',18);
INSERT INTO EtudiantStatistique VALUES(5,'E','E',15);
INSERT INTO EtudiantStatistique VALUES(6,'F','F',9);
INSERT INTO EtudiantStatistique VALUES(7,'G','G',20);
INSERT INTO EtudiantStatistique VALUES(8,'H','H',7);
COMMIT;
-- Verification queries
SELECT ROUND(AVG(note),2),MIN(note),MAX(note) FROM EtudiantStatistique;
