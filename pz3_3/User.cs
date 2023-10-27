using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz3_3
{
    internal class User
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
        public uint? SexId { get; set; }
        [ForeignKey("SexId")]
        public virtual Sex? Sex { get; set; }
    }
}
