using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Dotify;
using Dotify.Droid;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: ExportRenderer(typeof(CustomPickerView), typeof(CustomPickerRenderer))]
namespace Dotify.Droid
{
    class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetTextColor(global::Android.Graphics.Color.LightGray);
                Control.SetHintTextColor(global::Android.Graphics.Color.LightGray);
            }
        }
    }
}