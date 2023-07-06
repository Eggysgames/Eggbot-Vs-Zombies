using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


	private Rigidbody2D projectile; 
	private int removetimer;

	public int speed; 
	public GameObject explosion;
	public GameObject smallexplosion;
	public GameObject molotovfire;
	public bool isRocket; 
	public bool isGrenade;
	public bool isMolotov;
	public bool justonce;
	public GameObject mypos;

	public AudioSource soundplayer;

	public AudioClip smashsound;
	public AudioClip bangsound;
	public AudioClip bigbangsound;

	void Start () {
		mypos = GameObject.Find ("Main Camera");
		justonce = true;
		projectile = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		if (isRocket) {
			projectile.AddForce (transform.right * speed);
			removetimer++;
			if (removetimer >= 100) {
				AudioSource.PlayClipAtPoint (bigbangsound, mypos.transform.position);
				Instantiate (smallexplosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		if (isGrenade) {
			if (justonce) {
				projectile.AddForce (transform.right * speed);
				justonce = false;
			}
			removetimer++;
			if (removetimer >= 100) {
				AudioSource.PlayClipAtPoint (bangsound, mypos.transform.position);
				Instantiate (smallexplosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		if (isMolotov) {
			if (justonce) {
				projectile.AddForce (transform.right * speed);
				justonce = false;
			}
			removetimer++;
			if (removetimer >= 200) {
				AudioSource.PlayClipAtPoint (smashsound, mypos.transform.position);
				Instantiate (smallexplosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}


	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "CrabEnemy") {
			if (isRocket) {
				AudioSource.PlayClipAtPoint (bigbangsound, mypos.transform.position);
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
			if (isGrenade) {
				AudioSource.PlayClipAtPoint (bangsound, mypos.transform.position);
				Instantiate (smallexplosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		if (col.gameObject.layer == 8) {
			if (isRocket) {
				AudioSource.PlayClipAtPoint (bigbangsound, mypos.transform.position);
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}

		}
		if (col.gameObject.tag == "Bottom") {
			if (isRocket) {
				AudioSource.PlayClipAtPoint (bigbangsound, mypos.transform.position);
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
			if (isMolotov) {
				AudioSource.PlayClipAtPoint (smashsound, mypos.transform.position);
				Instantiate (molotovfire, transform.position, molotovfire.transform.rotation);
				Destroy (gameObject);
			}
		}
		if (col.gameObject.tag == "NoDecal") {
			if (isRocket) {
				AudioSource.PlayClipAtPoint (bigbangsound, mypos.transform.position);
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}



}
