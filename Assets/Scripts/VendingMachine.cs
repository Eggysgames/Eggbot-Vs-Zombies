using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VendingMachine : MonoBehaviour {

	private ShootingGuns shootingcode;
	private Character playercode;
	private Main maincode;
	private bool hittingplayer;
	private float nearby;
	private Rigidbody2D player;
	private Color mycolour; 
	private float colourfade;

	public GameObject ExtraLife;
	public bool isGlocksRUs;
	public bool isHealthCentre;
	public bool isReviveOMatic;
	public int framegun; 
	public Text overlaytext;
	public int cost; 
	public GameObject hearts;
	public GameObject smokepuff;
	public GameObject lifeeffect;
	public GameObject explosion;
	public int reviveamounts; 

	public AudioSource soundplayer;

	public AudioClip glocksound;
	public AudioClip healthsound;
	public AudioClip revivesound;

	void Start () {
		shootingcode = GameObject.Find ("ArmGun").GetComponent<ShootingGuns> ();
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		player = GameObject.Find ("EggHead").GetComponent<Rigidbody2D> ();
		playercode = GameObject.Find ("EggHead").GetComponent<Character> ();
		mycolour = overlaytext.GetComponent<Text> ().color;
		mycolour.a = 1f;
	}

	void Update () {

		if (Input.GetButtonDown ("Activate") && maincode.gamemoney >= cost && hittingplayer == true) {

			if (isGlocksRUs) {
				if (shootingcode.primary != 0) {
					soundplayer.PlayOneShot (glocksound, 0.7f); 
					shootingcode.primary = framegun;
					shootingcode.GunUISpritescode.guntype = framegun;
					shootingcode.GunUISpritescode.switchweapons ();
					shootingcode.switchtheguntype ();
					shootingcode.resetammo ();
					////
					maincode.gamemoney -= cost;
					maincode.UpdateText ();
					//
					Instantiate (smokepuff, transform.position, transform.rotation);
				}
			}
			if (isHealthCentre) {
				if (playercode.currenthealth != 100) {
					maincode.gamemoney -= cost;
					maincode.UpdateText ();
					soundplayer.PlayOneShot (healthsound, 0.7f); 
					playercode.currenthealth = 100; 
					playercode.uiupdate ();
					Instantiate (hearts, transform.position, transform.rotation);
				}
			}
			if (isReviveOMatic) {
				if (ExtraLife.activeSelf == false) {
					maincode.gamemoney -= cost;
					maincode.UpdateText ();
					soundplayer.PlayOneShot (revivesound, 0.7f); 
					ExtraLife.SetActive (true);
					Instantiate (lifeeffect, transform.position, transform.rotation);
					reviveamounts -= 1; 
					if (reviveamounts <= 0) {
						Instantiate (explosion, transform.position, transform.rotation);
						this.gameObject.SetActive (false);
					}
				}
			}
		}

		nearby = Vector2.Distance (transform.position, player.transform.position);

		if (nearby < 0.8) {
			colourfade = 1f;
			colourreset ();
			mycolour.a = colourfade;
			overlaytext.GetComponent<Text> ().color = mycolour;
			hittingplayer = true;
		}
		if (nearby >= 0.8) {
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
