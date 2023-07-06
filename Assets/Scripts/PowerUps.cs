using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	private ShootingGuns shootingcode;
	private Shop shopcode;
	private Main maincode;

	public int roll;
	public Sprite[] mysprites;
	public int min; 
	public int max; 
	public GameObject fireworks;
	public int changer;
	public GameObject mypos;

	public AudioClip powerupsound;

	void Start () {
		mypos = GameObject.Find ("Main Camera");
		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		shootingcode = GameObject.Find ("ArmGun").GetComponent<ShootingGuns> ();
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		////
		min = 0;
		max = 99;
		roll = Random.Range (min, max);
		if (roll < 50) {
			changer = 0;
		}
		if (roll >= 50 && roll <= 60) {
			changer = 1;
		}
		if (roll >= 61) {
			changer = 2;
		}
		GetComponent<SpriteRenderer> ().sprite = mysprites [changer];

	}
	

	void Update () {
		if (shopcode.isvisible == true) {
			Destroy (gameObject);
		}
	}


	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			///Ammo
			if (changer == 0) {
				shootingcode.resetammo2 ();
			}
			///slow mo
			if (changer == 1) {
				maincode.slowmotimeractive = true;
				Time.timeScale = 0.4f;
			}
			///Mass Kill
			if (changer == 2) {
				maincode.killthemall = true;
			}
			AudioSource.PlayClipAtPoint (powerupsound, mypos.transform.position);
			Instantiate (fireworks, transform.position, transform.rotation);
			Destroy (gameObject);

		}
	}
}
