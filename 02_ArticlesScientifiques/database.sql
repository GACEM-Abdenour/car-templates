-- Practice table: ArticleScientifique. Rename it only if the professor's schema uses another name.
-- Do not run DROP TABLE automatically: this script is safe for an isolated practice schema.
CREATE TABLE ArticleScientifique(idarticle NUMBER(5) PRIMARY KEY,titre VARCHAR2(200) NOT NULL,auteur VARCHAR2(100) NOT NULL,revue VARCHAR2(100),anneepublication NUMBER(4) NOT NULL,doi VARCHAR2(100) NOT NULL UNIQUE);
INSERT INTO ArticleScientifique VALUES(1,'Systèmes distribués','O''Connor, Anne','RSD',2024,'10.1/a');
INSERT INTO ArticleScientifique VALUES(2,'Oracle pratique','Benali, Ali','Data',2023,'10.1/b');
COMMIT;
-- Verification queries
SELECT * FROM ArticleScientifique WHERE doi='10.1/a';
