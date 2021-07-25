using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class User : AuditableEntity<long>
    {
        public string UserName { get; set; }

        public string NickName { get; set; }

        public string AvatarUrl { get; set; }
    }
}
