using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Testing
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Name> names;

        public MainWindowVM()
        {
            names = new ObservableCollection<Name>();
            names.Add(new Name("Jaanugopan"));
            
            names.Add(new Name("Jaanu"));
        }
        
        public string textboxtext { get; set; }

        [RelayCommand]

        public void TextBoxTextAdd()
        {
            names = new ObservableCollection<Name>();
            names.Add(new Name(textboxtext));
        
        }



    }

}
