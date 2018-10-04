using System;
using System.ComponentModel;
using BacASable.Components;
using BacASable.iOS.Components;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NoBorderNoStyleEntry), typeof(NoBorderNoStyleEntryRenderer))]
namespace BacASable.iOS.Components
{
    public class NoBorderNoStyleEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            RenderControl();
        }

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

            RenderControl();
		}

		private void RenderControl()
        {
            var entry = (NoBorderNoStyleEntry)Element;
            if (entry == null) return;

            var phFontFamily = entry.PlaceHolderFontFamily;

            var attributes = new UIStringAttributes();
            attributes.ForegroundColor = entry.PlaceholderColor.ToUIColor();
            attributes.Font = UIFont.FromName(entry.PlaceHolderFontFamily, (int)entry.FontSize);
            attributes.UnderlineStyle = NSUnderlineStyle.Single;

            Control.AttributedPlaceholder = new Foundation.NSAttributedString(entry.Placeholder, attributes);
            Control.BorderStyle = UIKit.UITextBorderStyle.None;

            entry.IsEnabled = !entry.IsReadonly;
        }
    }
}
