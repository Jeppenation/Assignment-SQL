namespace Infrastructure.Entities
{
    public class UserAddressesEntity 
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }

        //Many to many relationship
        public virtual UsersEntity User { get; set; } = null!;
        public virtual AddressesEntity Address { get; set; } = null!;
    }

}
