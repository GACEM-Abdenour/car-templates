# 13 — Modification partielle

## Difficulty and main trick
Easy. Fixed and dynamic UPDATE SET, CheckBox flags and nullable telephone.

## Exam clues and énoncé
Modifier uniquement, conserver les autres attributs, champs sélectionnés : gérer les employés et modifier seulement les champs choisis.

## Database
`EmployeModification` uses matricule as primary key, department, salary and optional telephone. Telephone is VARCHAR2 to preserve leading zeroes and `+`. Run `database.sql` in an isolated schema.

## Files and adaptation from aaa-tp4
Add signatures to `Interfaces/IRemoteOperation.cs`, fixed methods `ModifierSalaire`, `ModifierDepartement`, `ModifierTelephone` and dynamic `ModifierEmployePartiellement` to `Server/RemoteOperation.cs`, the `btnModifierSelection_Click` handler to `ClientForm/Form1.cs`, and checkboxes/buttons to `Form1.Designer.cs`. Change the table and columns in the database script. Program and Remoting configuration remain unchanged.

## Reusable pattern and mistakes
Build `List<string>` of fixed SET fragments, `string.Join` them, bind only selected parameters and always include the primary key in WHERE. A false flag leaves a column untouched; a selected blank telephone binds `DBNull.Value` to clear it. Do not parse unselected salary and do not fetch and rewrite all fields, which can overwrite concurrent changes.

## Verification
Change salary 50000 to 65000 and verify other fields remain unchanged. Change department and telephone together; clear telephone; test no selection, invalid unselected salary and unknown matricule. Check affected row count and CRUD.

## Exam reuse

For another partial edit, adapt the fixed SET fragments and parameter types while keeping the primary key in the WHERE clause.
