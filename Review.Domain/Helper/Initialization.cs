using Review.Domain.Models;

namespace Review.Domain.Helper
{
    public static class Initialization
    {
        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private static Random random = new Random();
        public static List<Models.Review> SetReviews()
        {
            var count = 100;
            var reviews = new List<Models.Review>(count);
            for (int i = 1; i <= count; i++)
            {
                var review = CreateReview(i);
                reviews.Add(review);
            }
            return reviews;
        }

        public static Models.Review CreateReview(int i)
        {
            return new Models.Review()
            {
                Id = i,
                UserId = random.Next(1, 10),
                ProductId = random.Next(1, 10),
                Text = LoremIpsum.Substring(0, random.Next(20, 100)),
                Grade = random.Next(0, 6),
                CreateDate = DateTime.Now.AddDays(random.Next(-100, 0)),
                Status = (ReviewStatus)random.Next(0, 2)
            };
        }

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
