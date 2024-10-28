using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserDal:GenericRepositories<User>,IUserDal
    {
       

        public EfUserDal(ApplicationDbContext context, IConfiguration configuration) : base(context)
        {
            
        }
        
    }
}
