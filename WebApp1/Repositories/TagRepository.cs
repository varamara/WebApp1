using WebApp1.Contexts;
using WebApp1.Models.Entities;

namespace WebApp1.Repositories
{
    public class TagRepository : Repository<TagEntity>
    {
        public TagRepository(IdentityDataContext context) : base(context)
        {
        }
    }
}
