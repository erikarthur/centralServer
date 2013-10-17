﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace centralServer
{
    class Program
    {
        List<peer> peers = new List<peer>();
        List<peerList> peerList = new List<peerList>();

        static void Main(string[] args)
        {
            string strRetPage;

            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            Int32 port = 13000;
            TcpListener server = null; 

            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = null;

            while(true) 
              {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests. 
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();            
                Console.WriteLine("Connected!");

                data = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client. 
                while((i = stream.Read(bytes, 0, bytes.Length))!=0) 
                {   
                  // Translate data bytes to a ASCII string.
                  data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                  Console.WriteLine("Received: {0}", data);

                  // Process the data sent by the client.
                  data = data.ToUpper();

                  byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                  // Send back a response.
                  stream.Write(msg, 0, msg.Length);
                  Console.WriteLine("Sent: {0}", data);            
                }

        // Shutdown and end connection
        client.Close();
            
            //Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////s.Connect(EPhost);

            ////if (!s.Connected)
            //// {
            ////   strRetPage = "Unable to connect to host";
            ////}

            ////// Use the SelectWrite enumeration to obtain Socket status.  
            ////if(s.Poll(-1, SelectMode.SelectWrite))
            ////{
            ////    Console.WriteLine("This Socket is writable.");
            ////}
            ////else if (s.Poll(-1, SelectMode.SelectRead)){
            ////    Console.WriteLine("This Socket is readable." );
            ////}
            ////else if (s.Poll(-1, SelectMode.SelectError)){
            ////    Console.WriteLine("This Socket has an error.");
            ////}

            //IPAddress hostIP = (Dns.Resolve(IPAddress.Any.ToString())).AddressList[0];
            //IPEndPoint ep = new IPEndPoint(hostIP, port);
            //s.Bind(ep);
        }
    }

}
