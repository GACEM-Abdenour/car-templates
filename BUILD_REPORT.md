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

## Subsequent environment and portability checks

- The local Oracle FREE service and its listener are running; the listener on port 1521 advertises `freepdb1`. A read-only connection probe to the scenarios' configured endpoint `localhost:1522/XEPDB1` succeeded and identified schema `ORACLE`. Its isolation and ownership have not been established, so no database scripts or modifying SQL were executed. Oracle CRUD, stock concurrency and scenario 21 rollback remain untested.
- Static file checks found the expected interface, server, client, configuration, README and solution files for all 22 scenarios, and a local Oracle provider DLL and database script for each of 01–21. Scenario 22 has no Oracle DLL by design. This check does not prove portable offline builds or validate every resource and reference.
- Relative Markdown file links in the five central references resolve to existing paths. Method names and every resource have not yet been fully checked. Existing compilation and scenario 22 Remoting probe results below are retained; concurrent clients, live UI and Designer runtime remain untested.

| Scenario | Source requirements | Event wiring | Layout inspection | Compilation | Oracle runtime | Live UI runtime | Designer runtime | Remaining issues |
|---|---|---|---|---|---|---|---|---|
| 11 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify ranking, TOP N and CRUD against an isolated Oracle schema. |
| 12 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify date/time boundaries, grid formatting and CRUD against an isolated Oracle schema. |
| 13 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify partial updates, nullable telephone and CRUD with isolated Oracle data. |
| 14 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Test confirmations and deletion conditions only with isolated practice data. |
| 15 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify uniqueness, normalization, concurrent inserts and CRUD in an isolated Oracle schema. |
| 16 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify selection, rebinding and CRUD in the running UI with isolated Oracle data. |
| 17 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify duplicate names, refresh and selection restoration with isolated Oracle data. |
| 18 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Test stock limits, concurrent exits, CRUD and layout against isolated Oracle data. |
| 19 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify decisions, boundaries, CRUD and layout against isolated Oracle data. |
| 20 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify grouped results, CRUD, two grids and weighted average against isolated Oracle data. |
| 21 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not tested | Not tested | Not tested | Verify rollback, stock concurrency, both connections, master-detail and Designer behavior with isolated Oracle data. |
| 22 | Complete by static inspection | Passed by static inspection | Passed by static inspection | Passed | Not applicable | Not tested | Not tested | Local Remoting probe passed: copy serialization and list, Singleton 1/2 same instance; SingleCall 1/1 distinct instances and static 1/2. UI, two-client and concurrent tests not run. |
