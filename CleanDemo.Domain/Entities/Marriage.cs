using CleanDemo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Domain.Entities
{
    public class Marriage :AuditableEntity
    {
        public int WifeId { get; set; }
        public int HusbandId { get; set; }
        public DateTime MarriageDate { get; set; }
        public Birth Wife { get; set; }
        public Birth Husband { get; set; }
    }
}
