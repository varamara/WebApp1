using WebApp1.Models.Dtos;
using WebApp1.Models.Entities;
using WebApp1.Models.Schemas;
using WebApp1.Repositories;

namespace WebApp1.Services
{
    public class TagService
    {
        
        private readonly TagRepository _tagRepo;

        public TagService(TagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }

        public async Task<Tag> CreateTagAsync(string tagName)
        {
            var entity = new TagEntity { TagName = tagName };
            var result = await _tagRepo.AddAsync(entity);
            return result;
        }

        public async Task<Tag> CreateTagAsync(TagSchema tagSchema)
        {
            var result = await _tagRepo.AddAsync(tagSchema);
            return result;
        }

        public async Task<Tag> GetTagAsync(string tagName)
        {
            var result = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return result;
        }

        public async Task<Tag> GetTagAsync(TagSchema tagSchema)
        {
            var result = await _tagRepo.GetAsync(x => x.TagName == tagSchema.TagName);
            return result;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            var result = await _tagRepo.GetAllAsync();
            var list = new List<Tag>();
            foreach (var tag in result)
                list.Add(tag);

            return list;
        }

        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            if (entity != null)
            {
                entity.TagName = tag.TagName;
                var result = await _tagRepo.UpdateAsync(entity);
                return result;
            }

            return null!;
        }

        public async Task<bool> DeleteTagAsync(int id)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == id);
            return await _tagRepo.DeleteAsync(entity);
        }

        public async Task<bool> DeleteTagAsync(string tagName)
        {
            var entity = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return await _tagRepo.DeleteAsync(entity);
        }

        public async Task<bool> DeleteTagAsync(Tag tag)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            return await _tagRepo.DeleteAsync(entity);
        }
    }
}
