-- Isolated practice schema only.
CREATE TABLE EtudiantSelection(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(20) NOT NULL,prenom VARCHAR2(20) NOT NULL);
INSERT INTO EtudiantSelection VALUES(1,'Benali','Ali');
INSERT INTO EtudiantSelection VALUES(2,'Amari','Sara');
INSERT INTO EtudiantSelection VALUES(3,'Dali','Nadia');
INSERT INTO EtudiantSelection VALUES(4,'Hamdi','Lina');
INSERT INTO EtudiantSelection VALUES(5,'Kaci','Sami');
INSERT INTO EtudiantSelection VALUES(6,'Farah','Karim');
COMMIT;
SELECT * FROM EtudiantSelection ORDER BY matricule;
