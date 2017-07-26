using PSC.Xam.Controls.BindableRadioButton;
using PSC.Xam.Controls.UWP;
using PSC.Xam.Controls.UWP.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomRadioButton), typeof(RadioButtonRenderer))]
namespace PSC.Xam.Controls.UWP
{
    using NativeCheckBox = RadioButton;

    public class RadioButtonRenderer : ViewRenderer<CustomRadioButton, NativeCheckBox>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadioButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.CheckedChanged -= CheckedChanged;
            }

            if (this.Control == null)
            {
                var checkBox = new NativeCheckBox();
                checkBox.Checked += (s, args) => this.Element.Checked = true;
                checkBox.Unchecked += (s, args) => this.Element.Checked = false;

                this.SetNativeControl(checkBox);
            }

            this.Control.Content = e.NewElement.Text;
            this.Control.IsChecked = e.NewElement.Checked;

            this.Element.CheckedChanged += CheckedChanged;
            this.Element.PropertyChanged += ElementOnPropertyChanged;
        }

        private void ElementOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "Checked":
                    this.Control.IsChecked = this.Element.Checked;
                    break;
                case "TextColor":
                    this.Control.Foreground = new SolidColorBrush(this.Element.TextColor.ConvertColorType());
                    break;
                case "Text":
                    this.Control.Content = Element.Text;
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("Property change for {0} has not been implemented.", propertyChangedEventArgs.PropertyName);
                    break;
            }
        }

        private void CheckedChanged(object sender, GenericEventArgs<bool> eventArgs)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                this.Control.Content = this.Element.Text;
                this.Control.IsChecked = eventArgs.Value;
            });
        }
    }
}