using Education_Database.Models;

namespace Education_Database.Repositories
{
    class AddressRepository : BaseRepository<Address>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM Address";

    }
}
