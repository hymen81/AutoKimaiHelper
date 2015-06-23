using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace autoKimaiHelper
{
    class NetWorkCheck
    {
        private string ipText;
        private string subMarkText;
        private string gateWayText;
        private string dns1Text;
        private string dns2Text;
        private string dnsSuffixText;

        public NetWorkCheck()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                bool Pd1 = (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet); 
                if (Pd1)
                {
                    IPInterfaceProperties ip = adapter.GetIPProperties();  
                    if (ip.UnicastAddresses.Count > 0)
                    {
                        ipText = ip.UnicastAddresses[0].Address.ToString();//IP地址
                        subMarkText = ip.UnicastAddresses[0].IPv4Mask.ToString();//子网掩码

                    }
                    if (ip.GatewayAddresses.Count > 0)
                    {
                        gateWayText = ip.GatewayAddresses[0].Address.ToString();//默认网关
                    }
                    
                    dnsSuffixText = ip.DnsSuffix.ToString();
                    if (dnsSuffixText.IndexOf("acer") != -1)
                        break;
                    int DnsCount = ip.DnsAddresses.Count;
                    //Console.WriteLine("DNS服务器地址：");
                    if (DnsCount > 0)
                    {
                        try
                        {
                            dns1Text = ip.DnsAddresses[0].ToString(); //主DNS
                            dns2Text = ip.DnsAddresses[1].ToString(); //备用DNS地址
                        }
                        catch (Exception er)
                        {
                            throw er;
                        }
                    }
                }
            }
        }

        public string dnsName 
        {
            get 
            {
                return dnsSuffixText;
            }
        }
    }
}
