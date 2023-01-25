using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatterFitness.Dal.Entities.Charts
{
    public class DailyValueEntity
    {
        public DateTime Day { get; set; }
        public double Value { get; set; }
    }
}
