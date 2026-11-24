# Offline code snippets

All snippets are present verbatim in the linked projects. Machine 2 uses `Oracle.ManagedDataAccess.Client`; Machine 1 uses `System.Data` and Remoting.

- **Interface declaration** — see [01 interface](01_GestionProduits/Interfaces/IRemoteOperation.cs); change types/columns to match the statement.
- **Oracle parameter / `BindByName`** — see [01 server](01_GestionProduits/Server/RemoteOperation.cs); retain parameters, never concatenate input.
- **Exact case-insensitive search** — [03](03_RechercheParNom/Server/RemoteOperation.cs), `RechercherParNom`.
- **LIKE prefix/substring/suffix** — [04](04_RecherchePartielle/Server/RemoteOperation.cs); change only the `%` placement.
- **Dynamic AND / OR** — [05](05_RechercheMulticritere/Server/RemoteOperation.cs).
- **Decimal parsing and BETWEEN** — [06](06_GestionNotes/ClientForm/Form1.cs), [server](06_GestionNotes/Server/RemoteOperation.cs).
- **ComboBox binding / SelectedValue** — [07](07_FiltrageComboBox/ClientForm/Form1.cs).
- **DISTINCT / ExecuteScalar / COUNT** — [08](08_ComptageConditionnel/Server/RemoteOperation.cs).
- **SUM / NVL / calculated SQL field** — [09](09_GestionVentes/Server/RemoteOperation.cs).
- **AVG / MIN / MAX / CASE WHEN / DBNull** — [10](10_StatistiquesNotes/Server/RemoteOperation.cs), `GetStatistiques`.
- **DataGridView binding** — every `Form1.cs`, method `Afficher`.

- **ORDER BY / ordered TOP N / RANK** — Machine 2, Server, [scenario 11](11_ClassementEtudiants/Server/RemoteOperation.cs): `TrierParNom`, `TrierParNoteCroissante`, `TrierParNoteDecroissante`, `GetMeilleursEtudiants`, `GetClassement`; `using System.Data; using Oracle.ManagedDataAccess.Client;`. Adapt table and columns, retain the ordered subquery and bound `:nombre`. `DENSE_RANK` and `ROW_NUMBER` alternatives are in the source comments. Machine 1 binds the returned DataSet in [Form1.cs](11_ClassementEtudiants/ClientForm/Form1.cs), `Afficher` (`using System.Data;`).
- **Oracle DATE / calendar-day range / SYSDATE / TRUNC** — Machine 2, Server, [scenario 12](12_GestionReservations/Server/RemoteOperation.cs), `AjouterReservation`, `ModifierReservation`, `GetReservationsEntre`, `GetReservationsFutures`, `GetReservationsAujourdhui`; `using System; using System.Data; using Oracle.ManagedDataAccess.Client;`. Adapt the table and date column; bind `OracleDbType.Date` and use an exclusive next-day upper bound. Machine 1 reads `DateTimePicker.Value` in [Form1.cs](12_GestionReservations/ClientForm/Form1.cs), `btnAjouter_Click`, and configures the custom format in [Form1.Designer.cs](12_GestionReservations/ClientForm/Form1.Designer.cs).
- **Partial UPDATE / selected SET / DBNull** — Machine 2, Server, [scenario 13](13_ModificationPartielle/Server/RemoteOperation.cs), `ModifierSalaire`, `ModifierEmployePartiellement`; `using System; using System.Collections.Generic; using Oracle.ManagedDataAccess.Client;`. Adapt fixed column fragments and primary key; bind only selected values. Machine 1 reads `CheckBox.Checked` and parses only selected salary in [Form1.cs](13_ModificationPartielle/ClientForm/Form1.cs), `btnModifierSelection_Click`.
- **Conditional and bulk DELETE / confirmation** — Machine 2, Server, [scenario 14](14_SuppressionConditionnelle/Server/RemoteOperation.cs), `SupprimerProduitSiStockNul`, `SupprimerProduitsEpuises`, `SupprimerProduitsEpuisesParCategorie`; `using System; using Oracle.ManagedDataAccess.Client;`. Adapt table, key and condition, keeping the business rule in DELETE. Machine 1 confirms using `MessageBoxButtons.YesNo` and displays affected rows in [Form1.cs](14_SuppressionConditionnelle/ClientForm/Form1.cs), `btnSupprimerTousEpuises_Click` (`using System.Windows.Forms;`).
