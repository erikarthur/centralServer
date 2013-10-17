using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace centralServer
{
    class peer
    {
        private string _hostname;
        private string _ipaddress;
        private int _port;

        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
        }

        public string ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        public int port
        {
            get { return _port; }
            set { _port = value; }
        }

    }
}
