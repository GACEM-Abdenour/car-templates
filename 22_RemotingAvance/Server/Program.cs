using System;
using System.Collections;
using System.Configuration;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;

namespace Server
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                int port;
                if (!int.TryParse(ConfigurationManager.AppSettings["Port"], out port) || port < 1 || port > 65535) throw new ArgumentException("Port invalide.");
                string uri = ConfigurationManager.AppSettings["ObjectUri"];
                if (string.IsNullOrWhiteSpace(uri)) throw new ArgumentException("URI manquante.");
                string configuration = ConfigurationManager.AppSettings["ActivationMode"];
                WellKnownObjectMode mode;
                if (configuration == "Singleton") mode = WellKnownObjectMode.Singleton;
                else if (configuration == "SingleCall") mode = WellKnownObjectMode.SingleCall;
                else throw new ArgumentException("ActivationMode doit être Singleton ou SingleCall.");
                // Full formatter deserialization is deliberately enabled only for the trusted isolated lab.
                var sink = new BinaryServerFormatterSinkProvider { TypeFilterLevel = TypeFilterLevel.Full };
                var properties = new Hashtable();
                properties["port"] = port;
                var channel = new TcpChannel(properties, null, sink);
                ChannelServices.RegisterChannel(channel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteOperation), uri, mode);
                Console.WriteLine("Mode {0}, TCP {1}/{2}. Entrée pour arrêter.", mode, port, uri);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur serveur : " + ex.Message);
                Console.ReadLine();
            }
        }
    }
}
