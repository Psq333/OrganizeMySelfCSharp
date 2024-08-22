using OrganizeMySelf.Models;
using OrganizeMySelf.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeMySelf.ViewModels
{
    public class CategoriaViewModel : BaseViewModel
    {
        public ObservableCollection<TypeModel> Types { get; set; }
        public RelayCommand AddTypeCommand { get; set; }
        public String NewType { get; set; }
        public CategoriaViewModel(List<TypeModel> types) {
            Types = new ObservableCollection<TypeModel>(types);
            AddTypeCommand = new RelayCommand(AddTypeMethod);
        }

        private void AddTypeMethod(object param)
        {
            TypeModel nuovo = new TypeModel() { Type = NewType }; 
            int read = HTTPRequest<TypeModel>.RequestPost(PathClass.Path, PathClass.Type, Method.Post, nuovo);
            nuovo.Id = read;
            Types.Add(nuovo);
        }
    }
}
