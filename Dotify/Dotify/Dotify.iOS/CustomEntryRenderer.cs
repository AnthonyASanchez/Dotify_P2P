using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using Dotify;
using Dotify.iOS;
using CoreAnimation;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomEntryView), typeof(CustomEntryRenderer))]
namespace Dotify.iOS
{
    class CustomEntryRenderer : EntryRenderer

    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;

                CALayer line = new CALayer
                {
                    BorderColor = UIColor.FromRGB(174, 174, 174).CGColor,
                    BackgroundColor = UIColor.FromRGB(174, 174, 174).CGColor,
                    Frame = new CGRect(0, Frame.Height / 2, Frame.Width * 2, 1f)
                };

                Control.Layer.AddSublayer(line);
            }
        }
    }
}