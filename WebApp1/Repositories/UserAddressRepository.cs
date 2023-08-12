using WebApp1.Contexts;
using WebApp1.Models.Entities;

namespace WebApp1.Repositories
{
    public class UserAddressRepository : Repository<UserAddressEntity>
    {
        public UserAddressRepository(IdentityDataContext context) : base(context)
        {
        }
    }
}
