using LocalShopDataAccessLayer.Models;
namespace LocalShop.Services
{
    public class AuthService
    {
        private LocalShopDbContext _context;
        public AuthService()
        {
            _context = new LocalShopDbContext();
        }

        public async Task<Person?> LoginCheck(string Email, string Password)
        {
            Person? person = _context.People.FirstOrDefault(p => p.Password == Password && p.Email == p.Email);
            return person;
        }
        public async Task Register(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
        }

    }
}
