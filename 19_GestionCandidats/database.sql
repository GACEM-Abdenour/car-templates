-- Isolated practice schema only.
CREATE TABLE Candidat(idcandidat NUMBER(5) PRIMARY KEY,nom VARCHAR2(30) NOT NULL,prenom VARCHAR2(30) NOT NULL,noteecrit NUMBER(4,2) NOT NULL CHECK(noteecrit BETWEEN 0 AND 20),noteoral NUMBER(4,2) NOT NULL CHECK(noteoral BETWEEN 0 AND 20));
INSERT INTO Candidat VALUES(1,'A','A',18,16);
INSERT INTO Candidat VALUES(2,'B','B',10,10);
INSERT INTO Candidat VALUES(3,'C','C',8,8);
INSERT INTO Candidat VALUES(4,'D','D',20,4);
INSERT INTO Candidat VALUES(5,'E','E',16,16);
INSERT INTO Candidat VALUES(6,'F','F',5,5);
INSERT INTO Candidat VALUES(7,'G','G',4,20);
INSERT INTO Candidat VALUES(8,'H','H',20,20);
COMMIT;
SELECT idcandidat,ROUND(noteecrit*0.6+noteoral*0.4,2) AS note_finale FROM Candidat;
