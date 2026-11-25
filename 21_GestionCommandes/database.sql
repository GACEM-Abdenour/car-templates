-- Isolated schema only. Seed stock is current stock AFTER the historical orders below.
CREATE TABLE Client_Commande(idclient NUMBER(5) PRIMARY KEY,nom VARCHAR2(60) NOT NULL,telephone VARCHAR2(20));
CREATE TABLE Produit_Commande(idproduit NUMBER(5) PRIMARY KEY,designation VARCHAR2(60) NOT NULL,prix NUMBER(12,2) NOT NULL CHECK(prix>=0),stock NUMBER(8) NOT NULL CHECK(stock>=0));
-- One client has many orders.
CREATE TABLE Commande(idcommande NUMBER(8) PRIMARY KEY,idclient NUMBER(5) NOT NULL,datecommande DATE DEFAULT SYSDATE NOT NULL,CONSTRAINT fk_cmd_client FOREIGN KEY(idclient) REFERENCES Client_Commande(idclient));
-- Many-to-many association: both keys are required to identify a line.
CREATE TABLE Ligne_Commande(idcommande NUMBER(8) NOT NULL,idproduit NUMBER(5) NOT NULL,quantite NUMBER(8) NOT NULL CHECK(quantite>0),prixunitaire NUMBER(12,2) NOT NULL CHECK(prixunitaire>=0),CONSTRAINT pk_ligne_commande PRIMARY KEY(idcommande,idproduit),CONSTRAINT fk_ligne_cmd FOREIGN KEY(idcommande) REFERENCES Commande(idcommande),CONSTRAINT fk_ligne_produit FOREIGN KEY(idproduit) REFERENCES Produit_Commande(idproduit));
INSERT INTO Client_Commande VALUES(1,'Ali','0550100001');
INSERT INTO Client_Commande VALUES(2,'Benali','0550100002');
INSERT INTO Client_Commande VALUES(3,'Amari',NULL);
INSERT INTO Client_Commande VALUES(4,'Dali',NULL);
INSERT INTO Client_Commande VALUES(5,'Farah',NULL);
INSERT INTO Produit_Commande VALUES(1,'Stylo',125.50,10);
INSERT INTO Produit_Commande VALUES(2,'Cahier',200,20);
INSERT INTO Produit_Commande VALUES(3,'Livre',900,0);
INSERT INTO Produit_Commande VALUES(4,'Classeur',450,5);
INSERT INTO Produit_Commande VALUES(5,'Gomme',50,30);
INSERT INTO Produit_Commande VALUES(6,'Règle',80,9);
INSERT INTO Commande VALUES(1,1,TRUNC(SYSDATE)-2);
INSERT INTO Commande VALUES(2,1,TRUNC(SYSDATE)-1);
INSERT INTO Commande VALUES(3,2,TRUNC(SYSDATE));
INSERT INTO Ligne_Commande VALUES(1,1,3,125.50);
INSERT INTO Ligne_Commande VALUES(1,2,2,200);
INSERT INTO Ligne_Commande VALUES(2,3,1,900);
INSERT INTO Ligne_Commande VALUES(3,4,1,450);
COMMIT;
SELECT c.idcommande,cl.nom FROM Commande c INNER JOIN Client_Commande cl ON cl.idclient=c.idclient;
SELECT * FROM Ligne_Commande WHERE idcommande=1 AND idproduit=1;
