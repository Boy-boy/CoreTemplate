using Core.Ddd.Domain.Repositories;
using Demo.Domain.Entities;
using Demo.Domain.Repositories;

namespace Demo.Persistence.Repositories
{
    public class StudentsRepository : DomainRepository<Students, string>, IStudentsRepository
    {
        public StudentsRepository(IRepository<Students, string> repository)
            : base(repository)
        {

        }
    }
}
