# 15 — Gestion des doublons

## Difficulty and main trick
Easy. COUNT, EXISTS, bool, primary key, UNIQUE and ORA-00001.

## Exam clues and énoncé
Existe déjà, éviter les doublons, adresse unique : gérer les inscriptions avec matricule et email uniques.

## Database
`EtudiantInscription` has a primary key and unique normalized email. Run `database.sql` only in an isolated schema. This exercise uses trimmed lowercase ASCII emails; the CHECK enforces lowercase and trimmed storage.

## Files and adaptation from aaa-tp4
Add bool and CRUD declarations in `Interfaces/IRemoteOperation.cs`; implement `EtudiantExiste`, `EmailExiste`, `EmailUtiliseParAutreEtudiant`, CRUD and error conversion in `Server/RemoteOperation.cs`; add handlers in `ClientForm/Form1.cs` and controls in `Form1.Designer.cs`. Change table and fields in `database.sql`. Program and Remoting configuration remain unchanged.

## Reusable pattern and common mistakes
COUNT and EXISTS return one value through ExecuteScalar, converted to bool. Exclude the current matricule when checking an update. Two clients can both pass a preliminary check: Oracle's unique constraint is authoritative, and ORA-00001 becomes a standard exception. Do not send OracleException to the client.

## Verification
Insert a student, reject duplicate matricule or email including uppercase input, modify while retaining own email, reject another student's email, and verify unknown email yields false and an empty result. Test concurrent inserts only in an isolated schema.

## Exam reuse

For another uniqueness rule, adapt the normalized value and database constraint as well as the preliminary existence checks.
