namespace ChatApp.Models.Repo
{
    public class EfTagRepository : IChatRepository<Tag>
    {
        private readonly ChatDbContext _context;
        public EfTagRepository(ChatDbContext context)
        {
            _context = context;
        }

        IQueryable<Tag> IChatRepository<Tag>.GetValues => _context.Tags;

        public Tag Add(Tag item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tag> GetUserTags(User user)
        {
            throw new NotImplementedException();
        }
    }
}
