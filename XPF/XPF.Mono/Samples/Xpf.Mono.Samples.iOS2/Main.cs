using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Xpf.Mono.Samples.iOS
{
	[Register("AppDelegate")]
	public class Program:UIApplicationDelegate
	{
		Game1 game;
		public override void FinishedLaunching(UIApplication app)
		{
			game = new Game1 ();
			game.Run ();
		}

		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}
