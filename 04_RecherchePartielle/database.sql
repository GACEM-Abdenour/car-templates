-- Practice table: EtudiantLike. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE EtudiantLike(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(20),prenom VARCHAR2(20));
INSERT INTO EtudiantLike VALUES(1,'Benali','A');
INSERT INTO EtudiantLike VALUES(2,'Benamar','B');
INSERT INTO EtudiantLike VALUES(3,'Bensalem','C');
INSERT INTO EtudiantLike VALUES(4,'Amari','D');
INSERT INTO EtudiantLike VALUES(5,'Hamadi','E');
INSERT INTO EtudiantLike VALUES(6,'Belkacem','F');
COMMIT;
-- Verification queries
SELECT * FROM EtudiantLike WHERE UPPER(nom) LIKE UPPER('Ben%');
