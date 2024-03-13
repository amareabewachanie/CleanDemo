using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Domain.Common
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set;}
        public DateTime? UpdatedDate { get; set; }
    }
}
