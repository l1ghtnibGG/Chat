namespace ChatApp.Models.Repo
{
    public interface IChatRepository<T> where T : class
    {
        public IQueryable<T> GetValues { get; }

        public T Add(T item);

        public IQueryable<Tag> GetUserTags(User user);
    }
}
