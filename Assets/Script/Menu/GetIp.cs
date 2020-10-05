using UnityEngine;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using TMPro;


public class GetIp : MonoBehaviour
{
    public TextMeshProUGUI TMIP;
    private static string TEXTIP = "IP: ";  
    void Awake() {
        string IP = GetLocalIPAddress();
        TMIP.text = TEXTIP + IP;
    }

        public static string GetLocalIPAddress()
    {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
}
