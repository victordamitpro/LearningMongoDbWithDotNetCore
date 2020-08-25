using Electric.Core.CustomAttributes;
using Electric.Core.Entities.Base;

namespace Electric.Core.Entities
{
    [BsonCollection("GateWay")]
    public class GateWay : Document
    {
        public string IP { get; set; }
        public int? Port { get; set; }
    }
}
