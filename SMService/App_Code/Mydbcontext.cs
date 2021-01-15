using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Mydbcontext
/// </summary>
public class Mydbcontext:DbContext
{
    public Mydbcontext() : base("MydbContext")
    {
        
        //
        // TODO: Add constructor logic here
        //
    }
    public DbSet<Student> Students { get; set; }
}