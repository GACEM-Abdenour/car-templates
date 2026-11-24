-- Practice table: Cours. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE Cours(idcours NUMBER(5) PRIMARY KEY,intitule VARCHAR2(80) NOT NULL,enseignant VARCHAR2(60) NOT NULL,volumehoraire NUMBER(5,2) NOT NULL CHECK(volumehoraire>=0));
INSERT INTO Cours VALUES(1,'CAR','A',30);
INSERT INTO Cours VALUES(2,'BDD','A',45);
INSERT INTO Cours VALUES(3,'Java','B',20);
INSERT INTO Cours VALUES(4,'Reseau','C',35);
INSERT INTO Cours VALUES(5,'SE','B',25);
INSERT INTO Cours VALUES(6,'IA','A',50);
INSERT INTO Cours VALUES(7,'Web','C',15);
INSERT INTO Cours VALUES(8,'Algo','B',40);
COMMIT;
-- Verification queries
SELECT COUNT(*) FROM Cours WHERE volumehoraire>30;
