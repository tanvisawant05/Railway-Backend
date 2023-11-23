using RailwayReservationJWT.Data;
using RailwayReservationJWT.Interface;
using RailwayReservationJWT.Models;

namespace RailwayReservationJWT.Repository
{
    public class AdminRepository : IAdmin
    {
        private readonly RailwayContext _context;
        public AdminRepository(RailwayContext context)
        {
            _context = context;
        }
        public Admin Get(string name)
        {
            return _context.admins.FirstOrDefault(u => u.AdminName == name);
        }
        public List<Admin> GetAll()
        {
            return _context.admins.ToList();
        }
        public Admin Delete(string name)
        {
            Admin admin = _context.admins.FirstOrDefault(u => u.AdminName == name);
            if (admin != null)
            {
                _context.admins.Remove(admin);
                _context.SaveChanges();
            }
            return admin;
        }
        public void Add(Admin admin)
        {
            _context.admins.Add(admin);
            _context.SaveChanges();
        }
        public Admin Update(string name, Admin admin)
        {
            Admin admin1 = _context.admins.FirstOrDefault();
            if (admin1 != null)
            {
                admin1 = admin;
                _context.SaveChanges();
            }
            return admin1;
        }
    }
}