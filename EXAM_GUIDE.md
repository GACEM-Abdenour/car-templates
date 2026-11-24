# CAR practical-exam guide

1. Identify the table, primary key, columns and Oracle types.
2. List CRUD, filters and statistics.
3. Find the wording in `PATTERN_INDEX.md`.
4. Change `Interfaces/IRemoteOperation.cs` first.
5. Add explicit parameterized SQL in `Server/RemoteOperation.cs`.
6. Add controls and handlers in `ClientForm/Form1.cs`.
7. On Machine 1 change `tcp://localhost:1069/RemoteOperation`; on Machine 2 change `oradb`.
8. Build all projects and test each requested operation.

Examples: department + salary threshold + count combines 07 (ComboBox), 06 (comparison) and 08 (COUNT). Name keyword plus average combines 04 and 10. Product sales by designation plus total combines 01 and 09.

For “les cinq meilleurs étudiants du groupe G2 ayant une moyenne >= 10”, combine 05's filters, 06's numeric condition and 11's ordered ROWNUM. Filter in the inner SELECT, sort it, then apply ROWNUM. Add the filter and count parameters to `IRemoteOperation.cs`; implement the SQL in `RemoteOperation.cs`; read inputs and call it from `Form1.cs`; add the corresponding controls in `Form1.Designer.cs`.

For “calculer le chiffre d'affaires entre deux dates”, combine 09's SUM with 12's day boundaries: add two DateTime parameters in `IRemoteOperation.cs`, apply `datevente >= :debut AND datevente < :finExclusive` around the SUM in `RemoteOperation.cs`, and add two date pickers and their handler in `Form1.Designer.cs` and `Form1.cs`.

For “rechercher un employé puis modifier uniquement son salaire”, combine 03's key lookup and 13's `ModifierSalaire`: declare both in `IRemoteOperation.cs`, put the lookup and single-column UPDATE in `RemoteOperation.cs`, and add matricule/salary controls and handlers in `Form1.Designer.cs` and `Form1.cs`. The UPDATE leaves all other fields untouched.

For “afficher une catégorie puis supprimer uniquement les produits sans stock”, combine 07's ComboBox filtering with 14's category DELETE. Add the signatures in `IRemoteOperation.cs`, SQL with `categorie=:categorie AND quantite=0` in `RemoteOperation.cs`, and selection and confirmation controls/handlers in `Form1.Designer.cs` and `Form1.cs`. Keep the stock rule in the DELETE itself.
