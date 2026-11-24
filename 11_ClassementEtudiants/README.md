# 11 — Classement des étudiants

## Difficulty and main trick
Easy. ORDER BY, TOP N with ordered ROWNUM, and RANK for ex æquo.

## Exam clues
Trier, ordre alphabétique, note croissante ou décroissante, les N premiers, rang, classement et ex æquo.

## Énoncé
Gérer les notes des étudiants et afficher les meilleurs ou leur classement général.

## Database
`EtudiantClassement` has primary key `matricule`, names and a grade constrained to 0–20. Run `database.sql` only in an isolated practice schema.

## Files and adaptation from aaa-tp4
Add declarations in `Interfaces/IRemoteOperation.cs`, SQL in `Server/RemoteOperation.cs` (`TrierParNom`, `TrierParNoteCroissante`, `TrierParNoteDecroissante`, `GetMeilleursEtudiants`, `GetClassement`), handlers in `ClientForm/Form1.cs`, and controls in `Form1.Designer.cs`. Change the table and columns in SQL and database script. Program.cs and Remoting configuration stay unchanged.

## Reusable snippets and common mistakes
`ORDER BY note DESC, matricule ASC` makes ties deterministic. Apply `ROWNUM` outside the sorted subquery, otherwise the wrong rows can be selected. Bind N, but never concatenate arbitrary column names or ASC/DESC: select fixed queries from a whitelist.

`RANK() OVER (ORDER BY note DESC)` gives tied grades the same rank and leaves gaps. `DENSE_RANK() OVER (ORDER BY note DESC)` removes gaps; `ROW_NUMBER() OVER (ORDER BY note DESC, matricule)` gives unique positions. Adding matricule inside the RANK ordering would eliminate grade ties. TOP N returns exactly N rows if available; it does not include all ties at the cutoff.

## Verification
For 18, 16, 16, 12, 9 expect RANK 1, 2, 2, 4, 5 and DENSE_RANK 1, 2, 2, 3, 4. Request three rows and test zero and negative N. Verify CRUD and switching from rank to ordinary grid columns.
