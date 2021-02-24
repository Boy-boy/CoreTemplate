using System.Collections.Generic;

namespace Demo.Dtos.Dtos
{
    public class AddStudentDto
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    public class StudentDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class CreateStudentRequest
    {
        public List<AddStudentDto> Students { get; set; }
    }
}
