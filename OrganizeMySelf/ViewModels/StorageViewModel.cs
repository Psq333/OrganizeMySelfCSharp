using OrganizeMySelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OrganizeMySelf.ViewModels
{
    public class StorageViewModel : BaseViewModel
    {

        protected StorageModel _storageModel = null;

        public StorageViewModel(StorageModel model)
        {
            if(model == null)
                _storageModel = new StorageModel();
            else _storageModel = model;
        }

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
            get => _storageModel.Date;
            set
            {
                _storageModel.Date = value;
                Notify();
            }
        }

        public TypeModel Type
        {
            get => _storageModel.Type;
            set
            {
                _storageModel.Type = value;
                Notify();
            }
        }

        public InsideStorage Inside
        {
            get => _storageModel.Inside;
            set
            {
                _storageModel.Inside = value;
                Notify();
            }
        }

        public decimal Cash
        {
            get => _storageModel.Cash;
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


        public Brush Colore => Inside == InsideStorage.Inside ? Brushes.Green : Brushes.Red;
    }
}
