-- Run only in an isolated practice schema; no table is dropped.
CREATE TABLE EtudiantClassement (matricule NUMBER(5) PRIMARY KEY, nom VARCHAR2(30) NOT NULL, prenom VARCHAR2(30) NOT NULL, note NUMBER(4,2) NOT NULL CHECK(note BETWEEN 0 AND 20));
INSERT INTO EtudiantClassement VALUES(1,'Ali','Amine',18);
INSERT INTO EtudiantClassement VALUES(2,'Benali','Sara',16);
INSERT INTO EtudiantClassement VALUES(3,'Cherif','Karim',16);
INSERT INTO EtudiantClassement VALUES(4,'Dali','Nadia',12);
INSERT INTO EtudiantClassement VALUES(5,'Essaid','Lina',9);
INSERT INTO EtudiantClassement VALUES(6,'Farah','Sami',8);
INSERT INTO EtudiantClassement VALUES(7,'Ghali','Anis',7);
INSERT INTO EtudiantClassement VALUES(8,'Hamdi','Rania',6);
INSERT INTO EtudiantClassement VALUES(9,'Idir','Kamel',5);
INSERT INTO EtudiantClassement VALUES(10,'Jamal','Yasmine',4);
COMMIT;
SELECT matricule,note,RANK() OVER(ORDER BY note DESC) AS rang FROM EtudiantClassement ORDER BY rang,matricule;
