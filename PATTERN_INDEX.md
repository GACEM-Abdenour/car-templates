# CAR pattern index

Implemented scenarios are linked; 11–30 remain planned.

| Exam clue | Technical trick | Scenario | File / method |
|---|---|---|---|
| Prix unitaire, code-barres | decimal CRUD | [01](01_GestionProduits/README.md) | [RemoteOperation](01_GestionProduits/Server/RemoteOperation.cs): `AjouterProduit` |
| DOI unique | exact text key | [02](02_ArticlesScientifiques/README.md) | `RechercherParDOI` |
| Nom, prénom, sans majuscules | equality / UPPER | [03](03_RechercheParNom/README.md) | `RechercherParNom` |
| Commence/contient/termine par | LIKE | [04](04_RecherchePartielle/README.md) | `RechercherCommencePar`, `RechercherContient`, `RechercherTerminePar` |
| Plusieurs critères, et, ou | dynamic WHERE | [05](05_RechercheMulticritere/README.md) | `RechercherEtudiants`, `RechercherNomOuPrenom` |
| Admis, compris entre | numeric/BETWEEN | [06](06_GestionNotes/README.md) | `GetAdmis`, `RechercherNotesEntre` |
| Liste déroulante | DISTINCT / ComboBox | [07](07_FiltrageComboBox/README.md) | `GetDepartements`, `ChargerDepartements` |
| Nombre de | COUNT | [08](08_ComptageConditionnel/README.md) | `CompterCours` |
| Chiffre d'affaires | SUM / NVL | [09](09_GestionVentes/README.md) | `CalculerChiffreAffaires` |
| Moyenne / meilleure note | AVG / MAX | [10](10_StatistiquesNotes/README.md) | `CalculerMoyenne`, `GetNoteMaximale` |

| Trier, ordre croissant / décroissant | ORDER BY | [11](11_ClassementEtudiants/README.md) | [RemoteOperation](11_ClassementEtudiants/Server/RemoteOperation.cs): `TrierParNom`, `TrierParNoteCroissante`, `TrierParNoteDecroissante` |
| Les N premiers, meilleurs | ordered ROWNUM | [11](11_ClassementEtudiants/README.md) | [RemoteOperation](11_ClassementEtudiants/Server/RemoteOperation.cs): `GetMeilleursEtudiants` |
| Rang, classement, ex æquo | RANK | [11](11_ClassementEtudiants/README.md) | [RemoteOperation](11_ClassementEtudiants/Server/RemoteOperation.cs): `GetClassement` |

| Date et heure, insertion / modification | Oracle DATE | [12](12_GestionReservations/README.md) | [RemoteOperation](12_GestionReservations/Server/RemoteOperation.cs): `AjouterReservation`, `ModifierReservation` |
| Journée, entre deux dates, jusqu'au | DateTime boundaries | [12](12_GestionReservations/README.md) | [RemoteOperation](12_GestionReservations/Server/RemoteOperation.cs): `GetReservationsParDate`, `GetReservationsEntre` |
| Futures, aujourd'hui | SYSDATE / TRUNC | [12](12_GestionReservations/README.md) | [RemoteOperation](12_GestionReservations/Server/RemoteOperation.cs): `GetReservationsFutures`, `GetReservationsAujourdhui` |

| Modifier uniquement, conserver les autres champs | partial UPDATE | [13](13_ModificationPartielle/README.md) | [RemoteOperation](13_ModificationPartielle/Server/RemoteOperation.cs): `ModifierSalaire`, `ModifierDepartement`, `ModifierTelephone` |
| Champs sélectionnés, effacer téléphone | dynamic SET / DBNull | [13](13_ModificationPartielle/README.md) | [RemoteOperation](13_ModificationPartielle/Server/RemoteOperation.cs): `ModifierEmployePartiellement`; [Form1](13_ModificationPartielle/ClientForm/Form1.cs): `btnModifierSelection_Click` |

| Supprimer seulement si, produits épuisés | conditional DELETE | [14](14_SuppressionConditionnelle/README.md) | [RemoteOperation](14_SuppressionConditionnelle/Server/RemoteOperation.cs): `GetProduitsEpuises`, `SupprimerProduitSiStockNul` |
| Supprimer tous, par catégorie, confirmer | bulk DELETE / confirmation | [14](14_SuppressionConditionnelle/README.md) | [RemoteOperation](14_SuppressionConditionnelle/Server/RemoteOperation.cs): `SupprimerProduitsEpuises`, `SupprimerProduitsEpuisesParCategorie`; [Form1](14_SuppressionConditionnelle/ClientForm/Form1.cs): `btnSupprimerTousEpuises_Click` |

Planned: 15 doublons, 16 sélection grille, 17 ComboBox edit, 18 stock, 19 CASE, 20 GROUP BY, 21–30 relations, transactions, auth, serialization, multiclient and réseau.
