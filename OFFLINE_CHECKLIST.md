# Offline checklist

- Install Visual Studio and .NET Framework 4.7.2 targeting pack.
- Confirm `System.Runtime.Remoting`, the Interfaces project reference, and `libs/Oracle.ManagedDataAccess.dll`.
- Copy Client executable, Server executable and Interfaces.dll for deployment.
- Change the client Remoting URL and the Server Oracle connection string.
- Check firewall, TCP 1069, Oracle listener and credentials. 1521 below is only an example: replace it with the teacher’s listener port.

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
