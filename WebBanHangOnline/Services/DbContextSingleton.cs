using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Services
{
    public class DbContextSingleton
    {
        private static DbContextSingleton instance;
        private ApplicationDbContext dbContext;

        private DbContextSingleton()
        {
            dbContext = new ApplicationDbContext();
        }

        public static DbContextSingleton Instance
        {
            get
            {
                if (instance == null)
                {                  
                     instance = new DbContextSingleton();
                }
                return instance;
            }
        }

        public ApplicationDbContext GetDbContext()
        {
            return dbContext;
        }
    }
}