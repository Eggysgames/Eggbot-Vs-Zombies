using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void OpenLinkJSPlugin()
	{
		#if !UNITY_EDITOR
		openWindow("http://www.eggysgames.com");
		#endif
	}

	public void OpenLinkJSPluginGooglePlay()
	{
		#if !UNITY_EDITOR
		openWindow("https://play.google.com/store/apps/details?id=com.EggysGames.EggbotVsZombies");
		#endif
	}

	public void OpenLinkJSPluginLikeUs()
	{
		#if !UNITY_EDITOR
		openWindow("http://www.facebook.com/EggysGames");
		#endif
	}

	public void OpenLinkJSPluginPlayMore()
	{
		#if !UNITY_EDITOR
		openWindow("http://www.eggysgames.com");
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}