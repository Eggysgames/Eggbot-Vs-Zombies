using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activate : MonoBehaviour {

	public Sprite[] levers;
	public bool hittingplayer; 
	public Teleporter teleportercode;
	public bool pressedonce;

	private Rigidbody2D player;
	private float nearby;
	private Color mycolour; 
	private float colourfade;
	public Text overlaytext;
	//public Text overlaytext2;

	public AudioSource leversound;

	void Start () {
		player = GameObject.Find ("EggHead").GetComponent<Rigidbody2D> ();
		pressedonce = false;
		hittingplayer = false;
		teleportercode = GameObject.Find ("Teleporter").GetComponent<Teleporter> ();
	}

	void Update() {
		if (hittingplayer == true) {
			if (Input.GetButtonDown ("Activate") && pressedonce == false) {
				GetComponent<SpriteRenderer> ().sprite = levers [1];
				teleportercode.leverspressed++;
				pressedonce = true;
				leversound.Play ();
				teleportercode.overlaytext2.text = teleportercode.leverspressed + "/2 Levers Activated";
			}
		}

		nearby = Vector2.Distance (transform.position, player.transform.position);

		if (nearby < 0.8) {
			colourfade = 1f;
			colourreset ();
			mycolour.a = colourfade;
			overlaytext.GetComponent<Text> ().color = mycolour;
			//overlaytext2.GetComponent<Text> ().color = mycolour;
			hittingplayer = true;
		}
		if (nearby >= 0.8) {
			colourfade = 0.3f;
			colourreset ();
			mycolour.a = colourfade;
			overlaytext.GetComponent<Text> ().color = mycolour;
			//overlaytext2.GetComponent<Text> ().color = mycolour;
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
