using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
[assembly: ExportRenderer(typeof(Button), typeof(XamarinHelloWorld.Droid.FlatButtonRenderer))]
namespace XamarinHelloWorld.Droid
{
    public class FlatButtonRenderer : ButtonRenderer
    {
        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            base.OnDraw(canvas);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            this.Control.SetAllCaps(false);
        }
    }
}