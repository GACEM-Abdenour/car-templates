using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                TcpChannel channel = new TcpChannel(1069);
                ChannelServices.RegisterChannel(channel, false);

                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(RemoteOperation),
                    "RemoteOperation",
                    WellKnownObjectMode.Singleton);

                Console.WriteLine("Le serveur a demarre avec succes sur le port 1069...");
                Console.WriteLine("En attente de requetes...");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors du demarrage du serveur : " + ex.Message);
                Console.ReadLine();
            }
        }
    }
}
