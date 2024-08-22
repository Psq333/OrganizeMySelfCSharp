using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OrganizeMySelf.Models
{
    public class StorageModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TypeModel Type { get; set; }
        public InsideStorage Inside {  get; set; }
        public decimal Cash { get; set; }

        public override string ToString()
        {
            return $"{Date} - {Inside} - {Cash}€";
        }

        public String OnlyDate
        {
            get => Date.ToString("d");
        }

        public Brush Colore => Inside == InsideStorage.Inside 
            ? Brushes.LightGreen : Brushes.PaleVioletRed;

    }

    //ublic enum TypeModel { Regular, Straordinary, Assurance}
    public enum InsideStorage { Inside, Outside }
}
