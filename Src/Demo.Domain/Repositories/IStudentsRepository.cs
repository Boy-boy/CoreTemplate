using Core.Ddd.Domain.Repositories;
using Demo.Domain.Entities;

namespace Demo.Domain.Repositories
{
    public interface IStudentsRepository :IDomainRepository<Students, string>
    {
    }
}
