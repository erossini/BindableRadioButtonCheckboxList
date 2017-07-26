using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Xam.Controls.BindableRadioButton
{
    /// <summary>
    /// Class GenericEventArgs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.EventArgs" />
    public class GenericEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs" /> class.
        /// </summary>
        /// <param name="value">Value of the argument</param>
        public GenericEventArgs(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value of the event argument
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; set; }
    }
}