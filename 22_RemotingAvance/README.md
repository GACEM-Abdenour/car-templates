# 22 — Remoting avancé

## Advanced: serialization and activation
This scenario intentionally uses no Oracle database. `Etudiant` and `ResultatCompteur` in Interfaces are `[Serializable]` copies; `RemoteOperation` inherits MarshalByRefObject and is accessed through a proxy. A DataSet carries tables; `List<Etudiant>` carries strongly typed objects whose public properties bind to a grid.

## Exam clues and files
Objet distant, passage par valeur, proxy, Singleton, SingleCall, état partagé, plusieurs clients, concurrence, IP and URI. Inspect `Interfaces/IRemoteOperation.cs`, `Etudiant.cs`, `ResultatCompteur.cs`, `Server/RemoteOperation.cs`, `Server/Program.cs`, and `ClientForm/Form1.cs` and `Form1.Designer.cs`.

## Configuration and safety
Change `Server/App.config` Port, ObjectUri and ActivationMode (Singleton or SingleCall), then restart the server. Change ServerIp, ServerPort and ObjectUri in `ClientForm/App.config`; copy matching Interfaces.dll versions. `Activator.GetObject` creates a proxy without proving reachability: use Tester connexion. Open TCP 1069 in the server firewall only for the trusted lab. The server deliberately sets `TypeFilterLevel.Full` for custom object deserialization; unsecured .NET Remoting and permissive deserialization must be restricted to an isolated trusted network, never exposed publicly.

## Patterns and verification
Modify a returned student locally, retrieve it again, and compare; sending an object changes the server's copy and the returned object, not the original client instance. Singleton keeps one instance counter; SingleCall creates a new instance per invocation. `InitializeLifetimeService` disables lease expiry, not SingleCall semantics. Static counters are shared within the application domain but not durable across restart. Interlocked makes increments atomic; Singleton alone does not ensure thread safety. For concurrent testing, reset the Singleton counter, run 100 calls and inspect successes and failures; completion order may differ. Launch two client processes to compare modes.

Commands: run `ipconfig` and `ping SERVER_IP` on the relevant machine and `Test-NetConnection SERVER_IP -Port 1069` on the client. A TCP test does not validate the Remoting URI or assembly versions.

Actual local checks: Singleton returned instance counts 1,2 with the same ID; the sent `ali` remained lowercase locally and returned `ALI`, the original server record remained `Benali`, and the list had two records. SingleCall returned 1,1 with distinct IDs while static counts were 1,2. UI, two-client and concurrent tests have not been run.

## Exam reuse

For another remote object, adapt the shared serializable contract and client configuration together; keep the client and server Interfaces assemblies compatible.
