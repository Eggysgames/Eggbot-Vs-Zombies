using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunBox : MonoBehaviour {

	private ShootingGuns shootingcode;
	private GunUISprites thesprites;
	private Main maincode;
	private bool hittingplayer;
	private float nearby;
	private Rigidbody2D player;
	private Color mycolour; 
	private float colourfade;
	private int timer;
	private int timer2;
	private bool readytograb;
	private int gun;
	private Vector2 getbigger;
	private Vector2 startPos;
	private string gunname; 
	private int myroll;


	public Transform pos1;
	public Transform pos2;
	public Transform pos3;
	public Transform pos4;
	public Transform pos5;
	public Transform pos6;
	public Transform pos7;
	public GameObject poof;
	public GameObject GunBoxObject;
	public GameObject gunsinthebox;
	public GameObject overlay;
	public int framegun; 
	public Text overlaytext;
	public Text overlaytext2;
	public int cost; 
	public bool gunrolling; 

	public GameObject mypos;

	public bool awppurchased = true;
	public bool bigbessypurchased = true;
	public bool laserpurchased = true;
	public bool bigsniperpurchased = false;
	public bool handturretpurchased = false;
	public bool shotgunpurchased = false;
	public bool antigravpurchased = false;

	public AudioSource chestsound;
	public AudioClip equipsound;

	void Start () {
		mypos = GameObject.Find ("Main Camera");
		gunrolling = false;
		readytograb = false;
		startPos = gunsinthebox.transform.localPosition;
		gun = 0;
		getbigger.x = 0.336f;
		getbigger.y = 0.336f;
		shootingcode = GameObject.Find ("ArmGun").GetComponent<ShootingGuns> ();
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		player = GameObject.Find ("EggHead").GetComponent<Rigidbody2D> ();
		thesprites = GameObject.Find ("GunsInTheBox").GetComponent<GunUISprites> ();
		mycolour = overlaytext.GetComponent<Text> ().color;
		mycolour.a = 1f;
		gunsinthebox.SetActive (false);
		newspawn ();
		///


	}

	void Update () {
		
		if (Input.GetButtonDown ("Activate") && maincode.gamemoney >= cost && hittingplayer == true) {

			if (readytograb == false) {
				chestsound.Play ();
				overlay.SetActive (false);
				gunsinthebox.SetActive (true);
				gunrolling = true;
			}

			///Grab Gun
			if (readytograb == true) {
				AudioSource.PlayClipAtPoint (equipsound, mypos.transform.position);
				workoutguns ();
				shootingcode.primary = framegun;
				shootingcode.GunUISpritescode.guntype = framegun;
				shootingcode.GunUISpritescode.switchweapons ();
				shootingcode.switchtheguntype ();
				shootingcode.resetammo ();
				////
				maincode.gamemoney -= cost;
				maincode.UpdateText ();
				///
				getbigger.x = 0.336f;
				getbigger.y = 0.336f;
				gunsinthebox.transform.localScale = getbigger;
				overlay.SetActive (true);
				gunsinthebox.SetActive (false);
				readytograb = false;
				gunrolling = false;
				timer = 0;
				timer2 = 0;
				Instantiate(poof, transform.position, transform.rotation);
				gunsinthebox.transform.localPosition = startPos;

				//
				maincode.boxtimeractive = true;
				//
				GunBoxObject.SetActive(false);

			}
		}
			

		if (gunrolling == true) {
			
			getbigger.x += 0.01f;
			getbigger.y += 0.01f;
			gunsinthebox.transform.localScale = getbigger;
			gunsinthebox.transform.Translate (Vector2.up/300);
			timer++;
			timer2++;

			if (timer >= 3) {
				gun = Random.Range (0, 7);
				workoutguns ();
				thesprites.guntype = gun;
				thesprites.switchweaponssprites ();
				timer = 0;
				overlaytext2.text = "[E]" + "\n" + gunname;
			}
			if (timer2 >= 60) {
				gun = Random.Range (0, 7);
				workoutguns ();
				//

				//
				thesprites.guntype = gun;
				thesprites.switchweaponssprites ();
				readytograb = true;
				gunrolling = false;
				overlaytext2.text = "[E]" + "\n" + gunname;
			}
		}



		///Text Fade
		nearby = Vector2.Distance (transform.position, player.transform.position);
		if (nearby < 1.5) {
			colourfade = 1f;
			colourreset ();
			mycolour.a = colourfade;
			overlaytext.GetComponent<Text> ().color = mycolour;
			overlaytext2.GetComponent<Text> ().color = mycolour;
			hittingplayer = true;
		}
		if (nearby >= 1.5) {
			colourfade = 0.3f;
			colourreset ();
			mycolour.a = colourfade;
			overlaytext.GetComponent<Text> ().color = mycolour;
			overlaytext2.GetComponent<Text> ().color = mycolour;
			hittingplayer = false;
		}
	}


	void colourreset() {
		mycolour.b = 255f;
		mycolour.r = 255f;
		mycolour.g = 255f;
	}

	void workoutguns() {
		if (gun == 0) {
			framegun = 19;
			gunname = "Awp";
		}
		if (gun == 1) {
			framegun = 20;
			gunname = "Big Bessy";
		}
		if (gun == 2) {
			framegun = 21;
			gunname = "Laser";
		}
		if (gun == 3) {
			if (bigsniperpurchased == true) {
				framegun = 22;
				gunname = "Big Sniper";
			}
			if (bigsniperpurchased == false) {
				framegun = 19;
				gunname = "Awp";
				gun = 0;
			}
		}
		if (gun == 4) {
			if (handturretpurchased == true) {
				framegun = 23;
				gunname = "Hand Turret";
			}
			if (handturretpurchased == false) {
				framegun = 20;
				gunname = "Big Bessy";
				gun = 1;
			}
		}
		if (gun == 5) {
			if (shotgunpurchased == true) {
				framegun = 24;
				gunname = "12 Gauge";
			}
			if (shotgunpurchased == false) {
				framegun = 21;
				gunname = "Laser";
				gun = 2;
			}
		}
		if (gun == 6) {
			if (antigravpurchased == true) {
				framegun = 25;
				gunname = "Anti-Grav Gun";
			}
			if (antigravpurchased == false) {
				framegun = 21;
				gunname = "Laser";
				gun = 2;
			}
		}

	}
	public void newspawn() {
		myroll = Random.Range (0, 6);

		if (myroll == 1) {
			GunBoxObject.transform.position = pos1.transform.position;
			Instantiate(poof, pos1.transform.position, transform.rotation);
		}
		if (myroll == 2) {
			GunBoxObject.transform.position = pos2.transform.position;
			Instantiate(poof, pos2.transform.position, transform.rotation);
		}
		if (myroll == 3) {
			GunBoxObject.transform.position = pos3.transform.position;
			Instantiate(poof, pos3.transform.position, transform.rotation);
		}
		if (myroll == 4) {
			GunBoxObject.transform.position = pos4.transform.position;
			Instantiate(poof, pos4.transform.position, transform.rotation);
		}
		if (myroll == 5) {
			GunBoxObject.transform.position = pos5.transform.position;
			Instantiate(poof, pos5.transform.position, transform.rotation);
		}
		if (myroll == 6) {
			GunBoxObject.transform.position = pos6.transform.position;
			Instantiate(poof, pos6.transform.position, transform.rotation);
		}
		if (myroll == 0) {
			GunBoxObject.transform.position = pos7.transform.position;
			Instantiate(poof, pos7.transform.position, transform.rotation);
		}
		GunBoxObject.SetActive(true);
	}
		

}
