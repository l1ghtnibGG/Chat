namespace ChatApp.Models.Repo
{
    public class EfUserRepository : IChatRepository<User>
    {
        private readonly ChatDbContext _context;
        public EfUserRepository(ChatDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetValues => _context.Users;

        public User Add(User item)
        {
            var user = new User
            {
                Name = item.Name,
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Name = "Programmer"
                    },
                    new Tag
                    {
                        Name = "Upper"
                    },
                    new Tag
                    {
                        Name = "Lowest"
                    },
                    new Tag
                    {
                        Name = "All"
                    },
                    new Tag
                    {
                        Name = "HR"
                    }
                }
            };

            _context.Users.Add(user);  
            _context.SaveChanges();

            return user;    
        }

        public IQueryable<Tag> GetUserTags(User user) => (from tags in _context.Tags
                                                    where tags.Users.Any(x => x.Id == user.Id)
                                                    select tags);
    }
}
