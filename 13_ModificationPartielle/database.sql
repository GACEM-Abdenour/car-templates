-- Isolated practice schema only; no table is dropped.
CREATE TABLE EmployeModification(matricule NUMBER(5) PRIMARY KEY,nom VARCHAR2(30) NOT NULL,prenom VARCHAR2(30) NOT NULL,departement VARCHAR2(40) NOT NULL,telephone VARCHAR2(20),salaire NUMBER(12,2) NOT NULL CHECK(salaire>=0));
INSERT INTO EmployeModification VALUES(10001,'Benali','Ahmed','Informatique','0550123456',50000);
INSERT INTO EmployeModification VALUES(10002,'Ali','Sara','Commercial',NULL,45000);
INSERT INTO EmployeModification VALUES(10003,'Dali','Nadia','Comptabilite','0550111111',60000);
INSERT INTO EmployeModification VALUES(10004,'Farah','Sami','Commercial','+213550222222',55000);
INSERT INTO EmployeModification VALUES(10005,'Hamdi','Lina','Informatique','0550333333',70000);
INSERT INTO EmployeModification VALUES(10006,'Kaci','Rania','Administration','0550444444',48000);
COMMIT;
SELECT * FROM EmployeModification ORDER BY matricule;
