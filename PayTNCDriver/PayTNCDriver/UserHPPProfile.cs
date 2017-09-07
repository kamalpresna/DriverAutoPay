using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver
{
    public partial class UserHPPProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string HPPProfileId { get; set; }
        public string FriendlyName { get; set; }
        public Nullable<bool> PrimaryProfile { get; set; }
    }
}
