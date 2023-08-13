using WebApp1.Contexts;
using WebApp1.Models.Entities;

namespace WebApp1.Repositories
{
    public class ContactFormRepository : Repository<ContactFormEntity>
    {
        public ContactFormRepository(IdentityContext context) : base(context)
        {
        }
    }
}
