# 12 — Gestion des réservations

## Difficulty and main trick
Easy. Oracle DATE, DateTimePicker, calendar-day and interval searches.

## Exam clues and énoncé
À une date donnée, entre deux dates, aujourd'hui, réservations futures : gérer les réservations d'une salle et rechercher par date.

## Database
`Reservation` has primary key `idreservation`, `responsable`, `salle` and Oracle DATE `datereservation`, including time. The SQL seeds use both explicit dates and `SYSDATE`-relative dates. Run only in an isolated schema.

## Files and adaptation from aaa-tp4
Change the schema in `database.sql`, declarations in `Interfaces/IRemoteOperation.cs`, SQL and OracleDbType.Date parameters in `Server/RemoteOperation.cs`, and handlers/DateTimePicker controls in `ClientForm/Form1.cs` and `Form1.Designer.cs`. Program.cs and Remoting setup remain unchanged. When loading a record into the picker, read the DataRow date with `Convert.ToDateTime(row["datereservation"])` after checking `DBNull`.

## Reusable pattern and mistakes
`GetReservationsEntre` binds `dateDebut.Date` and `dateFin.Date.AddDays(1)` using `>=` and `<`: the whole last day is included. An inclusive final midnight would exclude later times. This differs from an exact date-and-time interval. `SYSDATE` uses the database server clock; `TRUNC(SYSDATE)` returns midnight. Applying TRUNC to the stored column can affect ordinary index use. DateTimePicker uses a custom date-time format and decimal dates are never concatenated into SQL.

## Verification
Test 08:00, 14:30 and 23:59 on day 1 and 00:00 on day 2: a day-1 search returns three; an interval through day 2 includes all four. Test invalid ranges, CRUD, and preservation of hours and minutes.
