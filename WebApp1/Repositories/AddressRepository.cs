using WebApp1.Contexts;
using WebApp1.Models.Entities;

namespace WebApp1.Repositories
{
    public class AddressRepository : Repository<AddressEntity>
    {
        public AddressRepository(IdentityDataContext context) : base(context)
        {
        }
    }
}
