using OrganizeMySelf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace OrganizeMySelf.ViewModels
{
    public class AnalizzaDatiViewModel : BaseViewModel
    {
        public IList<TypeModel> Types { get; set; }
        public List<StorageModel> AllItems { get; set; }
        public ObservableCollection<StorageModel> Items { get; set; }
        public String Totale { get; set; }
        private TypeModel _selectedType; 
        public Double Positive { get; set; }
        public Double Negative { get; set; }

        public AnalizzaDatiViewModel(List<StorageModel> Items, List<TypeModel> types)
        {
            Types = types;

            this.Items = new ObservableCollection<StorageModel>(Items);
            this.AllItems = Items;
            Totale = TotaleSommato();
            SelectedType = Types.FirstOrDefault();
        }

        public String TotaleSommato()
        {
            Positive = (from it in Items where it.Inside == InsideStorage.Inside select it.Cash).Sum();
            Negative = (from it in Items where it.Inside == InsideStorage.Outside select it.Cash).Sum();
            Double total = Positive - Negative;
            return "Totale " + total.ToString() + "€";
        }

        public TypeModel SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;FilteredItems(_selectedType);
                Notify();
            }
        }

        private void FilteredItems(TypeModel type)
        {
            IEnumerable<StorageModel> items = AllItems.Where(it => it.Type == type);
            Items.Clear();
            foreach (StorageModel item in items) Items.Add(item);
        }
    }
}
