using SMClient.Models;
using SMClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMClient.Helper
{
    public class ConvertTypeHelper
    {
        public static StudentClient ConvertServiceStudentToViewStudent(Student serviceStudent)
        {
            var stdView = new StudentClient
            {
                Id = serviceStudent.Id,
                StudentId = serviceStudent.StudentId,
                Name = serviceStudent.Name,
                Birthday = serviceStudent.Birthday,
                Email = serviceStudent.Email,
                Gender = serviceStudent.Gender,
                Introduce = serviceStudent.Introduce
            };
            return stdView;
        }

        public static Student ConvertViewStudentToServiceStudent(StudentClient studentClient)
        {
            var student = new Student
            {

                StudentId = studentClient.StudentId,
                Birthday = studentClient.Birthday,
                Email = studentClient.Email,
                Gender = studentClient.Gender,
                Introduce = studentClient.Introduce,
                Name = studentClient.Name
            };
            return student;
        }
    }
}