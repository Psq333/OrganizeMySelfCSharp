using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeMySelf.Models
{
    public class TypeModel
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public TypeModel(int id, string type)
        {
            Id = id;
            Type = type;
        } 
        
        public TypeModel() { }
    }
}
