using BindingProject.ViewModels;
using PSC.Xam.Controls.BindableRadioButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindingProject
{
    public partial class MainPage : ContentPage
    {
        MainViewModel vm = null;

        public MainPage()
        {
            InitializeComponent();
            vm = new MainViewModel();
            this.BindingContext = vm;

            this.MyRadioGroup.CheckedChanged += MyRadioGroup_CheckedChanged;
            this.MyCheckGroup.CheckedChanged += MyCheckGroup_CheckedChanged;

            this.MyRadioGroup.SelectedIndex = 3;
            this.MyCheckGroup.Checkboxes[2].Checked = true;
        }

        private void MyCheckGroup_CheckedChanged(object sender, int e)
        {
            vm.SelectedItems = this.MyCheckGroup.SelectedItems;
        }

        void MyRadioGroup_CheckedChanged(object sender, int e)
        {
            var radio = sender as CustomRadioButton;
            if (radio == null || radio.Id == -1) return;
            this.txtSelected.Text = radio.Text;
            vm.SelectedIndex = this.MyRadioGroup.SelectedIndex;
        }
    }
}
