using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace CompiledContent.LikeIPConfig
   {
   class Program
      {
      /// <summary>
      /// Obtains information about network interfaces. Formats and returns it 
      /// similar to "ipconfig" command.
      /// </summary>
      public static string GetNetworkInformation(Boolean activeOnly)
         {
         string title;
         StringBuilder info = new StringBuilder();

         NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

         if (nics == null || nics.Length < 1)
            {
            info.AppendLine("No network interfaces found.");
            return info.ToString();
            }

         title = String.Format("{0}Network Interfaces", activeOnly ? "Active " : "");
         info.AppendLine(title);
         info.AppendLine(String.Empty.PadLeft(title.Length, '='));
         foreach (NetworkInterface adapter in nics)
            {
            IPInterfaceProperties properties = adapter.GetIPProperties();

            // continue to the next adapter if we are only showing active ones.
            if (activeOnly && adapter.OperationalStatus != OperationalStatus.Up)
               continue;

            info.AppendLine();
            title = String.Format("{0} adapter {1}", adapter.NetworkInterfaceType, adapter.Name);
            info.AppendLine(title);
            info.AppendLine(String.Empty.PadLeft(title.Length, '-'));

            info.AppendFormat("Description . . . . . . . . . . . . . . . : {0}\n", adapter.Description);
            info.AppendFormat("Physical Address  . . . . . . . . . . . . : {0}\n", adapter.GetPhysicalAddress());
            info.AppendFormat("Operational status  . . . . . . . . . . . : {0}\n", adapter.OperationalStatus);

            // The following information is not useful for loopback adapters.
            if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
               {
               continue;
               }

            // DNS
            info.AppendFormat("DNS Services  . . . . . . . . . . . . . . : {0}\n",
               properties.IsDynamicDnsEnabled ? "dynamic" : properties.IsDnsEnabled
               ? "enabled" : "disabled");

            if (!String.IsNullOrEmpty(properties.DnsSuffix))
               {
               info.AppendFormat("DNS Suffix  . . . . . . . . . . . . . . . : {0}\n",
                  properties.DnsSuffix);
               }

            if (properties.DnsAddresses != null && properties.DnsAddresses.Count > 0)
               {
               AddIpAddresses(info, "DNS Servers . . . . . . . . . . . . . . . : ", properties.DnsAddresses);
               }

            // IPv4
            if (adapter.Supports(NetworkInterfaceComponent.IPv4))
               {
               IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
               if (ipv4 != null)
                  {
                  if (ipv4.UsesWins)
                     {
                     IPAddressCollection winsServers = properties.WinsServersAddresses;
                     if (winsServers != null && winsServers.Count > 0)
                        {
                        AddIpAddresses(info, "WINS Servers  . . . . . . . . . . . . . . : ", winsServers);
                        }
                     }
                  info.AppendFormat("IPv4 DHCP Enabled . . . . . . . . . . . . : {0}\n", ipv4.IsDhcpEnabled);
                  info.AppendFormat("IPv4 MTU  . . . . . . . . . . . . . . . . : {0}\n", ipv4.Mtu);
                  }
               }

            // IPv6
            if (adapter.Supports(NetworkInterfaceComponent.IPv6))
               {
               IPv6InterfaceProperties ipv6 = properties.GetIPv6Properties();
               if (ipv6 != null)
                  {
                  info.AppendFormat("IPv6 MTU  . . . . . . . . . . . . . . . . : {0}\n", ipv6.Mtu);
                  info.AppendFormat("IPv6 Interface Index  . . . . . . . . . . : {0}\n", ipv6.Index);
                  }
               }

            info.AppendFormat("Speed . . . . . . . . . . . . . . . . . . : {0} MBps\n",
               adapter.Speed / 1000000);
            info.AppendFormat("Receive Only  . . . . . . . . . . . . . . : {0}\n",
               adapter.IsReceiveOnly);
            info.AppendFormat("Multicast . . . . . . . . . . . . . . . . : {0}\n",
               adapter.SupportsMulticast);
            }
         return info.ToString();
         }

      /// <summary>
      /// Formats and adds the IPAddress information to the String builder object
      /// </summary>
      private static void AddIpAddresses(StringBuilder info, string text, IPAddressCollection ipAddresses)
         {
         bool doneFirst = false;

         foreach (var address in ipAddresses)
            {
            if (!doneFirst)
               {
               info.AppendFormat("{0}{1}\n", text, address);
               doneFirst = true;
               }
            else
               {
               info.AppendFormat("                                          : {0}\n", address);
               }
            }
         }

      static void Main(string[] args)
         {
         Console.WriteLine(GetNetworkInformation(true));
         Console.ReadLine();
         }
      }
   }