using Review.Domain.Models;

namespace Review.Domain.Helper
{
    public static class Initialization
    {
        public static List<Login> SetLogins()
        {
            var logins = new List<Login>();
            var login1 = new Login()
            {  
                Id = 1,
                UserName = "admin", 
                Password = "admin" 
            };
            logins.Add(login1);
            return logins;
        }
    }
}
