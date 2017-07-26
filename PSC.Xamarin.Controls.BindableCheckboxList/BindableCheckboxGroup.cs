using PSC.Xam.Controls.BindableCheckboxList.EventsArgs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PSC.Xam.Controls.BindableCheckboxList
{
    /// <summary>
    /// Class BindableCheckboxGroup.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.StackLayout" />
    public class BindableCheckboxGroup : StackLayout
    {
        /// <summary>
        /// The checkboxes
        /// </summary>
        public List<CustomCheckbox> Checkboxes;

        /// <summary>
        /// The checkbox selected
        /// </summary>
        public List<CheckboxSelected> CheckboxSelected = new List<CheckboxSelected>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BindableCheckboxGroup"/> class.
        /// </summary>
        public BindableCheckboxGroup()
        {
            Checkboxes = new List<CustomCheckbox>();
        }

        /// <summary>
        /// The items source property
        /// </summary>
        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindableCheckboxGroup, IEnumerable>(o => o.ItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);

        /// <summary>
        /// The selected index property
        /// </summary>
        public static BindableProperty SelectedIndexProperty =
            BindableProperty.Create<BindableCheckboxGroup, int>(o => o.SelectedIndex, default(int), BindingMode.TwoWay, propertyChanged: OnSelectedIndexChanged);

        /// <summary>
        /// Gets or sets the items source.
        /// </summary>
        /// <value>The items source.</value>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>The index of the selected.</value>
        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        /// <summary>
        /// Gets or sets the selected items.
        /// </summary>
        /// <value>The selected items.</value>
        public List<CheckboxSelected> SelectedItems
        {
            get { return CheckboxSelected.OrderBy(s => s.Id).ToList(); }
            set { CheckboxSelected = value; }
        }

        /// <summary>
        /// Occurs when [checked changed].
        /// </summary>
        public event EventHandler<int> CheckedChanged;

        /// <summary>
        /// Called when [items source changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldvalue">The oldvalue.</param>
        /// <param name="newvalue">The newvalue.</param>
        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var checkButtons = bindable as BindableCheckboxGroup;
            checkButtons.Checkboxes.Clear();
            checkButtons.Children.Clear();

            if (newvalue != null)
            {
                int checkIndex = 0;
                foreach (var item in newvalue)
                {
                    var rad = new CustomCheckbox();
                    rad.DefaultText = item.ToString();
                    rad.Id = checkIndex;

                    rad.CheckedChanged += checkButtons.OnCheckedChanged;

                    checkButtons.Checkboxes.Add(rad);

                    checkButtons.Children.Add(rad);
                    checkIndex++;
                }
            }
        }

        /// <summary>
        /// Called when [checked changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnCheckedChanged(object sender, GenericEventArgs<bool> e)
        {
            var selectedRad = sender as CustomCheckbox;
            List<CheckboxSelected> toRemove = CheckboxSelected.Where(s => s.Id == selectedRad.Id).ToList();
            if (toRemove.Count() > 0)
            {
                foreach (CheckboxSelected chk in toRemove)
                    CheckboxSelected.Remove(chk);
            }

            if (selectedRad.Checked)
            {
                CheckboxSelected.Add(new CheckboxSelected() { Id = selectedRad.Id, Text = selectedRad.Text });
            }

            CheckboxSelected = CheckboxSelected.OrderBy(s => s.Id).ToList();
            CheckedChanged.Invoke(sender, selectedRad.Id);
        }

        /// <summary>
        /// Called when a selected index changed.
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldvalue">The oldvalue.</param>
        /// <param name="newvalue">The newvalue.</param>
        private static void OnSelectedIndexChanged(BindableObject bindable, int oldvalue, int newvalue)
        {
            if (newvalue == -1) return;
        }
    }
}