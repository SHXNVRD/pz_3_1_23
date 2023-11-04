using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz4_1
{
    public class User
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Phone { get; set; } = null!;
        public string? Address { get; set; } 
    }
}
