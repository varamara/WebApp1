using Microsoft.EntityFrameworkCore;
using WebApp1.Contexts;
using WebApp1.Models.Entities;
using WebApp1.ViewModels;

namespace WebApp1.Services
{
    public class ContactService
    {
        private readonly IdentityContext _context;

        public ContactService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterMessageAsync(ContactFormViewModel viewModel)
        {
            var contactEntity = (ContactFormEntity)viewModel;

            _context.ContactForms.Add(contactEntity);
            await _context.SaveChangesAsync();

            return true; // Meddelandet sparades
        }
    }
}
