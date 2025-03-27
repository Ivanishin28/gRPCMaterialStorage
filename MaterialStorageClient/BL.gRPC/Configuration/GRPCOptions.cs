using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.gRPC.Configuration
{
    public class GRPCOptions
    {
        public const string SECTION_NAME = "GRPCOptions";

        public string ChannelAddress { get; set; }
    }
}
