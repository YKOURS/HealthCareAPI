using Authentication.Data;

namespace Authentication.Repo
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly HealthCareContext _dbContext;
        private bool disposedValue;

        public UnitOfWork(HealthCareContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region DisposeContext
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region DbGetAll
        IEnumerable<T> IUnitOfWork.GetAll<T>()
        {
            var res = _dbContext.Set<T>();

            return res;
        }
        #endregion

        #region DbGet
        public T? Get<T>(long Id) where T : class
        {
            var res = _dbContext.Set<T>().Find(Id);

            return res;
        }
        #endregion

        #region DbAdd
        public bool Add<T>(T Req) where T : class
        {
            var insert = _dbContext.Set<T>().Add(Req);

            var res = _dbContext.SaveChanges() > 0;

            return res;
        }
        #endregion

        #region DbAddRange
        public bool AddRange<T>(List<T> Req) where T : class
        {
            _dbContext.Set<T>().AddRange(Req);

            var res = _dbContext.SaveChanges() > 0;

            return res;
        }
        #endregion

        #region DbUpdate
        public bool Update<T>(T Req) where T : class
        {
            var update = _dbContext.Set<T>().Update(Req);

            var res = _dbContext.SaveChanges() > 0;

            return res;
        }
        #endregion

        #region DbUpdateRange
        public bool UpdateRange<T>(List<T> Req) where T : class
        {
            _dbContext.Set<T>().UpdateRange(Req);

            var res = _dbContext.SaveChanges() > 0;

            return res;
        }
        #endregion

        #region DbDeleteRow
        public bool Delete<T>(long Id) where T : class
        {
            var record = _dbContext.Set<T>().Find(Id);

            if (record != null)
            {
                var delete = _dbContext.Set<T>().Remove(record);

                var res = _dbContext.SaveChanges() > 0;

                return res;
            }
            return false;
        }
        #endregion

        #region DbDeleteRows
        public bool DeleteRange<T>(List<T> Ids) where T : class
        {
            var records = _dbContext.Set<T>().Where(k => Ids.Contains(k)).ToList();

            if (!records.Any())
            {
                _dbContext.Set<T>().RemoveRange(records);

                var res = _dbContext.SaveChanges() > 0;

                return res;
            }

            return false;
        }
        #endregion
    }
}