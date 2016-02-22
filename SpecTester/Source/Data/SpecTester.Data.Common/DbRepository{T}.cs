namespace SpecTester.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Models;

    // TODO: Why BaseModel<int> instead BaseModel<TKey>?
    public class DbRepository<T> : IDbRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        public DbRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private IDbSet<T> DbSet { get; }

        private DbContext Context { get; }

        public IQueryable<T> All()
        {
            return this.DbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.DbSet;
        }

        public T GetById(object id)
        {
            var item = this.DbSet.Find(id);
            if (item.IsDeleted)
            {
                return null;
            }

            return item;
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
        }

        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        //public void Update(T entity)
        //{
        //    this.ChangeEntityState(entity, EntityState.Modified);
        //}

        //protected void ChangeEntityState(T entity, EntityState state)
        //{
        //    var entry = this.Context.Entry(entity);

        //    if (entry.State == EntityState.Detached)
        //    {
        //        this.DbSet.Attach(entity);
        //    }

        //    entry.State = state;
        //}
    }
}
