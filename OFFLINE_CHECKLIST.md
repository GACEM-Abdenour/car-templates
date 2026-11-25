# Offline checklist

For scenario 21 configure OraclePrincipale and optionally OracleSecondaire in its Server/App.config. For scenario 22 configure client IP, port and URI plus server activation mode in App.config; both sides need matching Interfaces.dll. Restart the server after changing activation mode. Full formatter deserialization and unsecured Remoting are limited to a trusted isolated lab.

- Install Visual Studio and .NET Framework 4.7.2 targeting pack.
- Confirm `System.Runtime.Remoting`, the Interfaces project reference, and `libs/Oracle.ManagedDataAccess.dll`.
- Copy Client executable, Server executable and Interfaces.dll for deployment.
- Change the client Remoting URL and the Server Oracle connection string.
- Check firewall, TCP 1069, Oracle listener and credentials. 1521 below is only an example: replace it with the teacher’s listener port.

## Physical deployment

- Client machine: install the required .NET Framework runtime, copy the client and its matching `Interfaces.dll`, and configure the server IP, TCP port 1069 and object URI.
- Server machine: install the .NET Framework runtime, copy the server, its matching `Interfaces.dll` and, for scenarios 01–21, `Oracle.ManagedDataAccess.dll`. Configure the Oracle connection string for the intended practice schema. Permit inbound TCP 1069 in Windows Firewall on the trusted network.
- Oracle machine: start the database and listener, confirm the database host, listener port and service name, and provide an isolated practice schema and credentials. Allow the listener port through the firewall where needed. Scenario 22 does not use Oracle.
- Development machine: install Visual Studio with .NET Framework 4.7.2 targeting tools; keep the scenario's local `libs` folder and all project files together. Build the client and server against the same version of the shared Interfaces assembly.

For a manual UI check, start the scenario server and client, exercise the controls and input validation, then inspect grid refreshes and layout. Open each form in Visual Studio Designer separately; compilation alone does not test the designer. Use isolated practice data for database operations.

On each relevant Windows machine:
```cmd
ipconfig
ping SERVER_IP
```
On Machine 1:
```powershell
Test-NetConnection SERVER_IP -Port 1069
```
On Machine 2:
```powershell
Test-NetConnection DATABASE_IP -Port 1521
New-NetFirewallRule -DisplayName "CAR Remoting 1069" -Direction Inbound -Protocol TCP -LocalPort 1069 -Action Allow
```
