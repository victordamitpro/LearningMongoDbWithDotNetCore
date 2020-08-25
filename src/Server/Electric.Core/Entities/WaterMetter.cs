using Electric.Core.CustomAttributes;
using Electric.Core.Entities.Base;

namespace Electric.Core.Entities
{
    [BsonCollection("WaterMetter")]
    public class WaterMetter : Document
    {
        public override string ToString()
        {
            return $"WaterMetter";
        }
    }
}
