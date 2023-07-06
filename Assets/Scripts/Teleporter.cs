using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	private Activate lever1code;
	private Activate lever2code;
	public GameObject player;

	public int leverspressed;
	public int teletimer;
	public bool telebegin;
	public bool hittingplayer; 
	public GameObject mylight;
	public GameObject sparkles;
	public GameObject Character; 
	public GameObject TeleporterReceiver;
	public GameObject blueeffect;
	public GameObject splosionspawn;
	public GameObject receivesplosion;

	public AudioSource telesound;

	private float nearby;
	private Color mycolour; 
	private float colourfade;
	public Text overlaytext;
	public Text overlaytext2;

	void Start () {
		lever1code = GameObject.Find ("LeverLocked").GetComponent<Activate> ();
		lever2code = GameObject.Find ("LeverLocked2").GetComponent<Activate> ();
		leverspressed = 0;
		hittingplayer = false;
		mylight.SetActive (false);
		sparkles.SetActive (false);
	}


	void Update () {

		if (leverspressed == 2) {
			mylight.SetActive (true);
			sparkles.SetActive (true);
		}

		if (hittingplayer == true) {
			if (Input.GetButtonDown ("Activate") && leverspressed == 2) {
				Character.SetActive (false);
				Instantiate (blueeffect, Character.transform.position, transform.rotation);
				telebegin = true;
			}
		}

		if (telebegin == true) {
			teletimer++;
		}
		if (teletimer > 20 && telebegin == true) {
			telesound.Play ();
			Character.SetActive (true);
			Character.transform.position = TeleporterReceiver.transform.position;
			Instantiate (blueeffect, receivesplosion.transform.position, transform.rotation);
			telebegin = false;
			teletimer = 0;
			//

			lever1code.GetComponent<SpriteRenderer> ().sprite = lever1code.levers [0];
			lever2code.GetComponent<SpriteRenderer> ().sprite = lever2code.levers [0];
			lever1code.pressedonce = false;
			lever2code.pressedonce = false;
			leverspressed = 0;
			overlaytext2.text = leverspressed + "/2 Levers Activated";
			mylight.SetActive (false);
			sparkles.SetActive (false);
		}



			nearby = Vector2.Distance (transform.position, player.transform.position);

		if (leverspressed == 2) {
			if (nearby < 0.8) {
				colourfade = 1f;
				colourreset ();
				mycolour.a = colourfade;
				overlaytext.GetComponent<Text> ().color = mycolour;
				overlaytext2.GetComponent<Text> ().color = mycolour;
				hittingplayer = true;
			}
		}

			if (nearby >= 0.8) {
				colourfade = 0.3f;
				colourreset ();
				mycolour.a = colourfade;
				overlaytext.GetComponent<Text> ().color = mycolour;
				overlaytext2.GetComponent<Text> ().color = mycolour;
				hittingplayer = false;
			}




	}


	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "EggHead") {
			hittingplayer = true;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.name == "EggHead") {
			hittingplayer = false;
		}
	}

	void colourreset() {
		mycolour.b = 255f;
		mycolour.r = 255f;
		mycolour.g = 255f;
	}

}
