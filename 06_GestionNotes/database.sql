-- Practice table: EtudiantNote. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE EtudiantNote(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(30) NOT NULL,prenom VARCHAR2(30) NOT NULL,note NUMBER(4,2) NOT NULL CHECK(note BETWEEN 0 AND 20));
INSERT INTO EtudiantNote VALUES(1,'A','A',0);
INSERT INTO EtudiantNote VALUES(2,'B','B',7.50);
INSERT INTO EtudiantNote VALUES(3,'C','C',9.99);
INSERT INTO EtudiantNote VALUES(4,'D','D',10);
INSERT INTO EtudiantNote VALUES(5,'E','E',12.50);
INSERT INTO EtudiantNote VALUES(6,'F','F',16);
INSERT INTO EtudiantNote VALUES(7,'G','G',20);
COMMIT;
-- Verification queries
SELECT * FROM EtudiantNote WHERE note BETWEEN 10 AND 15;
