-- Isolated practice schema only.
CREATE TABLE EtudiantInscription(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(30) NOT NULL,prenom VARCHAR2(30) NOT NULL,email VARCHAR2(100) NOT NULL,CONSTRAINT uq_etudiant_inscription_email UNIQUE(email),CONSTRAINT ck_inscription_email_normal CHECK(email=LOWER(TRIM(email))));
INSERT INTO EtudiantInscription VALUES(10001,'Benali','Ahmed','ahmed@example.com');
INSERT INTO EtudiantInscription VALUES(10002,'Amari','Sara','sara@example.com');
INSERT INTO EtudiantInscription VALUES(10003,'Hamadi','Yacine','yacine@example.com');
INSERT INTO EtudiantInscription VALUES(10004,'Dali','Nadia','nadia@example.com');
INSERT INTO EtudiantInscription VALUES(10005,'Kaci','Lina','lina@example.com');
INSERT INTO EtudiantInscription VALUES(10006,'Ali','Sami','sami@example.com');
COMMIT;
SELECT * FROM EtudiantInscription ORDER BY matricule;
