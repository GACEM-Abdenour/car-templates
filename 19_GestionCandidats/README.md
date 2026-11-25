# 19 — Gestion des candidats

## Difficulty and trick
Easy. Weighted result, CASE WHEN, calculated alias and decision counts.

## Énoncé et indices
Calculer une moyenne pondérée et classer les candidats : éliminé, admis, admis avec mention ou ajourné.

## Database and files
`Candidat` stores only original written and oral grades (0–20), not calculated results. Use database.sql in an isolated schema. Inspect `Interfaces/IRemoteOperation.cs`, `Server/RemoteOperation.cs` (`Resultats`, `GetCandidatsParDecision`, `GetAdmis`, `CompterCandidatsParDecision`) and Form1 client and Designer. Adapt database, interface, SQL and controls from aaa-tp4; Program and Remoting remain unchanged.

## Pattern and pitfalls
CASE checks elimination first and mention before ordinary admission. Classification uses the unrounded weighted grade; ROUND is for display. If the statement requires rounded classification, apply ROUND to each threshold expression. An outer query filters the calculated alias; IN includes both admitted categories.

## Verification
For the eight seed records expect 1 ADMIS, 3 ADMIS AVEC MENTION, 2 AJOURNE and 2 ELIMINE. In particular 20 written and 4 oral is ELIMINE. Verify grade boundaries and CRUD.

## Exam reuse

For another classification exercise, adapt the weights and order of CASE conditions to the exact thresholds in the énoncé.
