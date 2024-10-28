using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public UserManager(IUserDal userDal, IMapper mapper,ApplicationDbContext applicationDbContext)
        {
            _userDal = userDal;
            _mapper = mapper;
            _context = applicationDbContext;
        }

        public Task TInsertAsync(User t)
        {
            _context.Add(t);
            return _context.SaveChangesAsync();
        }

        public void TDelete(User t)
        {
            _userDal.Delete(t);
        }

        public User TGetByID(int id)
        {
            return _userDal.GetByID(id);
        }

        public List<User> TGetList()
        {
            return _userDal.GetList();
        }

        public void TInsert(User t)
        {
            _userDal.Insert(t);
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }
    }
}
