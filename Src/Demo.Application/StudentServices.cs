﻿using Core.Uow;
using Demo.Domain.Entities;
using Demo.Domain.Repositories;
using Demo.Dtos.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Application
{
    public class StudentServices
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentServices(IStudentsRepository studentsRepository,
            IUnitOfWork unitOfWork)
        {
            _studentsRepository = studentsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StudentDto>> GetStudents()
        {
            var students = await _studentsRepository.FindAllAsync(p => true);
            var result = students.Select(p => new StudentDto
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age
            }).ToList();
            return result;
        }

        public async Task SetStudents(List<StudentDto> models)
        {
            // ....
            foreach (var model in models)
            {
                _studentsRepository.Add(new Students(model.Name, model.Age));
            }

            await _unitOfWork.CommitAsync();
        }
    }
}