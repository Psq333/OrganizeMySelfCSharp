using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeMySelfAPI.Models
{
    public class StorageModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TypeModel Type { get; set; }
        public InsideStorage Inside {  get; set; }
        public Double Cash { get; set; }
        public String Descrizione { get; set; }

        public override string ToString()
        {
            return $"{Date} - {Inside} - {Cash}€";
        }

        public String OnlyDate
        {
            get => Date.ToString("d");
        }

    }

    //ublic enum TypeModel { Regular, Straordinary, Assurance}
    public enum InsideStorage { Inside, Outside }
}
