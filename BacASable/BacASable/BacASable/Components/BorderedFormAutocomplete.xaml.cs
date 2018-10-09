using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BacASable.Components
{
    /// <summary>
    /// Syncfusion Autocomplete + Label
    /// Support :
    /// - Watermark (PlaceHolder)
    /// - DataSource
    /// - SelectedItem
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BorderedFormAutocomplete : ContentView
    {
        public new event EventHandler Unfocused = (e, a) => { };
        public new event EventHandler Focused = (e, a) => { };
        public event EventHandler TextChanged = (e, a) => { };

        public BorderedFormAutocomplete()
        {
            InitializeComponent();

            // initialisation des valeurs par défaut des propriétés liables
            Init();
        }

        private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection changed");
        }

        /// <summary>
        /// initialisation des valeurs par défaut des propriétés liables
        /// </summary>
        private void Init()
        {
            // par défaut, on a un clavier text
            RelatedAutoComplete.Keyboard = Xamarin.Forms.Keyboard.Text;
            RelatedAutoComplete.PropertyChanged += OnRelatedAutoCompletePropertyChanged;
        }

        #region SelectedItem
        // Bindable property
        public static readonly BindableProperty SelectedItemProperty =
          BindableProperty.Create(
             propertyName: nameof(SelectedItem),
             returnType: typeof(object),
             declaringType: typeof(BorderedFormAutocomplete),
             defaultValue: default(object),
             defaultBindingMode: BindingMode.TwoWay,
             propertyChanged: (bindable, oldValue, newValue) =>
             {
             });


        // Gets or sets value of this BindableProperty
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        #endregion

        #region ItemsSource
        // Bindable property
        public static readonly BindableProperty ItemsSourceProperty =
          BindableProperty.Create(
             propertyName: nameof(ItemsSource),
             returnType: typeof(IEnumerable<object>),
             declaringType: typeof(BorderedFormAutocomplete),
             defaultValue: null,
             defaultBindingMode: BindingMode.TwoWay,
             propertyChanged: (bindable, oldValue, newValue) =>
             {
             });


        // Gets or sets value of this BindableProperty
        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        #endregion

        #region DisplayMemberPath
        // Bindable property
        public static readonly BindableProperty DisplayMemberPathProperty =
          BindableProperty.Create(
             propertyName: nameof(DisplayMemberPath),
             declaringType: typeof(BorderedFormAutocomplete),
             returnType: typeof(string),
             defaultValue: string.Empty,
             defaultBindingMode: BindingMode.TwoWay,
             propertyChanged: (bindable, oldValue, newValue) =>
             {
             });


        // Gets or sets value of this BindableProperty
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }
        #endregion

        #region Caption Text Bindable
        public static readonly BindableProperty CaptionProperty =
                        BindableProperty.Create(
                            nameof(Caption),
                            typeof(string),
                            typeof(BorderedFormAutocomplete),
                            string.Empty,
                            defaultBindingMode: BindingMode.TwoWay,
                            propertyChanged: (bindable, oldValue, newValue) =>
                            {
                            });

        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }
        #endregion            

        #region Text Bindable
        public static readonly BindableProperty TextProperty =
    BindableProperty.Create(nameof(Text),
        typeof(string),
        typeof(BorderedFormAutocomplete),
        string.Empty,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
        });

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        #endregion

        #region TextColor Bindable

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor),
                typeof(Color),
                typeof(BorderedFormAutocomplete),
                Color.Black,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                });

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);

        }

        #endregion

        #region WatermarkColor Bindable

        public static readonly BindableProperty WatermarkColorProperty =
            BindableProperty.Create(nameof(WatermarkColor),
                typeof(Color),
                typeof(BorderedFormAutocomplete),
                Color.Black,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                });

        public Color WatermarkColor
        {
            get => (Color)GetValue(WatermarkColorProperty);
            set => SetValue(WatermarkColorProperty, value);

        }
        #endregion

        #region Watermark
        public static readonly BindableProperty WatermarkProperty =
            BindableProperty.Create(nameof(Watermark),
                typeof(string),
                typeof(BorderedFormAutocomplete),
                string.Empty,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                });

        public string Watermark
        {
            get => (string)GetValue(WatermarkProperty);
            set => SetValue(WatermarkProperty, value);
        }

        #endregion

        #region Keyboard
        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(String), typeof(BorderedFormAutocomplete),
                "Text",
                defaultBindingMode: BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = bindable as BorderedFormAutocomplete;
            if (view == null)
            {
                return;
            }
            switch (newValue.ToString().ToUpper())
            {
                case "TEXT":
                    view.RelatedAutoComplete.Keyboard = Xamarin.Forms.Keyboard.Text;
                    break;
                case "NUMERIC":
                    view.RelatedAutoComplete.Keyboard = Xamarin.Forms.Keyboard.Numeric;
                    break;
                case "CHAT":
                    view.RelatedAutoComplete.Keyboard = Xamarin.Forms.Keyboard.Chat;
                    break;
                case "PLAIN":
                    view.RelatedAutoComplete.Keyboard = Xamarin.Forms.Keyboard.Plain;
                    break;
                case "TELEPHONE":
                case "PHONE":
                    view.RelatedAutoComplete.Keyboard = Xamarin.Forms.Keyboard.Telephone;
                    break;
                case "URL":
                    view.RelatedAutoComplete.Keyboard = Xamarin.Forms.Keyboard.Url;
                    break;
                case "MAIL":
                case "EMAIL":
                    view.RelatedAutoComplete.Keyboard = Xamarin.Forms.Keyboard.Email;
                    break;
                default:
                    view.RelatedAutoComplete.Keyboard = Xamarin.Forms.Keyboard.Text;
                    break;
            }
        });

        public String Keyboard
        {
            get => (String)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }


        #endregion

        #region IsFocused
        public static readonly new BindableProperty IsFocusedProperty =
            BindableProperty.Create(nameof(IsFocused), typeof(bool), typeof(BorderedFormAutocomplete), false);

        public new bool IsFocused
        {
            get => RelatedAutoComplete.IsFocused || RelatedLabel.IsFocused;
        }

        #endregion

        #region Focus
        /// <summary>
        /// répercution du focus sur l'entry
        /// </summary>
        public new void Focus()
        {
            RelatedAutoComplete.Focus();
        }


        private void RelatedAutoComplete_Unfocused(object sender, FocusEventArgs e)
        {
            // envoi du unfocus sur le contrôle parent
            Unfocused?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// demande d'apparition du clavier
        /// le subscribe n'est fait qu'en android. En iOS, le clavier apparait dès le premier tap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RelatedAutoComplete_Focused(object sender, FocusEventArgs e)
        {
            // envoi du focus sur le contrôle parent
            Focused?.Invoke(this, EventArgs.Empty);
            try
            {
                Device.BeginInvokeOnMainThread(() => MessagingCenter.Send("", "AfficheClavier"));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

        }
        #endregion

        #region PropertyChanged
        void OnRelatedAutoCompletePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TextProperty.PropertyName)
            {
                Text = ((Syncfusion.SfAutoComplete.XForms.SfAutoComplete)sender).Text;
            }

            if (e.PropertyName == BorderedFormAutocomplete.ItemsSourceProperty.PropertyName)
            {
                Debugger.Break();
            }
        }
        #endregion


        #region Events
        private void RelatedAutoComplete_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged?.Invoke(sender, e);
        }



        /// <summary>
        /// Quand on tape sur le label, cela donne le focus à l'entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Focus();
        }
        #endregion
    }
}
