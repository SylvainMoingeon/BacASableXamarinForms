using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Android.Content;
using Android.Graphics;
using Android.Text.Style;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Android.Text;
using Android.Views.InputMethods;
using BacASable.Components;
using BacASable.Droid.Components;

[assembly: ExportRenderer(typeof(NoBorderNoStyleEntry), typeof(NoBorderNoStyleEntryRenderer))]
namespace BacASable.Droid.Components
{
	public class NoBorderNoStyleEntryRenderer : EntryRenderer
	{

		public NoBorderNoStyleEntryRenderer(Context context) : base(context)
		{
            // message pour demande d'apparition du clavier
            MessagingCenter.Subscribe<String>(this, "AfficheClavier", (x) =>
            {
                ShowKeyboard();
            });
		}


		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			RenderControl();
		}

		private bool _inititialized = false;

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			RenderControl();

			
		}


		void RenderControl()  {

			var entry = (NoBorderNoStyleEntry)Element;
			if (entry == null) return;

			var phFontFamily = entry.PlaceHolderFontFamily;

			Typeface font = Typeface.CreateFromAsset(Context.Assets, entry.PlaceHolderFontFamily);
			TypefaceSpan typefaceSpan = new CustomTypeFaceSpan(font);
			SpannableString spannableString = new SpannableString(entry.Placeholder);

			SpannableStringBuilder builder = new SpannableStringBuilder(entry.Placeholder);
			builder.SetSpan(typefaceSpan, 0, spannableString.Length(), SpanTypes.InclusiveExclusive);
			Control.SetHintTextColor(entry.PlaceholderColor.ToAndroid());
			Control.HintFormatted = builder;
			Control.Background = null;
			entry.IsEnabled = !entry.IsReadonly;
		}

        /// <summary>
        /// forçage de l'apparition du clavier
        /// utilisé lors du focus sur une entry où il fallait cliquer 2 fois pour faire apparaitre le clavier
        /// </summary>
	    public void ShowKeyboard()
	    {
            try
            {
                if (this.Control?.Context == null)
                {
                    return;
                }
                InputMethodManager inputMethodManager = this.Control.Context.GetSystemService(Android.Content.Context.InputMethodService) as InputMethodManager;
                inputMethodManager.ShowSoftInput(this.Control, ShowFlags.Forced);
                inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
            }
            catch (Exception ex)
            {
                //Debugger.Break();
            }
	    }

		class CustomTypeFaceSpan : TypefaceSpan
		{
			Typeface _font;


			public CustomTypeFaceSpan(Typeface typeface) : base(string.Empty) {
				_font = typeface;
			}

			public CustomTypeFaceSpan(string family) : base(family)
			{
			}

			public override void UpdateDrawState(TextPaint ds)
			{
				base.UpdateDrawState(ds);
				ApplyCustomTypeFace(ds, _font);
			}

			public override void UpdateMeasureState(TextPaint paint)
			{
				base.UpdateMeasureState(paint);
				ApplyCustomTypeFace(paint, _font);
			}

			private void ApplyCustomTypeFace(Paint paint, Typeface tf) {
				TypefaceStyle oldStyle;
				Typeface old = paint.Typeface;
				if(old == null) {
					oldStyle = 0;
				} else {
					oldStyle = old.Style;
				}

				paint.Flags |= PaintFlags.UnderlineText;

				paint.SetTypeface(tf);
			}
		}
	}
}
