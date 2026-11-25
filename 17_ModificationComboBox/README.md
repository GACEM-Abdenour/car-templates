# 17 — Modification à partir d'un ComboBox

## Difficulty and trick
Easy. DisplayMember, ValueMember, SelectedValue and SelectionChangeCommitted.

## Énoncé et indices
Sélectionner un enseignant dans une liste déroulante, charger ses détails et le modifier par matricule, même si deux noms sont identiques.

## Database and files
`EnseignantSelection` has a primary key and optional specialite. Inspect `Interfaces/IRemoteOperation.cs`, `Server/RemoteOperation.cs` (`GetListeEnseignants`, `RechercherEnseignant`), and `ClientForm/Form1.cs` (`ChargerListeEnseignants`, `ChargerEnseignantSelectionne`). Adapt the SQL, controls and handlers from aaa-tp4; Remoting and Program remain unchanged.

## Pattern and mistakes
The display label includes the matricule; SelectedValue is the key, not SelectedIndex. Programmatic selection restoration requires an explicit detail load because SelectionChangeCommitted is user-driven. Scenario 07 selects a department to filter many employees; this scenario selects one teacher by identifier.

## Verification
Load both Benali Ahmed records, edit 10002 and verify 10001 is unchanged. Check renamed list entry, deletion refresh and empty list. Run database.sql in an isolated schema.

## Exam reuse

For another lookup list, adapt DisplayMember and ValueMember to the display label and stable primary key.
