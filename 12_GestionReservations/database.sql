-- Isolated practice schema only; no existing table is dropped.
CREATE TABLE Reservation (idreservation NUMBER(5) PRIMARY KEY, responsable VARCHAR2(60) NOT NULL, salle VARCHAR2(30) NOT NULL, datereservation DATE NOT NULL);
INSERT INTO Reservation VALUES(1,'A','Salle 1',TRUNC(SYSDATE)+8/24);
INSERT INTO Reservation VALUES(2,'B','Salle 1',TRUNC(SYSDATE)+14.5/24);
INSERT INTO Reservation VALUES(3,'C','Salle 2',TRUNC(SYSDATE)+23/24+59/1440);
INSERT INTO Reservation VALUES(4,'D','Salle 2',TRUNC(SYSDATE)+1);
-- Tomorrow at 10:00 according to the database server's calendar.
INSERT INTO Reservation VALUES(5,'E','Salle 3',TRUNC(SYSDATE)+1+10/24);
INSERT INTO Reservation VALUES(6,'F','Salle 1',TRUNC(SYSDATE)-1+10/24);
INSERT INTO Reservation VALUES(7,'G','Salle 2',TRUNC(SYSDATE)-2+9/24);
INSERT INTO Reservation VALUES(8,'H','Salle 3',TO_DATE('2026-11-24 08:30','YYYY-MM-DD HH24:MI'));
COMMIT;
SELECT * FROM Reservation WHERE datereservation>=TRUNC(SYSDATE) AND datereservation<TRUNC(SYSDATE)+1 ORDER BY datereservation;
