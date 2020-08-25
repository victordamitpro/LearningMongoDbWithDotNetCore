using Electric.Core.CustomAttributes;
using Electric.Core.Entities.Base;

namespace Electric.Core.Entities
{
    [BsonCollection("ElectricMetter")]
    public class ElectricMetter : Document
    {
        public override string ToString()
        {
            return $"ElectricMetter";
        }
    }
}
