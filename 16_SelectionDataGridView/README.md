# 16 — Sélection dans un DataGridView

## Difficulty and trick
Easy. CellClick, DataRowView, selected identity and Nouveau.

## Énoncé et indices
Sélectionner une ligne pour remplir automatiquement les champs, modifier ou supprimer sans ressaisir le matricule, puis préparer un nouvel étudiant.

## Database
`EtudiantSelection` uses matricule as primary key and has nom/prenom. Run the SQL in an isolated schema.

## Files and adaptation from aaa-tp4
The new selection feature is client-side: no extra remote methods or server queries are required. Inspect `Form1.cs` (`Selectionner`, `dataGridView1_CellClick`, `Nouveau`) and `Form1.Designer.cs`. Adapt table names and CRUD in Server and database.sql; Interfaces and Program retain the TP4 contract and Remoting setup.

## Pattern and pitfalls
The active CellClick ignores headers and reads a bound DataRowView by column name. `matriculeSelectionne` preserves identity independently of the read-only TextBox. Binding and clearing use a guard. SelectionChanged and CellDoubleClick alternatives are commented in the source; do not connect multiple selection handlers without coordinating them.

## Verification
Select and edit a row; confirm its original key is used. Delete after confirmation; use Nouveau and verify editing is blocked until a new selection. Click a header and display an empty result; neither should produce invalid row access.

## Exam reuse

For another grid selection exercise, adapt the bound column names and preserve the selected key independently of display text.
