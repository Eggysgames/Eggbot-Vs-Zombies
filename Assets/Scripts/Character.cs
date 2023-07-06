using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Character : MonoBehaviour {

	private Rigidbody2D character; 
	private Animator myanimator; 
	private RaycastHit hit;
	private Shop shopcode;
	private ShootingGuns shootingcode;
	private Fading fadingcode;

	public bool showshoponce;
	public int cooldown = 0;
	public int timer; 
	private bool grounded;
	private bool grounded2;
	private bool grounded3;
	private bool trigger1 = true;
	private bool trigger2 = false;
	private bool respawn; 
	private bool runonce;
	private int revivetimer; 

	public bool imdying; 
	public GameObject reviveeffect;
	public GameObject extralife;
	public GameObject hurtpoint;
	public GameObject hurtpoint2;
	public float maxhealth = 100;
	public float currenthealth = 100;
	public float jumpheight = 0f;
	public float speed = 0f;
	public GameObject skulls; 
	public GameObject blood;
	public GameObject explodepoint; 
	public GameObject deathparticle;
	public GameObject mylegs;
	public GameObject theguns;
	public GameObject glock;
	public GameObject baretta;
	public GameObject mac10;
	public Transform myleft;
	public Transform myright; 
	public Transform myarm; 
	public Transform spawnpoint;
	public Text healthUI;
	public bool myrenderer;
	public int hitholder;
	public GameObject megaeffect;
	public string enemyhitting; 
	public GameObject cogsep;
	public GameObject legsep;
	public GameObject armsep;
	public GameObject chatbox;

	public AudioSource deathsound;

	public GameObject popuptext;
	private Vector2 startPos;
	private bool runpopup;
	private Vector2 getbigger;
	private Color mycolour; 
	private float colourfade;
	private bool runpoponce;

	void Start () {
		imdying = false;
		runpopup = false;
		runpoponce = false;
		startPos = popuptext.transform.localPosition;
		mycolour = popuptext.GetComponent<Text> ().color;
		mycolour.a = 1f;
		colourfade = 1;
		popuptext.transform.localScale = new Vector3 (0.68945f, 0.68945f, 0.68945f);
		popuptext.SetActive (false);
		//
		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		shootingcode = GameObject.Find ("ArmGun").GetComponent<ShootingGuns> ();
		fadingcode = GameObject.Find ("FadingEnd").GetComponent<Fading> ();
		myrenderer = GetComponent<SpriteRenderer> ();
		character = GetComponent<Rigidbody2D> (); 
		myanimator = mylegs.GetComponent<Animator> ();
		extralife.SetActive (false);
		runonce = false;
		revivetimer = 0;
		timer = 11; 
		cooldown = 8;
		showshoponce = false;
	}
	

	void Update () {

		if (currenthealth <= 20 && runpoponce == false) {
			popuptext.SetActive (true);
			runpopup = true;
			runpoponce = true;
		}
		if (currenthealth >= 21) {
			runpoponce = false;
		}

		if (runpopup == true && shopcode.isvisible == false) {
			popuptext.transform.Translate (Vector2.up / 300);
			timer++;
			//
			colourfade -= 0.01f;
			colourreset ();
			mycolour.a = colourfade;
			popuptext.GetComponent<Text> ().color = mycolour;

			if (timer > 100) {
				runpopup = false;
				timer = 0;
				popuptext.SetActive (false);
				popuptext.transform.localPosition = startPos;
				colourfade = 1f;
				colourreset ();
				mycolour.a = colourfade;
				popuptext.GetComponent<Text> ().color = mycolour;
			}
		}

		///

		if (character.velocity.magnitude > 5f) {
			character.velocity = Vector3.ClampMagnitude (character.velocity, 5f);
		}

		if (shopcode.isvisible == false) {
			Vector3 mousePos = Input.mousePosition;
			myrenderer = GetComponent<SpriteRenderer> ().enabled;
			grounded = Physics2D.Linecast (myleft.position, myright.position, 1 << LayerMask.NameToLayer ("Ground"));
			grounded2 = Physics2D.Linecast (myleft.position, myright.position, 1 << LayerMask.NameToLayer ("Enemy"));
			grounded3 = Physics2D.Linecast (myleft.position, myright.position, 1 << LayerMask.NameToLayer ("Little"));

			if (myrenderer == true) {
				float horizontal = Input.GetAxis ("Horizontal");
				Movement (horizontal);
				inputkeys (); 
			}

			////
			mouseflip ();
			uiupdate ();
		}
		////////////
		cooldown++;

		if (respawn == true && showshoponce == false) {
			timer++; 
			if (timer > 100) {
				fadingcode.fadingin = true;
				showshoponce = true;
				chatbox.SetActive (false);
			}
		}
		if (extralife.activeSelf == true) {
			if (currenthealth <= 0) {
				dyingextralife ();

			}
		}

		if (extralife.activeSelf == false) {
			if (currenthealth <= 0) {
				dying ();
			}
		}

		if (transform.position.y < -50) {
			dying (); 
		}
		if (character.transform.position.y < -150) {
			dying (); 
		}
	}




	void mouseflip() {

		if (Time.timeScale != 0) {

			if (myarm.transform.localEulerAngles.z >= 90f && myarm.transform.localEulerAngles.z <= 270f && trigger1 == true) {
				Vector3 theScale = transform.localScale;
				theScale.x = -1;
				transform.localScale = theScale;
				//

				popuptext.transform.localScale = new Vector3 (-0.68945f, 0.68945f, 0.68945f);
				//

				megaeffect.SetActive (false);

				if (trigger1 == true) {
					myarm.transform.localScale *= -1;
					trigger1 = false;
					trigger2 = true;
				}
			}
			if (myarm.transform.localEulerAngles.z < 90f && trigger2 == true || myarm.transform.localEulerAngles.z > 270 && trigger2 == true) {

				Vector3 theScale = transform.localScale;
				theScale.x = 1;
				transform.localScale = theScale;
				//
				popuptext.transform.localScale = new Vector3 (0.68945f, 0.68945f, 0.68945f);
				//
				megaeffect.SetActive (false);

				if (trigger2 == true) {
					myarm.transform.localScale *= -1;
					trigger1 = true;
					trigger2 = false;
				}
			}

		}


	}
		
	void Movement(float horizontal) {
		character.velocity = new Vector2 (horizontal * speed, character.velocity.y);
		myanimator.SetFloat ("speed", Mathf.Abs(horizontal));
		if (transform.localScale.x == 1 && horizontal < 0) {
			myanimator.SetBool ("direction", false);
		}
		if (transform.localScale.x == 1 && horizontal > 0) {
			myanimator.SetBool ("direction", true);
		}
		if (transform.localScale.x == -1 && horizontal < 0) {
			myanimator.SetBool ("direction", true);
		}
		if (transform.localScale.x == -1 && horizontal > 0) {
			myanimator.SetBool ("direction", false);
		}
	}

	void inputkeys() {
		if (Input.GetButtonDown ("Jump") && grounded) {
			character.velocity = Vector3.zero;
			character.AddForce (new Vector2 (0, jumpheight));
		}
		if (Input.GetButtonDown ("Jump") && grounded2) {
			character.velocity = Vector3.zero;
			character.AddForce (new Vector2 (0, jumpheight));
		}
		if (Input.GetButtonDown ("Jump") && grounded3) {
			character.velocity = Vector3.zero;
			character.AddForce (new Vector2 (0, jumpheight));
		}
	}

	void dying() {
		if (respawn == false) {

			imdying = true;

			deathsound.Play ();
			respawn = true; 

			character.isKinematic = true;
			character.velocity = Vector2.zero;

			shootingcode.hideguns ();
			myarm.GetComponent<SpriteRenderer> ().enabled = false;
			mylegs.GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<SpriteRenderer> ().enabled = false;

			//Instantiate (deathparticle, explodepoint.transform.position, transform.rotation);
			Instantiate (skulls, explodepoint.transform.position, transform.rotation);
			Instantiate (blood, transform.position, transform.rotation);
			//
			Instantiate (cogsep, hurtpoint.transform.position, transform.rotation);
			Instantiate (cogsep, hurtpoint2.transform.position, transform.rotation);
			Instantiate (cogsep, transform.position, transform.rotation);
			Instantiate (legsep, explodepoint.transform.position, transform.rotation);
			Instantiate (armsep, explodepoint.transform.position, transform.rotation);
		}
	}

	void dyingextralife() {
		if (runonce == false) {

			imdying = true;

			deathsound.Play ();
			character.isKinematic = true;
			character.velocity = Vector2.zero;
			shootingcode.hideguns ();
			myarm.GetComponent<SpriteRenderer> ().enabled = false;
			mylegs.GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<SpriteRenderer> ().enabled = false;
			//Instantiate (deathparticle, explodepoint.transform.position, transform.rotation);
			Instantiate (skulls, explodepoint.transform.position, transform.rotation);
			Instantiate (blood, transform.position, transform.rotation);
			//
			Instantiate (cogsep, hurtpoint.transform.position, transform.rotation);
			Instantiate (cogsep, hurtpoint2.transform.position, transform.rotation);
			Instantiate (cogsep, transform.position, transform.rotation);
			Instantiate (legsep, explodepoint.transform.position, transform.rotation);
			Instantiate (armsep, explodepoint.transform.position, transform.rotation);
			runonce = true;
		}
		revivetimer++;
		if (revivetimer >= 50) {
			revive2();
		}
		//
	}

	void revive2() {
		timer = 0;
		currenthealth = 100;
		respawn = false;

		imdying = false;

		shootingcode.switchtheguntype ();
		character.isKinematic = false;

		Instantiate (reviveeffect, transform.position, transform.rotation);

		theguns.GetComponent<SpriteRenderer> ().enabled = true;
		myarm.GetComponent<SpriteRenderer> ().enabled = true;
		mylegs.GetComponent<SpriteRenderer> ().enabled = true;
		GetComponent<SpriteRenderer> ().enabled = true;
		revivetimer = 0;
		runonce = false;
		extralife.SetActive (false);

	}

	public void revive() {
		timer = 0;
		currenthealth = 100;
		respawn = false;

		imdying = false;

		transform.position = spawnpoint.position;

		character.isKinematic = false;

		theguns.GetComponent<SpriteRenderer> ().enabled = true;
		myarm.GetComponent<SpriteRenderer> ().enabled = true;
		mylegs.GetComponent<SpriteRenderer> ().enabled = true;
		GetComponent<SpriteRenderer> ().enabled = true;


		AudioListener.pause = true;
		Time.timeScale = 0;
		

		shopcode.showshop ();

	}

	public void uiupdate() {
		healthUI.text = currenthealth.ToString ();
		if (currenthealth < 0) {
			currenthealth = 0;
		}

	}
		

	public void hurtplayer() {
		if (myrenderer == true && cooldown >= 20) {
			//hurt player

			timer++;
			if (hitholder == 0) {
				Instantiate (blood, hurtpoint.transform.position, transform.rotation);
			}
			if (hitholder == 1) {
				Instantiate (blood, hurtpoint.transform.position, transform.rotation);
			}
			if (hitholder == 2) {
				Instantiate (blood, hurtpoint2.transform.position, transform.rotation);
			}
			if (enemyhitting == "zombie") {
				currenthealth -= 10f;
			}
			if (enemyhitting == "headcrab") {
				currenthealth -= 1f;
			}

			timer = 0;
			cooldown = 0;


		}
	}
	void colourreset() {
		mycolour.b = 255f;
		mycolour.r = 255f;
		mycolour.g = 255f;
	}



}
