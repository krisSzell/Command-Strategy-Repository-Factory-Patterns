using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWashServiceBrowserFull.API
{
    public class ContextInstanceProvider
    {
        private static AppDbContext _instance;

        private ContextInstanceProvider() { }

        public static AppDbContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppDbContext();
                }
                return _instance;
            }
        }
    }
}