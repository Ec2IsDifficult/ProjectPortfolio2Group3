namespace DataServices.UnitOfWork
{
    using Dataservices;
    using DataServices;
    using Dataservices.IRepositories;
    using Dataservices.Repository;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImdbContext _ctx;
        public UnitOfWork(ImdbContext context)
        {
            _ctx = context;
            Persons = new PersonRepository(_ctx);
        }
        public IPersonRepository Persons { get; private set; }

        public void Dispose()
        {
            _ctx.Dispose();
        }
        public int Complete()
        {
            return _ctx.SaveChanges();
        }
    }
}