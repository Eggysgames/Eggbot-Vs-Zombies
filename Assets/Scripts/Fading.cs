using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Fading : MonoBehaviour {

	private FadingBasic fadingcode;
	private Character playercode;
	private Main maincode;
	private Shop shopcode;

	public Image blackbox; 
	public GameObject uihud;
	public GameObject exitbutton;
	public Text title;
	public Text enemieskilled; 
	public Text zombieheadshots;
	public Text bestwave;
	public Text missions;
	public Text moneyearned;
	public int moneyearnedint; 
	public bool fadingin;
	public GameObject shop; 
	public Text pausedtitle;
	public GameObject pausedmenu;
	public GameObject specialeffects;
	public Text specialeffectstext;
	public Text backgroundtext;
	public Text audiotext;
	public Text fullscreentext;
	public bool specialonoroff; 
	public bool backgroundonoroff;
	public bool switchsound;
	public GameObject background;
	public bool switchfullscreen;

	private float timer;
	private bool setthemoneys;
	public bool paused;
	private bool onlyonce;

	public AudioSource beep;

	void Start () {
		onlyonce = false;
		fadingcode = GameObject.Find ("FadingMenu").GetComponent<FadingBasic> ();
		switchsound = true;
		specialonoroff = true;
		backgroundonoroff = true;
		setthemoneys = false;
		switchfullscreen = false;
		paused = false;
		playercode = GameObject.Find ("EggHead").GetComponent<Character> ();
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		fadingin = false;
		timer = 1;
		blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (10);
		exitbutton.GetComponent<Image> ().canvasRenderer.SetAlpha (0);
		title.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
		enemieskilled.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
		zombieheadshots.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
		bestwave.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
		missions.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
		moneyearned.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
		////
		pausedmenu.SetActive(false);
		AudioListener.pause = false;
	}


	void Update () {

		//Debug.Log (exitbutton.GetComponent<Image> ().canvasRenderer.GetAlpha ());

		if (Input.GetButtonDown ("Pause") && shopcode.isvisible == false) {
			paused = !paused;
			if (paused == true) {
				blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (10);
				pausedmenu.SetActive(true);
				Time.timeScale = 0;
			}
			else if (paused == false) {
				blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (0);
				pausedmenu.SetActive(false);
				Time.timeScale = 1;
			}

		}

		///FadeInForEnd
		if (fadingin == true) {

			if (setthemoneys == false) {
				moneyearnedint = maincode.enemieskilled / 2 + maincode.headshots * 2 + maincode.wave * 3 + maincode.missionscomplete * 10;
				enemieskilled.text = "Enemies Killed - " + maincode.enemieskilled + "................$" + maincode.enemieskilled / 2; 
				zombieheadshots.text = "Zombie Headshots - " + maincode.headshots + "..........$" + maincode.headshots*2; 
				bestwave.text = "Wave Reached - " + maincode.wave + "...............$" + maincode.wave * 3; 
				missions.text = "Missions Complete - " + maincode.missionscomplete + "............$" + maincode.missionscomplete * 10;
				moneyearned.text = "Total Money Earned - $" + moneyearnedint;
				shopcode.money += moneyearnedint;
				shopcode.moneyui.text = "$" + shopcode.money.ToString ();
				setthemoneys = true;

				PlayerPrefs.SetInt ("Money", shopcode.money);


			}


			//
			uihud.SetActive (false);
			timer += 0.2f; 
			///
			if (timer < 10) {
				blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (timer);
				exitbutton.GetComponent<Image> ().canvasRenderer.SetAlpha (timer);
				//
				title.GetComponent<Text> ().canvasRenderer.SetAlpha (timer/10);
				enemieskilled.GetComponent<Text> ().canvasRenderer.SetAlpha (timer/10);
				zombieheadshots.GetComponent<Text> ().canvasRenderer.SetAlpha (timer/10);
				bestwave.GetComponent<Text> ().canvasRenderer.SetAlpha (timer/10);
				missions.GetComponent<Text> ().canvasRenderer.SetAlpha (timer/10);
				moneyearned.GetComponent<Text> ().canvasRenderer.SetAlpha (timer/10);
			}
			if (timer >= 10) {
				fadingin = false;
				timer = 0;
				setthemoneys = false;
			}
		}
	}

	public void exittoshop() {

		if (exitbutton.GetComponent<Image> ().canvasRenderer.GetAlpha () >= 9.9f) {

			AudioListener.pause = true;
			Time.timeScale = 0;

			//blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (0);
			exitbutton.GetComponent<Image> ().canvasRenderer.SetAlpha (0);
			//
			title.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
			enemieskilled.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
			zombieheadshots.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
			bestwave.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
			missions.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
			moneyearned.GetComponent<Text> ().canvasRenderer.SetAlpha (0);

			playercode.revive ();


			beep.Play ();
		}

	}

	public void hideblack() {
		blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (0);
	}

	public void unpausegame() {
		beep.Play ();
		paused = !paused;
		blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (0);
		pausedmenu.SetActive(false);
		Time.timeScale = 1;
	}
	public void disablespecialeffects() {
		specialonoroff = !specialonoroff;
		beep.Play ();
		if (specialonoroff == true) {
			specialeffectstext.text = "Background Effects - On";
			specialeffects.SetActive (true);
		}
		if (specialonoroff == false) {
			specialeffectstext.text = "Background Effects - Off";
			specialeffects.SetActive (false);
		}


	}
	public void disablebackground() {
		backgroundonoroff = !backgroundonoroff;
		beep.Play ();
		if (backgroundonoroff == true) {
			backgroundtext.text = "Background - On";
			background.SetActive (true);
		}
		if (backgroundonoroff == false) {
			backgroundtext.text = "Background - Off";
			background.SetActive (false);
		}
	}

	public void togglesound() {
		switchsound = !switchsound;
		beep.Play ();
		if (switchsound == true) {
			audiotext.text = "Sound - On";
			AudioListener.pause = false;
		}
		if (switchsound == false) {
			audiotext.text = "Sound - Off";
			AudioListener.pause = true;
		}
	}

	public void togglefullscreen() {
		switchfullscreen = !switchfullscreen;
		beep.Play ();
		if (switchfullscreen == true) {
			fullscreentext.text = "Fullscreen - On";
			Screen.fullScreen = true;
		}
		if (switchfullscreen == false) {
			fullscreentext.text = "Fullscreen - Off";
			Screen.fullScreen = false;
		}
	}

	public void playgame() {
		if (onlyonce == false) {
			beep.Play ();
			fadingcode.faderunning = true;
			onlyonce = true;
			Time.timeScale = 1;
		}
	}
}
