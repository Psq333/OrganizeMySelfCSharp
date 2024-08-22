using OrganizeMySelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeMySelf.ViewModels
{
    public class StorageEditViewModel : BaseViewModel
    {

        protected StorageModel _storageModel = null;
        public IList<TypeModel> itemsType; 
        public IList<InsideStorage> itemsInside;

        public StorageEditViewModel(StorageModel model, List<TypeModel> types)
        {
            if (model == null)
                _storageModel = new StorageModel() { Date = DateTime.Now};
            else
                _storageModel = model;
            ModificaCommand = new RelayCommand(Edit);
            ItemsInside = Enum.GetValues(typeof(InsideStorage)).Cast<InsideStorage>().ToList();
            ItemsType = types;
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

        public decimal Cash
        {
            get =>  _storageModel.Cash;
            set
            {
                _storageModel.Cash = value;
                Notify();
            }
        }

        public String OnlyDate
        {
            get => _storageModel.Date.ToString("d");
        }

        public RelayCommand ModificaCommand { get; private set; }
        public event Action<StorageModel> ElementoModificato;

        public void Edit(object param)
        {
            StorageModel storage = new StorageModel()
            {
                Id = Id,
                Type = Type,
                Cash = Cash,
                Date = Date,
                Inside = Inside
            };
            ElementoModificato?.Invoke(storage);
        }
    }
}
