using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traps : MonoBehaviour {

	private Zombie zombieCode; 
	private Enemy enemycode; 

	private GameObject player;
	private Main maincode;

	public int cost;
	private bool hittingplayer;
	private float nearby;
	private Color mycolour; 
	private float colourfade;
	public Text overlaytext;

	public GameObject blade;
	public GameObject blade2;
	public GameObject blade3;
	public GameObject blade4;
	public GameObject blade5;
	public GameObject bloodsplat;
	public GameObject splatspot1;
	public GameObject splatspot2;
	public bool bladeson;
	public int timer; 

	public AudioSource chainsaw;

	void Start () {
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		player = GameObject.Find ("EggHead");
		hittingplayer = false;
		blade.SetActive (false);
		blade2.SetActive (false);
		blade3.SetActive (false);
		blade4.SetActive (false);
		blade5.SetActive (false);
	}


	void Update () {


		if (Input.GetButtonDown ("Activate") && maincode.gamemoney >= cost && hittingplayer == true && bladeson == false) {

			maincode.gamemoney -= cost;
			maincode.UpdateText ();
			chainsaw.Play ();

			blade.SetActive (true);
			blade2.SetActive (true);
			blade3.SetActive (true);
			blade4.SetActive (true);
			blade5.SetActive (true);

			bladeson = true;


			colourfade = 0f;
			colourreset ();
			mycolour.a = colourfade;
			overlaytext.GetComponent<Text> ().color = mycolour;


		}

		if (bladeson == true) {
			timer++; 

			if (timer > 1200) {
				timer = 0;
				bladeson = false;
				blade.SetActive (false);
				blade2.SetActive (false);
				blade3.SetActive (false);
				blade4.SetActive (false);
				blade5.SetActive (false);
				colourfade = 1f;
				colourreset ();
				mycolour.a = colourfade;
				overlaytext.GetComponent<Text> ().color = mycolour;

			}

		}

		if (bladeson == false) {
			nearby = Vector2.Distance (transform.position, player.transform.position);

			if (nearby < 0.6) {
				colourfade = 1f;
				colourreset ();
				mycolour.a = colourfade;
				overlaytext.GetComponent<Text> ().color = mycolour;
				//overlaytext2.GetComponent<Text> ().color = mycolour;
				hittingplayer = true;
			}
			if (nearby >= 0.6) {
				colourfade = 0.3f;
				colourreset ();
				mycolour.a = colourfade;
				overlaytext.GetComponent<Text> ().color = mycolour;
				//overlaytext2.GetComponent<Text> ().color = mycolour;
				hittingplayer = false;
			}
		}
	}


	void colourreset() {
		mycolour.b = 255f;
		mycolour.r = 255f;
		mycolour.g = 255f;
	}


	void OnTriggerStay2D (Collider2D col) {


		if (col.gameObject.tag == "Enemy") {

			zombieCode = col.transform.gameObject.GetComponent<Zombie> ();

				
			if (bladeson == true) {
				if (zombieCode.dying == false) {
					Instantiate (bloodsplat, splatspot1.transform.position, transform.rotation);
					Instantiate (bloodsplat, splatspot2.transform.position, transform.rotation);
					zombieCode.bodydamage = 999;
					zombieCode.store = 2; 
					//xpos = transform.position.x;
					//zombieCode.xposholder = xpos;
					//zombieCode.guntype = "m32";
					zombieCode.Damaged ();
				}
			}
		}
		if (col.gameObject.tag == "CrabEnemy") {

			enemycode = col.transform.gameObject.GetComponent<Enemy> ();

				
			if (bladeson == true) {
				if (enemycode.dying == false) {
					enemycode.bodydamage = 999;
					enemycode.store = 2; 
					//xpos = transform.position.x;
					//enemycode.xposholder = xpos;
					//zombieCode.guntype = "m32";
					enemycode.Damaged ();
					
				}
			}

		}
	}

}
