using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMClient.Models
{
    public class StudentClient
    {
        
        public int Id { get; set; }
        
        public string StudentId { get; set; }
        
        public string Name { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public int Gender { get; set; } //1.nam 0.nu
        
        public string Email { get; set; }
        
        public string Introduce { get; set; }
    }
}