using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    [OperationContract]
    Boolean AddStudent(Student newStudent);
    [OperationContract]
    Boolean DeleteStudent(int Id);
    [OperationContract]
    IEnumerable<Student> GetListStudents();
    [OperationContract]
    Boolean UpdateStudent(int id, Student updateStudent);
    [OperationContract]
    Student GetStudentById(int id);


    // TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class Student
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string StudentId { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public DateTime Birthday { get; set; }
    [DataMember]
    public int Gender { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public string Introduce { get; set; }
}