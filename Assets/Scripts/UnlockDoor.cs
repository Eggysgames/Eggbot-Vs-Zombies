using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnlockDoor : MonoBehaviour {

	private Main maincode;
	private bool hittingplayer;
	private float nearby;
	private Rigidbody2D player;
	private Color mycolour; 
	private float colourfade;

	public GameObject explosion;
	public Text overlaytext;
	public GameObject door; 
	public int cost; 

	public AudioSource unlocksound;

	void Start () {
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		player = GameObject.Find ("EggHead").GetComponent<Rigidbody2D> ();
		/////
		mycolour = overlaytext.GetComponent<Text> ().color;
		mycolour.a = 1f;
	}

	void Update () {

		if (Input.GetButtonDown ("Activate") && maincode.gamemoney >= cost && hittingplayer == true) {

			unlocksound.Play ();

			maincode.gamemoney -= cost;
			maincode.UpdateText ();
			door.SetActive (false);
			overlaytext.GetComponent<Text> ().enabled = false;

			Instantiate (explosion, transform.position, transform.rotation); 

		}
			
		nearby = Vector2.Distance (transform.position, player.transform.position);

		if (nearby < 1.5) {
			colourfade = 1f;
			colourreset ();
			mycolour.a = colourfade;
			overlaytext.GetComponent<Text> ().color = mycolour;
			hittingplayer = true;
		}
		if (nearby >= 1.5) {
			colourfade = 0.3f;
			colourreset ();
			mycolour.a = colourfade;
			overlaytext.GetComponent<Text> ().color = mycolour;
			hittingplayer = false;
		}


		
	}


	void colourreset() {
		mycolour.b = 255f;
		mycolour.r = 255f;
		mycolour.g = 255f;
	}


}
