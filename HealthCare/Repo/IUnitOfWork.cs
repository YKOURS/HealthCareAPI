namespace HealthCare.Repo
{
    public interface IUnitOfWork
    {
        IEnumerable<T> GetAll<T>() where T : class;

        T? Get<T>(long Id) where T : class;

        bool Add<T>(T Req) where T : class;

        bool AddRange<T>(List<T> Req) where T : class;

        bool Update<T>(T Req) where T : class;

        bool UpdateRange<T>(List<T> Req) where T : class;

        bool Delete<T>(long Id) where T : class;

        bool DeleteRange<T>(List<T> Ids) where T : class;

    }
}
