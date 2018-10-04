using System;
using System.Collections.Generic;
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
    /// Entry arrondi + Label
    /// Support :
    /// - Placeholder
    /// - Text
    /// - Keyboard (Text, Numeric, Chat, Plain, Telephone, Phone, Url, Mail, Email)
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BorderedFormLabelEntry : ContentView
    {
        public event EventHandler Unfocused = (e, a) => { };
        public event EventHandler Focused = (e, a) => { };
        public event EventHandler TextChanged = (e, a) => { };

        public BorderedFormLabelEntry()
        {
            InitializeComponent();
            // initialisation des valeurs par défaut des propriétés liables
            Init();
        }

        /// <summary>
        /// initialisation des valeurs par défaut des propriétés liables
        /// </summary>
        private void Init()
        {
            RelatedEntry.Placeholder = Placeholder;
            RelatedEntry.Text = Text;

            // par défaut, on a un clavier text
            RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Text;
            RelatedEntry.PropertyChanged += OnRelatedEntryPropertyChanged;
            RelatedEntry.IsPassword = IsPassword;


            RelatedEntry.ReturnCommand = new Command(() => { ReturnCommand.Execute(ReturnCommandParameter); });

            RelatedEntry.IsReadonly = IsReadonly;
            //try
            //{
            //    PlaceholderColor = (Color)Application.Current.Resources["AlmostBlackColor"];
            //}
            //catch (Exception)
            //{
            //    PlaceholderColor = Color.DimGray;
            //}
        }

        #region Label Text Bindable
        public static readonly BindableProperty CaptionProperty =
                        BindableProperty.Create(nameof(Caption),
                            typeof(string),
                            typeof(BorderedFormLabelEntry),
                            string.Empty,
                            defaultBindingMode: BindingMode.TwoWay,
                            propertyChanged: (bindable, oldValue, newValue) =>
                            {
                                var view = bindable as BorderedFormLabelEntry;
                                view.RelatedLabel.Text = newValue as string;
                            });

        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }
        #endregion

        void OnRelatedEntryPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == NoBorderNoStyleEntry.TextProperty.PropertyName)
            {
                Text = ((NoBorderNoStyleEntry)sender).Text;
            }
        }

        #region ReadOnly bindable property
        public static readonly BindableProperty IsReadonlyProperty =
   BindableProperty.Create(nameof(IsReadonly), typeof(bool), typeof(BorderedFormLabelEntry), false,
                          propertyChanged: (bindable, oldValue, newValue) =>
                          {
                              var view = bindable as BorderedFormLabelEntry;
                              view.RelatedEntry.IsReadonly = (bool)newValue;
                          });

        public bool IsReadonly
        {
            get => (bool)GetValue(IsReadonlyProperty);
            set => SetValue(IsReadonlyProperty, value);
        } 
        #endregion

        #region Text Bindable
        public static readonly BindableProperty TextProperty =
    BindableProperty.Create(nameof(Text),
        typeof(string),
        typeof(BorderedFormLabelEntry),
        string.Empty,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = bindable as BorderedFormLabelEntry;
            view.RelatedEntry.Text = newValue as string;
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
                typeof(BorderedFormLabelEntry),
                Color.Black,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var view = bindable as BorderedFormLabelEntry;
                    if (newValue is Color)
                    {
                        view.RelatedEntry.TextColor = (Color)newValue;
                    }
                });

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);

        }

        #endregion

        #region PlaceholderColor Bindable

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor),
                typeof(Color),
                typeof(BorderedFormLabelEntry),
                Color.Black,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var view = bindable as BorderedFormLabelEntry;
                    if (newValue is Color)
                    {
                        view.RelatedEntry.PlaceholderColor = (Color)newValue;
                    }
                });

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);

        }

        #endregion

        #region IsPassword
        public static readonly BindableProperty IsPasswordProperty =
   BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(BorderedFormLabelEntry), false,
                          propertyChanged: (bindable, oldValue, newValue) =>
                          {
                              var view = bindable as BorderedFormLabelEntry;
                              view.RelatedEntry.IsPassword = (bool)newValue;

                              // Sous Android, le clavier d'un champs mot de passe est en CapitalizeSentence par défaut !
                              view.RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Create(KeyboardFlags.CapitalizeNone);
                          });

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        #endregion

        #region ReturnType
        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(BorderedFormLabelEntry), ReturnType.Default,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var view = bindable as BorderedFormLabelEntry;
                    view.RelatedEntry.ReturnType = (ReturnType)newValue;
                });

        public ReturnType ReturnType
        {
            get => (ReturnType)GetValue(ReturnTypeProperty);
            set => SetValue(ReturnTypeProperty, value);
        }

        #endregion

        //#region IsEnabled
        //public static readonly BindableProperty IsEnabledProperty =
        //    BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(BorderedFormLabelEntry), false,
        //        propertyChanged: (bindable, oldValue, newValue) =>
        //        {
        //            var view = bindable as BorderedFormLabelEntry;
        //            view.RelatedEntry.IsEnabled = (bool)newValue;
        //        });

        //public bool IsEnabled
        //{
        //    get => (bool)GetValue(IsEnabledProperty);
        //    set => SetValue(IsEnabledProperty, value);
        //}

        //#endregion

        #region Placeholder
        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(BorderedFormLabelEntry), string.Empty,
                                   propertyChanged: (bindable, oldValue, newValue) =>
                                   {
                                       var view = bindable as BorderedFormLabelEntry;
                                       view.RelatedEntry.Placeholder = newValue as string;
                                   });

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        #endregion

        #region Horizontal alignment
        public static readonly BindableProperty HorizontalTextAlignmentProperty =
        BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(BorderedFormLabelEntry), TextAlignment.Start,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = bindable as BorderedFormLabelEntry;
                view.RelatedEntry.HorizontalTextAlignment = (TextAlignment)newValue;
            });

        public TextAlignment HorizontalTextAlignment
        {
            get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
            set => SetValue(HorizontalTextAlignmentProperty, value);
        }
        #endregion

        #region Keyboard
        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(String), typeof(BorderedFormLabelEntry),
                "Text",
                defaultBindingMode: BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = bindable as BorderedFormLabelEntry;
            if (view == null)
            {
                return;
            }
            switch (newValue.ToString().ToUpper())
            {
                case "TEXT":
                    view.RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Text;
                    break;
                case "NUMERIC":
                    view.RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Numeric;
                    break;
                case "CHAT":
                    view.RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Chat;
                    break;
                case "PLAIN":
                    view.RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Plain;
                    break;
                case "TELEPHONE":
                case "PHONE":
                    view.RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Telephone;
                    break;
                case "URL":
                    view.RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Url;
                    break;
                case "MAIL":
                case "EMAIL":
                    view.RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Email;
                    break;
                default:
                    view.RelatedEntry.Keyboard = Xamarin.Forms.Keyboard.Text;
                    break;
            }
        });

        public String Keyboard
        {
            get => (String)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }


        #endregion

        #region ReturnCommand

        public static readonly BindableProperty ReturnCommandProperty =
            BindableProperty.Create(nameof(ReturnCommand), typeof(Command), typeof(BorderedFormLabelEntry), new Command(() => { }),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var view = bindable as BorderedFormLabelEntry;
                    //view.ReturnCommand = (Command) newValue;
                });

        public Command ReturnCommand
        {
            get { return (Command)GetValue(ReturnCommandProperty); }
            set { SetValue(ReturnCommandProperty, value); }
        }
        #endregion

        #region ReturnCommandParameter

        public static readonly BindableProperty ReturnCommandParameterProperty =
            BindableProperty.Create(nameof(ReturnCommandParameter), typeof(Object), typeof(BorderedFormLabelEntry), null
                );

        public Object ReturnCommandParameter
        {
            get { return (Object)GetValue(ReturnCommandParameterProperty); }
            set { SetValue(ReturnCommandParameterProperty, value); }
        }
        #endregion

        #region IsFocused
        public static readonly BindableProperty IsFocusedProperty =
            BindableProperty.Create(nameof(IsFocused), typeof(bool), typeof(BorderedFormLabelEntry), false);

        public bool IsFocused
        {
            get => RelatedEntry.IsFocused || RelatedLabel.IsFocused;
        }

        #endregion

        /// <summary>
        /// répercution du focus sur l'entry
        /// </summary>
        public void Focus()
        {
            RelatedEntry.Focus();
        }


        private void RelatedEntry_Unfocused(object sender, FocusEventArgs e)
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
        private async void RelatedEntry_Focused(object sender, FocusEventArgs e)
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

        private void RelatedEntry_TextChanged(object sender, TextChangedEventArgs e)
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
    }
}
