using WebApp1.Models.Entities;
using WebApp1.Models.Identity;
using WebApp1.Repositories;

namespace WebApp1.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepo;
        private readonly UserAddressRepository _userAddressRepository;

        public AddressService(UserAddressRepository userAddressRepository, AddressRepository addressRepo)
        {
            _userAddressRepository = userAddressRepository;
            _addressRepo = addressRepo;
        }

        public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
        {
            var entity = await _addressRepo.GetAsync(x =>
            x.StreetName == addressEntity.StreetName &&
            x.PostalCode == addressEntity.PostalCode &&
            x.City == addressEntity.City
            );

            entity ??= await _addressRepo.AddAsync(addressEntity);
            return entity;
        }

        public async Task AddAddressAsync(AppUser user, AddressEntity addressEntity)
        {
            await _userAddressRepository.AddAsync(new UserAddressEntity
            {
                UserId = user.Id,
                AddressId = addressEntity.Id,
            });
        }
    }
}
