using StudentsAPI.Core.Entities;
using System.Collections.Generic;

namespace StudentsAPI.V2.Services.Interfaces
{
    public interface IStudentsGenerator
    {
        IEnumerable<Student> GenerateStudents(int studentsNumber);
    }
}