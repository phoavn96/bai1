using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{

    private Mydbcontext _mydbcontext;
    public Service()
    {
        this._mydbcontext = new Mydbcontext();
    }
    public bool AddStudent(Student newStudent)
    {
        _mydbcontext.Students.Add(newStudent);
        _mydbcontext.SaveChanges();
        return true;
    }

    public bool DeleteStudent(int Id)
    {
        var toDelStd = GetStudentById(Id);
        if (toDelStd == null)
        {
            return false;
        }
        _mydbcontext.Students.Remove(toDelStd);
        _mydbcontext.SaveChanges();
        return true;
    }

    public IEnumerable<Student> GetListStudents()
    {
        var list = from s in _mydbcontext.Students select s;
        return list;
    }

    public Student GetStudentById(int id)
    {
        var student = from s in _mydbcontext.Students where s.Id == id select s;
        return student.FirstOrDefault();
    }

    public bool UpdateStudent(int id, Student updateStudent)
    {
        var existStudent = _mydbcontext.Students.First(student => student.Id == id);
        if (existStudent == null)
        {
            return false;
        }
        //update
        existStudent.StudentId = updateStudent.StudentId;
        existStudent.Introduce = updateStudent.Introduce;
        existStudent.Gender = updateStudent.Gender;
        existStudent.Email = updateStudent.Email;
        existStudent.Name = updateStudent.Name;
        existStudent.Birthday = updateStudent.Birthday;
        _mydbcontext.SaveChanges();
        return true;
    }
}
