using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobEye.Controls;
using MobEye.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRendererAndroid))]
namespace MobEye.Droid
{
    public class CustomEntryRendererAndroid : EntryRenderer
    {
        public CustomEntryRendererAndroid(Context context) : base(context)
        {
        }

        public CustomEntry ElementV2 => Element as CustomEntry;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateBackground();

            base.OnElementPropertyChanged(sender, e);
        }

        protected override void UpdateBackground()
        {
            if (Control == null) return;

            var gd = new GradientDrawable();
            gd.SetColor(ElementV2.InnerBackgroundColor.ToAndroid());
            gd.SetCornerRadius(Context.ToPixels(ElementV2.CornerRadius));
            gd.SetStroke((int)Context.ToPixels(ElementV2.BorderThickness), ElementV2.BorderColor.ToAndroid());
            Control.SetBackground(gd);

            var padTop = (int)Context.ToPixels(ElementV2.Padding.Top);
            var padBottom = (int)Context.ToPixels(ElementV2.Padding.Bottom);
            var padLeft = (int)Context.ToPixels(ElementV2.Padding.Left);
            var padRight = (int)Context.ToPixels(ElementV2.Padding.Right);

            Control.SetPadding(padLeft, padTop, padRight, padBottom);
        }
    }
}