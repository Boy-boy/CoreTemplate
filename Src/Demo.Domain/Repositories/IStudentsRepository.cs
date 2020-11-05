using Core.Ddd.Domain.Repositories;
using Demo.Domain.Entities;
using System;

namespace Demo.Domain.Repositories
{
    public interface IStudentsRepository :IDomainRepository<Students, string>
    {
    }
}
