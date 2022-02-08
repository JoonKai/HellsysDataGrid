using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsysFilterDataGrid
{
    public class FilterItem : NotifyProperty
    {
        #region Public Events

        private event EventHandler<bool?> OnDateStatusChanged;

        #endregion Public Events

        #region Constructor

        public FilterItem(FilterCommon action = null)
        {
            // event subscription
            if (action != null)
                OnDateStatusChanged += action.UpdateTree;
        }

        #endregion Constructor

        #region Private Fields

        private bool? isChecked;
        private bool initialized;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        ///Children higher levels (years, months)
        /// </summary>
        public List<FilterItem> Children { get; set; }

        /// <summary>
        /// Raw value of the item (not displayed, see Label property)
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// Content length
        /// </summary>
        public int ContentLength { get; set; }


        /// <summary>
        /// Current filter
        /// </summary>
        public FilterCommon CurrentFilter { get; set; }

        /// <summary>
        /// Field type
        /// </summary>
        public Type FieldType { get; set; }

        /// <summary>
        /// Initial state
        /// </summary>
        public bool? InitialState { get; set; }

        public int Id { get; set; }

        /// <summary>
        /// State of checkbox
        /// </summary>
        public bool? IsChecked
        {
            get => isChecked;
            set
            {
                if (!initialized)
                {
                    InitialState = value;
                    initialized = true;
                    isChecked = value; // don't remove

                    // the iteration over an Collection triggers the notification
                    // of the "IsChecked" property and slows the performance of the loop,
                    // the return prevents the OnPropertyChanged
                    // notification at initialization
                    return;
                }

                // raise event to update the date tree, see FilterCommon class
                // only type date type fields are subscribed to the OnDateStatusChanged event
                // OnDateStatusChanged is not triggered at tree initialization
                if (FieldType == typeof(DateTime))
                {
                    OnDateStatusChanged?.Invoke(this, value);
                }
                else
                {
                    isChecked = value;
                    OnPropertyChanged("IsChecked");
                }
            }
        }

        /// <summary>
        /// Content displayed
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Hierarchical level for the date
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Parent of lower levels (days, months)
        /// </summary>
        public FilterItem Parent { get; set; }

        /// <summary>
        /// Set the state of the IsChecked property for date, does not invoke the update of the tree
        /// </summary>
        public bool? SetState
        {
            get => isChecked;
            set
            {
                isChecked = value;

                if (!initialized)
                {
                    InitialState = value;
                    initialized = true;
                }
                else
                {
                    OnPropertyChanged("IsChecked");
                }
            }
        }

        /// <summary>
        /// Checks if the initial state has changed
        /// </summary>
        public bool Changed => isChecked != InitialState;

        #endregion Public Properties
    }
}
