using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var userStroe = new UserStore<IdentityUser>();
            var userMgr = new UserManager<IdentityUser>(userStroe);

            var result = userMgr.Create(new IdentityUser("satish32@gmail.com"),"password");

            Console.WriteLine("User Created: {0}", result.Succeeded);

            Console.ReadLine();
        }
    }
}
