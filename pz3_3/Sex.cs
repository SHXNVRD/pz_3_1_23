using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz3_3
{
    internal class Sex
    {
        public uint Id { get; set; }
        public string Title { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
