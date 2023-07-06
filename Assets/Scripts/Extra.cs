using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Extra : MonoBehaviour {


	private Main maincode;
	private bool hittingplayer;
	private float nearby;
	private Rigidbody2D player;
	private Rigidbody2D bikerigidbody;
	private Character playercode;
	private Extra extramotorbikecode;
	private Color mycolour; 
	private float colourfade;
	private bool issaving; 
	private float issavingtime;
	private int turretTimer;
	private float angle;
	private bool angleswitch;

	public int health;
	public bool dying; 
	public int bodydamage;
	public GameObject explosion;
	public GameObject starburst;
	public Text overlaytext;
	public GameObject bullet;
	public GameObject spawnpos;
	public bool hitwall;
	public Transform myleft;
	public Transform myright;
	public bool direction;

	public bool isObelisk;
	public bool isHostage;
	public bool isAlien;
	public bool isMap;
	public bool isTurret; 
	public bool isMotorbike;

	public GameObject mypos;
	public AudioSource soundplayer;

	public AudioClip bangsound;
	public AudioClip thankssound;
	public AudioClip pagesound;



	void Start () {
		direction = false;
		mypos = GameObject.Find ("Main Camera");
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		player = GameObject.Find ("EggHead").GetComponent<Rigidbody2D> ();
		playercode = GameObject.Find ("EggHead").GetComponent<Character> ();

		issavingtime = 5f; 
		issaving = false;
		health = 5 + maincode.wave;
		dying = false;
		angle = -14f; 
		angleswitch = false;
		if (isTurret) {
			health = 10+ maincode.wave;
		}
		/////
		if (isHostage || isMap) {
			mycolour = overlaytext.GetComponent<Text> ().color;
			mycolour.a = 1f;
		}
		if (isMotorbike) {
			health = 40;
			bikerigidbody = GetComponent<Rigidbody2D> ();
		}
	}
	


	public void extraactive() {
		if (isObelisk) {
			health -= bodydamage; 
			if (health <= 0) {
				
				soundplayer.PlayOneShot (bangsound, 0.7f);
				this.gameObject.SetActive (false);
				Instantiate (explosion, transform.position, transform.rotation);
				maincode.obeliskamount -= 1;

				if (maincode.obeliskamount <= 0) {
					maincode.endingsound ();
					maincode.chat.text = "Great job Eggbot destroying those evil obelisks! Enjoy the $100!";
					maincode.missionsactive = false;
					maincode.gamemoney += 100; 
					maincode.gamemoneyui.text = "$" + maincode.gamemoney.ToString ();
					maincode.missionscomplete += 1;
				}

			}
		}
		if (isAlien) {
			health -= bodydamage; 
			if (health <= 0) {

				soundplayer.PlayOneShot (bangsound, 0.7f);
				this.gameObject.SetActive (false);
				Instantiate (explosion, transform.position, transform.rotation);
				maincode.alienamount -= 1;

				if (maincode.alienamount <= 0) {
					maincode.endingsound ();
					maincode.chat.text = "Yes! More alien scurge defeated! they were really stinking! Enjoy the $100!";
					maincode.missionsactive = false;
					maincode.gamemoney += 100; 
					maincode.gamemoneyui.text = "$" + maincode.gamemoney.ToString ();
					maincode.missionscomplete += 1;
				}

			}
		}
		if (isTurret) {
			health -= bodydamage; 
			if (health <= 0) {

				soundplayer.PlayOneShot (bangsound, 0.7f);
				this.gameObject.SetActive (false);
				Instantiate (explosion, transform.position, transform.rotation);
				maincode.turretamount -= 1;

				if (maincode.turretamount <= 0) {
					maincode.endingsound ();
					maincode.chat.text = "Great job shutting down that security system! That would have been a hassle! Heres $100";
					maincode.missionsactive = false;
					maincode.gamemoney += 100; 
					maincode.gamemoneyui.text = "$" + maincode.gamemoney.ToString ();
					maincode.missionscomplete += 1;
				}

			}
		}
		if (isMotorbike) {
			health -= bodydamage; 

			if (health <= 0) {

				soundplayer.PlayOneShot (bangsound, 0.7f);
				this.gameObject.SetActive (false);
				Instantiate (explosion, transform.position, transform.rotation);
				maincode.motorbikeamount -= 1;

				if (maincode.motorbikeamount <= 0) {
					maincode.endingsound ();
					maincode.chat.text = "Great job killing that zombie biker! Here have $200!";
					maincode.missionsactive = false;
					maincode.gamemoney += 200; 
					maincode.gamemoneyui.text = "$" + maincode.gamemoney.ToString ();
					maincode.missionscomplete += 1;
				}

			}
		}
	}
		
	void flip() {
		if (direction == false) {
			Vector3 theScale = transform.localScale;
			theScale.x = 0.661f;
			transform.localScale = theScale;
		}
		if (direction == true) {
			Vector3 theScale = transform.localScale;
			theScale.x = -0.661f;
			transform.localScale = theScale;
		}
	}


	void OnCollisionEnter2D (Collision2D col) {

		if (isMotorbike) {
			if (col.gameObject.tag == "Player") {
				playercode = GameObject.Find ("EggHead").GetComponent<Character> ();
				if (playercode.myrenderer == true) {
					playercode.hurtplayer ();
					playercode.enemyhitting = "headcrab";
				}
			}
		}
	}

	void Update () {

		if (isMotorbike) {

			hitwall = Physics2D.Linecast (myleft.position, myright.position, 1 << LayerMask.NameToLayer ("Ground"));
	
			if (hitwall == true) {
				flip ();
				direction = !direction;
			}


			if (direction == false) {
				bikerigidbody.velocity = new Vector2 (2, bikerigidbody.velocity.y);
			}
			if (direction == true) {
				bikerigidbody.velocity = new Vector2 (-2, bikerigidbody.velocity.y);
			}
		}



		if (isTurret) {
			turretTimer++; 
			if (turretTimer >= 30) {
				Instantiate (bullet, spawnpos.transform.position, transform.rotation);
				turretTimer = 0;
			}

			if (angleswitch == false) {
				angle += 0.1f;
			}
			if (angleswitch == true) {
				angle -= 0.3f;
			}

			if (angle <= -45) {
				angleswitch = false;
			}
			if (angle >= 5) {
				angleswitch = true;
			}

			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));

		}

		if (isHostage || isMap) {
			if (Input.GetButtonDown ("Activate") && hittingplayer == true) {
				issaving = true;
			}
			if (Input.GetButtonUp ("Activate")) {
				issaving = false;
			}
			if (isHostage) {
				if (issaving == true) {
					issavingtime -= 0.1f;
					overlaytext.text = "Saving..." + issavingtime.ToString ("f1");
				}
				if (issavingtime <= 0) {
					
					AudioSource.PlayClipAtPoint (thankssound, mypos.transform.position);

					this.gameObject.SetActive (false);
					Instantiate (starburst, transform.position, transform.rotation);
					maincode.hostageamount -= 1; 
					overlaytext.text = "[E]" + '\n' + "Rescue";
					issavingtime = 5;
					issaving = false;
					if (maincode.hostageamount <= 0) {
						maincode.endingsound ();
						maincode.chat.text = "Great job Eggbot rescuing those poor captured eggs! Use the $100 wisely!";
						maincode.missionsactive = false;
						maincode.gamemoney += 100; 
						maincode.gamemoneyui.text = "$" + maincode.gamemoney.ToString ();
						maincode.missionscomplete += 1;
					}
				}
			}
			if (isMap) {
				if (issaving == true) {
					issavingtime -= 0.1f;
					overlaytext.text = "Recovering..." + issavingtime.ToString ("f1");
				}
				if (issavingtime <= 0) {
					AudioSource.PlayClipAtPoint (pagesound, mypos.transform.position);
					this.gameObject.SetActive (false);
					Instantiate (starburst, transform.position, transform.rotation);
					maincode.intelamount -= 1; 
					overlaytext.text = "[E]" + '\n' + "Recover";
					issavingtime = 5;
					issaving = false;
					if (maincode.intelamount <= 0) {
						maincode.endingsound ();
						maincode.chat.text = "Ahh good you got that intel on the enemy. Here have $100!";
						maincode.missionsactive = false;
						maincode.gamemoney += 100; 
						maincode.gamemoneyui.text = "$" + maincode.gamemoney.ToString ();
						maincode.missionscomplete += 1;
					}
				}
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
	}

	void colourreset() {
		mycolour.b = 255f;
		mycolour.r = 255f;
		mycolour.g = 255f;
	}


}
