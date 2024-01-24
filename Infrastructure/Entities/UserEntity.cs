using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class UsersEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastModified { get; set; }

        public virtual UserAuthenticationsEntity UserAuthentication { get; set; } = null!;

        //Many to many relationship
        public virtual ICollection<UserAddressesEntity> UserAddresses { get; set; } = null!;

    }

}
