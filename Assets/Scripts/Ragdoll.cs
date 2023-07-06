using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour {

	private bool justonce;
	private Main maincode;
	private Shop shopcode;

	public Rigidbody2D torso;
	public Rigidbody2D headR;
	public Rigidbody2D frontarmR;
	public Rigidbody2D behindarmR;
	public Rigidbody2D behindlegR;
	public Rigidbody2D frontlegR;


	public SpriteRenderer head;
	public SpriteRenderer frontarm;
	public SpriteRenderer behindarm;
	public SpriteRenderer behindleg;
	public SpriteRenderer frontleg;
	public SpriteRenderer mytorso;
	public float explosionxpos; 
	public float explosionforce;
	public float explosiontotal;
	public float randomforce;
	public string guntype; 
	public int gunforce;
	public bool direction; 

	public AudioSource soundplayer;

	public AudioClip growl1;
	public AudioClip growl2;
	public AudioClip growl3;
	public AudioClip growl4;
	public AudioClip growl5;
	public AudioClip growl6;
	public AudioClip growl7;
	public AudioClip growl8;
	public AudioClip growl9;
	public AudioClip growl10;

	public int audioroll;

	void Start () {
		audiodying();
		maincode = GameObject.Find ("Main Camera").GetComponent<Main>();
		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		explosiontotal = 200;
		justonce = true;
		//torso = GetComponentInChildren<Rigidbody2D> ();

		headR = this.gameObject.transform.GetChild (0).GetComponent<Rigidbody2D> ();
		frontarmR = this.gameObject.transform.GetChild (1).GetComponent<Rigidbody2D> ();
		torso = this.gameObject.transform.GetChild (2).GetComponent<Rigidbody2D> ();
		behindarmR = this.gameObject.transform.GetChild (3).GetComponent<Rigidbody2D> ();
		behindlegR = this.gameObject.transform.GetChild (4).GetComponent<Rigidbody2D> ();
		frontlegR = this.gameObject.transform.GetChild (5).GetComponent<Rigidbody2D> ();
		///
		head = this.gameObject.transform.GetChild (0).GetComponent<SpriteRenderer> ();
		frontarm = this.gameObject.transform.GetChild (1).GetComponent<SpriteRenderer> ();
		mytorso = this.gameObject.transform.GetChild (2).GetComponent<SpriteRenderer> ();
		behindarm = this.gameObject.transform.GetChild (3).GetComponent<SpriteRenderer> ();
		behindleg = this.gameObject.transform.GetChild (4).GetComponent<SpriteRenderer> ();
		frontleg = this.gameObject.transform.GetChild (5).GetComponent<SpriteRenderer> ();
		//
		behindleg.sortingOrder = maincode.ragdollorder;
		behindarm.sortingOrder = maincode.ragdollorder + 1;
		mytorso.sortingOrder = maincode.ragdollorder + 2;
		frontarm.sortingOrder = maincode.ragdollorder + 3;
		frontleg.sortingOrder = maincode.ragdollorder + 4;
		head.sortingOrder = maincode.ragdollorder+5;
		maincode.ragdollorder += 6; 
		//Debug.Log (maincode.increaseorder);
	}
	

	void Update () {

		if (shopcode.isvisible == true) {
			Destroy (gameObject);
		}

		if (justonce == true) {
			///Ragdoll movement
			if (guntype == "glock" || guntype == "baretta" || guntype == "cz75" || guntype == "auto") {
				gunforce = Random.Range (10, 60);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "revolver") {
				gunforce = Random.Range (250, 300);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "mac10" || guntype == "mp5" || guntype == "spectre" || guntype == "ump" || guntype == "p90") {
				gunforce = Random.Range (50, 200);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "xm8") {
				gunforce = Random.Range (100, 150);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "gali" || guntype == "famas" || guntype == "sg") {
				gunforce = Random.Range (200, 250);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "m4a1") {
				gunforce = Random.Range (50, 250);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "m32") {
				explosionforce = explosionxpos - transform.position.x;
				explosiontotal = explosiontotal / explosionforce;
				torso.AddForce (new Vector2 (-explosiontotal, -explosiontotal));
			}
			if (guntype == "bazooka") {
				explosionforce = explosionxpos - transform.position.x;
				explosiontotal = explosiontotal / explosionforce;
				torso.AddForce (new Vector2 (-explosiontotal, -explosiontotal));
			}
			if (guntype == "grenade") {
				explosionforce = explosionxpos - transform.position.x;
				explosiontotal = explosiontotal / explosionforce;
				torso.AddForce (new Vector2 (-explosiontotal, -explosiontotal));
			}
			if (guntype == "m4a1") {
				gunforce = Random.Range (50, 250);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "bessy") {
				gunforce = Random.Range (100, 300);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "laser") {
				gunforce = Random.Range (50, 100);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "handturret") {
				gunforce = Random.Range (300, 350);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "shotgun") {
				gunforce = Random.Range (50, 250);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, -gunforce));
				}
			}
			if (guntype == "mega") {
				gunforce = Random.Range (550, 1250);
				if (direction == true) {
					torso.AddForce (new Vector2 (gunforce, gunforce));
				}
				if (direction == false) {
					torso.AddForce (new Vector2 (-gunforce, gunforce));
				}
				headR.gravityScale = 0;
				frontarmR.gravityScale = 0;
				torso.gravityScale = 0;
				behindarmR.gravityScale = 0;
				behindlegR.gravityScale = 0;
				frontlegR.gravityScale = 0;
			}

			GetComponent<SpriteRenderer> ().sortingOrder += maincode.increaseorder;
			justonce = false;

		}

	}


	void audiodying() {

		audioroll = Random.Range (0, 10);

		//audioroll = 0;

		if (audioroll == 0) {
			soundplayer.PlayOneShot (growl1, 0.7f);
		}
		if (audioroll == 1) {
			soundplayer.PlayOneShot (growl2, 0.7f);
		}
		if (audioroll == 2) {
			soundplayer.PlayOneShot (growl3, 0.7f);
		}
		if (audioroll == 3) {
			soundplayer.PlayOneShot (growl4, 0.7f);
		}
		if (audioroll == 4) {
			soundplayer.PlayOneShot (growl5, 0.7f);
		}
		if (audioroll == 5) {
			soundplayer.PlayOneShot (growl6, 0.7f);
		}
		if (audioroll == 6) {
			soundplayer.PlayOneShot (growl7, 0.7f);
		}
		if (audioroll == 7) {
			soundplayer.PlayOneShot (growl8, 0.7f);
		}
		if (audioroll == 8) {
			soundplayer.PlayOneShot (growl9, 0.7f);
		}
		if (audioroll == 9) {
			soundplayer.PlayOneShot (growl10, 0.7f);
		}
	}
}
