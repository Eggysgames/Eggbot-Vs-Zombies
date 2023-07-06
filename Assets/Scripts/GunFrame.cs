using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunFrame : MonoBehaviour {

	private Character playercode;
	private ShootingGuns shootingcode;
	private GunUISprites grenadescode;
	private Main maincode;
	private bool hittingplayer;
	private float nearby;
	private Rigidbody2D player;
	private Color mycolour; 
	private float colourfade;

	public bool grenadesOn; 
	public int framegun; 
	public Text overlaytext;
	public Text overlaytext2;
	public int cost; 
	public GameObject smokepuff;

	public AudioSource chaching;

	void Start () {
		grenadescode = GameObject.Find ("GrenadesUI").GetComponent<GunUISprites> ();
		shootingcode = GameObject.Find ("ArmGun").GetComponent<ShootingGuns> ();
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		player = GameObject.Find ("EggHead").GetComponent<Rigidbody2D> ();
		playercode = GameObject.Find ("EggHead").GetComponent<Character> ();
		mycolour = overlaytext.GetComponent<Text> ().color;
		mycolour.a = 1f;
	}

	void Update () {

		if (Input.GetButtonDown ("Activate") && maincode.gamemoney >= cost && hittingplayer == true && shootingcode.reloading == false && playercode.imdying == false) {

			maincode.gamemoney -= cost;
			maincode.UpdateText ();
			chaching.Play ();
			///setgun
			if (grenadesOn == false) {
				shootingcode.primary = framegun;
				shootingcode.GunUISpritescode.guntype = framegun;
				shootingcode.GunUISpritescode.switchweapons ();
				shootingcode.switchtheguntype ();
				shootingcode.resetammo ();
				Instantiate (smokepuff, transform.position, transform.rotation);
			}

			if (grenadesOn == true) {
				if (framegun == 17) {
					shootingcode.grenadeamount = 5; 
					shootingcode.grenadesui.SetActive (true);
					shootingcode.grenadeamountui.text = "x" + shootingcode.grenadeamount;
					shootingcode.grenadetype = "hegrenade";
					//
					grenadescode.guntype = 17;
					grenadescode.switchweapons ();
					Instantiate (smokepuff, transform.position, transform.rotation);
				}
				if (framegun == 18) {
					shootingcode.grenadeamount = 5; 
					shootingcode.grenadetype = "molotov";
					shootingcode.grenadesui.SetActive (true);
					shootingcode.grenadeamountui.text = "x" + shootingcode.grenadeamount;
					//
					grenadescode.guntype = 18;
					grenadescode.switchweapons ();
					Instantiate (smokepuff, transform.position, transform.rotation);

				}



			}

		}

		nearby = Vector2.Distance (transform.position, player.transform.position);

		if (nearby < 0.8) {
			colourfade = 1f;
			colourreset ();
			mycolour.a = colourfade;
			overlaytext.GetComponent<Text> ().color = mycolour;
			overlaytext2.GetComponent<Text> ().color = mycolour;
			hittingplayer = true;
		}
		if (nearby >= 0.8) {
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


}
