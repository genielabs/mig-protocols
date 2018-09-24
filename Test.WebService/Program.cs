/*
  This file is part of MIG (https://github.com/genielabs/mig-service-dotnet)
 
  Copyright (2012-2018) G-Labs (https://github.com/genielabs)

  Licensed under the Apache License, Version 2.0 (the "License");
  you may not use this file except in compliance with the License.
  You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.
*/

using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

using MIG;
using MIG.Config;

namespace Test.WebService
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string webPort = "8088";

            Console.WriteLine("MigService test APP");
            Console.WriteLine("URL: http://localhost:{0}", webPort);

            var migService = new MigService();

            // Add and configure the Web gateway
            var web = migService.AddGateway("WebServiceGateway");
            web.SetOption("HomePath", "html");
            web.SetOption("BaseUrl", "/pages/");
            web.SetOption("Host", "*");
            web.SetOption("Port", webPort);
            web.SetOption("Password", "");
            web.SetOption("EnableFileCaching", "False");

            /*
            // Add and configure the Web Socket gateway
            var ws = migService.AddGateway("WebSocketGateway");
            ws.SetOption("Port", "8181");
            */
            
            migService.StartService();

            // Enable UPnP interface

            var upnp = migService.AddInterface("Protocols.UPnP", "MIG.Protocols.dll");
            migService.EnableInterface("Protocols.UPnP");

            while (true)
            {
                Thread.Sleep(10000);
            }

        }
    }
}
