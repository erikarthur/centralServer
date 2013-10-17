using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace centralServer
{
    class peerList
    {
        private string _peerA;
        private string _peerB;

        public string peerA
        {
            get { return _peerA; }
            set { _peerA = value; }
        }

        public string peerB
        {
            get { return _peerB; }
            set { _peerB = value; }
        }
    }
}
