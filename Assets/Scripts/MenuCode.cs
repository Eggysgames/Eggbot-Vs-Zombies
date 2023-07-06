using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCode : MonoBehaviour {

	private FadingBasic fadingcode;
	AsyncOperation sceneAO;
	public bool onlyonce;

	public AudioSource beep;

	public bool showadOn;


	void Start () {

		fadingcode = GameObject.Find ("FadingMenu").GetComponent<FadingBasic> ();
		onlyonce = false;

	}


	public void playgame() {
		if (onlyonce == false && fadingcode.IsThisFadingIn == false) {
			fadingcode.faderunning = true;
			onlyonce = true;
			beep.Play ();
			//
			if (!showadOn) {
				Time.timeScale = 1;
				AudioListener.pause = false;
			}
			if (showadOn) {
				Debug.Log ("ad shown");
				
				Time.timeScale = 0;

			}

		}
	}

	public void playmoregames() {
		beep.Play ();
		Application.ExternalEval("window.open(\"http://www.eggysgames.com\",\"_blank\")");
	}

	public void likeus() {
		beep.Play ();
		Application.ExternalEval("window.open(\"http://www.facebook.com/EggysGames\",\"_blank\")");
	}

	public void eggysgames() {
		beep.Play ();
		Application.ExternalEval("window.open(\"http://www.eggysgames.com\",\"_blank\")");
	}

	public void googleplay() {
		beep.Play ();
		Application.ExternalEval("window.open(\"https://play.google.com/store/apps/details?id=com.EggysGames.EggbotVsZombies\",\"_blank\")");

	}




}
