using System.Collections.Generic;

namespace Demo.Dtos.Dtos
{
    public class StudentDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class CreateStudentRequest
    {
        public List<StudentDto> StudentDtos { get; set; }
    }
}
