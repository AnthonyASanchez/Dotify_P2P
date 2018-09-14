using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using Dotify;
using Dotify.iOS;

[assembly: ExportRenderer(typeof(CustomPickerView), typeof(CustomPickerRenderer))]
namespace Dotify.iOS
{
    class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextColor = UIColor.LightGray;
            }
        }
    }
}