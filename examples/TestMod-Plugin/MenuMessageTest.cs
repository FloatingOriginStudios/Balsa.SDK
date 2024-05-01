using System;

using UI;

namespace KitHackPluginTest
{
	[UI.MenuMessage]
	public class MenuMessageTest : UI.MenuMessageBase
	{
		/* Menu messages are displayed as the game is starting up. (eg, the Early Access warning message is a MenuMessage)
		 * You can define your own messages by creating subclasses of UI.MenuMessageBase and using the MenuMessage attribute 
		 */

		public override void OnShow(Action proceed)
		{
			PopupDialog.Create("Addon Test",
				"This message is brought to you by KitHackAddonTest.dll, for all your addon testing needs!"
				+ "\n\n"
				+ ("Check out this plugin's source code in the KitHack.SDK, available on Github.".RTColor(BalsaColors.TrainingBlue).RTSizePct(80f))

				, IconSprite.Info, BalsaColors.TrainingBlue,
					new PopupDialogOption("Cool", proceed),
					new PopupDialogOption("Open Github", () =>
					{
						openGitHub();
						proceed?.Invoke();  // don't forget to call proceed on these messages, otherwise the game can get stuck!
					}));
		}

		private void openGitHub()
		{
			// calling explorer with an url opens it in the default browser. Use this new power responsibly!
			//System.Diagnostics.Process.Start("explorer.exe", "https://floatingorigininteractive.github.io/Balsa.SDK");

			// Alternatively, you can use Steam's own browser.
			if (BalsaAddons.Steam.SteamworksSetup.Init)
			{
				System.Diagnostics.Process.Start("\"steam://openurl/https://floatingorigininteractive.github.io/Balsa.SDK");
			}
		}
	}
}
