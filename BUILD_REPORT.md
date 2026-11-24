# Build and verification report

Compilation and static inspection do not establish runtime correctness. Oracle scripts have not been run against a database, and UI runtime tests have not been performed.

| Scenario | Requirements implemented | UI event wiring | Layout inspection | Compilation | Oracle runtime | UI runtime | Remaining issues |
|---|---|---|---|---|---|---|---|
| 01 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify CRUD and ten-digit identifier with an isolated Oracle schema and the running UI; Designer runtime not tested. |
| 02 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify duplicate DOI, optional revue and apostrophes against isolated Oracle data; UI and Designer runtime untested. |
| 03 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify matching multiple rows and empty results with isolated Oracle data; UI and Designer runtime untested. |
| 04 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify literal wildcard escaping, CRUD and searches with isolated Oracle data; UI and Designer runtime untested. |
| 05 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify optional AND, OR, reset and matricule search with isolated Oracle data; UI and Designer runtime untested. |
| 06 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify CRUD, boundaries, display and layout at runtime with an isolated Oracle schema. |
| 07 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify selection events, refresh after writes and CRUD against an isolated Oracle schema. |
| 08 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify counting, CRUD and layout with isolated Oracle data and the running UI. |
| 09 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify CRUD and sales totals against isolated Oracle data and test the form at runtime. |
| 10 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed after repair | Not tested | Not tested | Verify CRUD, aggregate results and empty-table behavior in an isolated Oracle schema and UI. |

Decimal input uses the local Windows culture. Test with the machine's decimal separator. The original `aaa-tp4` was not modified during these repairs.

| Scenario | Source requirements | Event wiring | Layout inspection | Compilation | Oracle runtime | Live UI runtime | Designer runtime | Remaining issues |
|---|---|---|---|---|---|---|---|---|
| 11 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify ranking, TOP N and CRUD against an isolated Oracle schema. |
| 12 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify date/time boundaries, grid formatting and CRUD against an isolated Oracle schema. |
| 13 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify partial updates, nullable telephone and CRUD with isolated Oracle data. |
| 14 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Test confirmations and deletion conditions only with isolated practice data. |
| 15 | Incomplete | Not tested | Not tested | Not tested | Not tested | Not tested | Not tested | Template copied; implement duplicate checks, CRUD, schema, UI, SQL and documentation before using. |
