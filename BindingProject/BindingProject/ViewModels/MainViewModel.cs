using BindingProject.Models;
using PSC.Xam.Controls.BindableCheckboxList;
using PSC.Xamarin.MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingProject.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public List<Data> Datas { get; set; }

        public MainViewModel() {
            myList = new Dictionary<int, string>();
            myList2 = new Dictionary<int, string>();
            selectedIndex = -1;
            LoadData();
        }

        private void LoadData()
        {
            for (int i = 0; i < 5; i++)
            {
                MyList.Add(i, "Item " + i);
                MyList2.Add(i, "Item " + i);
            }
        }

        private Dictionary<int, string> myList;
        public Dictionary<int, string> MyList
        {
            get { return myList; }
            set {
                myList = value;
                OnPropertyChanged("MyList");
            }
        }

        private Dictionary<int, string> myList2;
        public Dictionary<int, string> MyList2
        {
            get { return myList2; }
            set {
                myList2 = value;
                OnPropertyChanged("MyList2");
            }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set {
                if (value == selectedIndex) return;
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        public List<CheckboxSelected> SelectedItems
        {
            get {
                return _selectedItems;
            }
            set {
                _selectedItems = value;
                SelectedItemsText = MakeText();
                OnPropertyChanged("SelectedItems");
                OnPropertyChanged("SelectedItemsText");
            }
        }
        private List<CheckboxSelected> _selectedItems = new List<CheckboxSelected>();

        public string SelectedItemsText
        {
            get {
                return _selectedItemsText;
            }
            set {
                if (_selectedItemsText != value)
                {
                    _selectedItemsText = value;
                    OnPropertyChanged("SelectedItemsText");
                }
            }
        }
        private string _selectedItemsText = "";

        private string MakeText()
        {
            string rtn = "";

            if (_selectedItems.Count > 0)
                foreach (CheckboxSelected chk in _selectedItems)
                    rtn += $"{chk.Id}-{chk.Text};";

            return rtn;
        }
    }
}