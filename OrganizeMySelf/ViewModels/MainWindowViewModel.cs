using OrganizeMySelf.Models;
using OrganizeMySelf.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OrganizeMySelf.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand AggiungiCommand { get; private set; }
        public RelayCommand ModificaCommand { get; private set; }
        public RelayCommand EliminaCommand { get; private set; }
        public RelayCommand AnalizzaCommand { get; private set; }
        public RelayCommand CategoriaCommand { get; private set; }
        public ObservableCollection<StorageModel> Items { get; private set; }
        public StorageModel selectedItem { get; private set;  } 
        public BaseViewModel StorageVM { private set; get; }
        private List<StorageModel> storage;
        private DateTime startDate;
        private DateTime endDate;
        private List<TypeModel> types;
        public MainWindowViewModel(int v)
        {
            AggiungiCommand = new RelayCommand(AggiungiMethod);
            EliminaCommand = new RelayCommand(EliminaMethod, EliminaCanExec);
            ModificaCommand = new RelayCommand(ModificaMethod, ModificaCanExec);
            AnalizzaCommand = new RelayCommand(AnalizzaMethod);
            CategoriaCommand = new RelayCommand(CategoriaMethod);

            types = HTTPRequest<TypeModel>.Request(PathClass.Path, PathClass.Type, Method.Get, null);

            storage = HTTPRequest<StorageModel>.Request(PathClass.Path, PathClass.Storage, Method.Get, null);

            Items = new ObservableCollection<StorageModel>();
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            EndDate = DateTime.Now;
            FilteredItem();
            Items.CollectionChanged += Item_CollectionChanged;

        }

        public List<StorageModel> Storage {  get; private set; }

        public StorageModel SelectedItem
        {
            get => selectedItem;
            set
            {
                if (selectedItem == value) return;
                selectedItem = value;
                Notify();
                StorageVM = new StorageViewModel(selectedItem);
                Notify(nameof(StorageVM));
                EliminaCommand.RaiseCanExecuteChanged();
                ModificaCommand.RaiseCanExecuteChanged();
            }
        }
        private void Item_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null) SelectedItem = (StorageModel)e.NewItems[e.NewItems.Count - 1];
        }

        private void AggiungiMethod(object param)
        {
            Notify();
            var storageAddViewModel = new StorageAddViewModel(null,types);
            storageAddViewModel.ElementoAggiunto += OnElementoAggiunto;
            StorageVM = storageAddViewModel;
            Notify(nameof(StorageVM));
        }

        private void EliminaMethod(object param)
        {
            Items.Remove(selectedItem);
        }

        private bool EliminaCanExec(object param)
        {
            return selectedItem != null;
        }

        private void ModificaMethod(object param)
        {
            Notify();
            var storageEditViewModel = new StorageEditViewModel(selectedItem, types);
            storageEditViewModel.ElementoModificato += OnElementoModificato;
            StorageVM = storageEditViewModel;
            Notify(nameof(StorageVM));
        }

        private bool ModificaCanExec(object param)
        {
            return selectedItem != null;
        }

        private void OnElementoAggiunto(StorageModel model)
        {
            Items.Add(model);
            storage.Add(model);
            Notify();
        }
        private void OnElementoModificato(StorageModel model)
        {
            FilteredItem();
        }

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    Notify(nameof(startDate));
                    FilteredItem();
                }
            }
        }


        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    Notify(nameof(endDate));
                    FilteredItem();
                }
            }
        }


        private void FilteredItem()
        {
            Items.Clear();
            ObservableCollection<StorageModel> tmp = new ObservableCollection<StorageModel>(storage);
            IEnumerable<StorageModel> ienum = from item in tmp
                                              where item.Date >= StartDate && item.Date <= EndDate
                                              select item;
            foreach (StorageModel item in ienum) Items.Add(item);
        }

        private void AnalizzaMethod(object param)
        {
            StorageVM = new AnalizzaDatiViewModel(storage, types);
            Notify(nameof(StorageVM));
        }
        private void CategoriaMethod(object param)
        {
            StorageVM = new CategoriaViewModel(types);
            Notify(nameof(StorageVM));
        }
    }
}
