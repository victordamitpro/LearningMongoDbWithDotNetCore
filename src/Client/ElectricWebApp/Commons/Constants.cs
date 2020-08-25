using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricWebApp.Commons
{
    public struct Constant
    {
        public struct State
        {
            public const string New = "New";
            public const string Running = "Running";
            public const string Stopping = "Stopping";
        }

        public struct Type
        {
            public const string Electric = "Electric";
            public const string Water = "Water";
            public const string Gateways = "Gateways";
        }
    }
}
