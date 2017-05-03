using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Data.Entity;

namespace IdentityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var userStroe = new UserStore<IdentityUser>();
            //var userMgr = new UserManager<IdentityUser>(userStroe);

            //var result = userMgr.Create(new IdentityUser("satish@gmail.com"),"password");

            var userStore = new CustomUserStore(new CustomUserDbContext());
            var userMgr = new UserManager<CustomUser, int>(userStore);

            var result = userMgr.Create(new CustomUser { UserName= "satish@gmail.com"}, "password");


            Console.WriteLine("User Created: {0}", result.Succeeded);

            Console.ReadLine();
        }
    }

    public class CustomUser : IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }
    }

    public class CustomUserDbContext: DbContext
    {
        public CustomUserDbContext(): base("DefaultConnection")
        {

        }

        public DbSet<CustomUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var user = modelBuilder.Entity<CustomUser>();
            user.ToTable("Users");
            user.HasKey(x => x.Id);
            user.Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            user.Property(x => x.UserName).IsRequired().HasMaxLength(256).HasColumnAnnotation("Index", new System.Data.Entity.Infrastructure.Annotations.IndexAnnotation(new System.ComponentModel.DataAnnotations.Schema.IndexAttribute("UserNameIndex") { IsUnique = true }));

            base.OnModelCreating(modelBuilder);
        }
    }

    public class CustomUserStore : IUserPasswordStore<CustomUser, int>
    {
        private readonly CustomUserDbContext context;

        public CustomUserStore(CustomUserDbContext context)
        {
            this.context = context;
        }

        public Task CreateAsync(CustomUser user)
        {
            context.Users.Add(user);
            return context.SaveChangesAsync();
        }

        public Task DeleteAsync(CustomUser user)
        {
            context.Users.Remove(user);
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Task<CustomUser> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(user);
        }

        public Task UpdateAsync(CustomUser user)
        {
            context.Users.Attach(user);
            return context.SaveChangesAsync();
        }
    }
}
