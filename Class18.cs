/*
 * C# Program to Implement UDP
 */

//SERVER SIDE PROGRAM

using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;

class EmployeeUDPServer
{
    public static void Main()
    {
        UdpClient udpc = new UdpClient(2055);
        Console.WriteLine("Server started, servicing on port 2055");
        IPEndPoint ep = null;
        while (true)
        {
            byte[] rdata = udpc.Receive(ref ep);
            string name = Encoding.ASCII.GetString(rdata);
            string job = ConfigurationSettings.AppSettings[name];
            if (job == null) job = "No such employee";
            byte[] sdata = Encoding.ASCII.GetBytes(job);
            udpc.Send(sdata, sdata.Length, ep);
        }
    }
}//XML CODING


<? xml version = "1.0" encoding = "utf-8" ?>
< configuration >
  < appSettings >
    < add key = "mickey" value = "manager" />
    < add key = "bob" value = "tester" />
    < add key = "tom" value = "clerk" />
    < add key = "jerry" value = "manager" />
  </ appSettings >
</ configuration >
 
//CLIENT SIDE PROGRAM
 
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class EmployeeUDPClient
{
    public static void Main(string[] args)
    {
        UdpClient udpc = new UdpClient("Win7-PC", 2055);
        IPEndPoint ep = null;
        while (true)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            if (name == "") break;
            byte[] sdata = Encoding.ASCII.GetBytes(name);
            udpc.Send(sdata, sdata.Length);
            byte[] rdata = udpc.Receive(ref ep);
            string job = Encoding.ASCII.GetString(rdata);
            Console.WriteLine(job);
        }
    }
}