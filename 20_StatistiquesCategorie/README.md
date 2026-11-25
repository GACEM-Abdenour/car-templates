# 20 — Statistiques par catégorie

## Difficulty and trick
Easy. GROUP BY, HAVING, WHERE, weighted averages and two DataGridViews.

## Énoncé et indices
Pour chaque catégorie, regrouper les ventes, calculer leur total et afficher les catégories dépassant un seuil.

## Database and files
`VenteCategorie` stores individual sales; montant is calculated. Use database.sql only in an isolated schema. Inspect `Interfaces/IRemoteOperation.cs`, `Server/RemoteOperation.cs` (`GetStatistiquesParCategorie`, `GetCategoriesParChiffreAffaires`, `GetPrixMoyenPondereParCategorie`) and the Form1 client and Designer. Adapt the table, interface, SQL and controls from aaa-tp4; Remoting and Program remain unchanged.

## Pattern and mistakes
WHERE filters sale rows before GROUP BY; HAVING filters aggregate groups. COUNT counts records, SUM(quantite) counts units. AVG(prixunitaire) weights each sale equally; SUM(quantite*prixunitaire)/NULLIF(SUM(quantite),0) weights units. The first grid displays sales, the second statistics; CRUD clears stale statistics.

## Verification
Use a separate controlled five-row dataset: Alimentaire (2×100, 3×200), Cosmetique (1×500, 2×300), Detergent (1×100). Expected totals are 800, 1100 and 100. HAVING >1000 returns only Cosmetique. Alimentaire simple average is 150 and weighted average 160. The supplied ten-row seed has different totals.

## Exam reuse

For another grouped report, adapt the grouping columns and distinguish row filters in WHERE from aggregate filters in HAVING.
