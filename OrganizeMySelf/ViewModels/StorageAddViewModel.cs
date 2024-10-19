using OrganizeMySelf.Models;
using OrganizeMySelf.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeMySelf.ViewModels
{
    public class StorageAddViewModel : BaseViewModel
    {

        protected StorageModel _storageModel = null;
        public IList<TypeModel> itemsType; 
        public IList<InsideStorage> itemsInside;

        public StorageAddViewModel(StorageModel model, List<TypeModel> types)
        {
            if (model == null)
                _storageModel = new StorageModel() { Date = DateTime.Now};
            else
                _storageModel = model;
            AggiungiCommand = new RelayCommand(Add);
            ItemsInside = Enum.GetValues(typeof(InsideStorage)).Cast<InsideStorage>().ToList();
            ItemsType = types;
            if(ItemsType != null)
                Type = ItemsType.First();
        }

        public List<TypeModel> ItemsType { get; set; }
        public List<InsideStorage> ItemsInside { get; set; }
        public int Id
        {
            get => _storageModel.Id;
            set
            {
                _storageModel.Id = value;
                Notify();
            }
        }

        public DateTime Date
        {
            get =>  _storageModel.Date;
            set
            {
                _storageModel.Date = value;
                Notify();
            }
        }

        public TypeModel Type
        {
            get =>  _storageModel.Type;
            set
            {
                _storageModel.Type = value;
                Notify();
            }
        }

        public InsideStorage Inside
        {
            get =>  _storageModel.Inside;
            set
            {
                _storageModel.Inside = value;
                Notify();
            }
        }

        public Double Cash
        {
            get =>  _storageModel.Cash;
            set
            {
                _storageModel.Cash = value;
                Notify();
            }
        }

        public String Descrizione
        {
            get => _storageModel.Descrizione;
            set
            {
                _storageModel.Descrizione = value;
                Notify();
            }
        }

        public String OnlyDate
        {
            get => _storageModel.Date.ToString("d");
        }

        public RelayCommand AggiungiCommand { get; private set; }
        public event Action<StorageModel> ElementoAggiunto;

        public void Add(object param)
        {
            StorageModel storage = new StorageModel()
            {
                Id = Id,
                Type = Type,
                Cash = Cash,
                Date = Date,
                Inside = Inside,
                Descrizione = Descrizione,
            };
            int read = HTTPRequest<StorageModel>.RequestPost(PathClass.Path, PathClass.Storage, Method.Post, storage);
            if (read > 0)
            {
                storage.Id = read;
                ElementoAggiunto?.Invoke(storage);
            }
        }
    }
}
