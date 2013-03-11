using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Xpf.Mono.Samples.Android
{
    [Activity(Label = "Xpf.Mono.Samples.Android"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Landscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Game1.Activity = this;
            var g = new Game1();

            //Samples.RedBadger.Xpf.Sandbox.Game1.Activity = this;
            //var g = new Samples.RedBadger.Xpf.Sandbox.Game1();
            
            SetContentView(g.Window);
            g.Run();
        }
    }
}

