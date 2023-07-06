using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShootingGuns : MonoBehaviour {

	private Shop shopcode;
	private Rigidbody2D pieces; 
	private Character playercode; 
	private LineRenderer laserLine;
	private LineRenderer laserLine2;
	private LineRenderer laserLine3;
	private Fading fadingendcode;
	private Vector3 offset; 
	private Vector3 offset2; 
	private Vector3 offset3; 
	private string guntype = "glock";
	public string grenadetype = "hegrenade";
	private Zombie zombieCode; 
	private Enemy enemyCode; 
	private Extra extraCode;
	private float shootspeed; 
	private int holder;
	private int equippedshootspeed;
	private int clipsize;
	public bool reloading = false;
	private Image barvis;
	private float barwidth;
	private float bartaker;
	private int switchholder; 
	private Gunvariables gunvariables;
	private int currentammoholder;
	private int ammoleftholder;
	private Transform sightholder;
	private int roll; 
	private float reloadspeed; 
	private int gundamage; 
	private bool hideatstart; 
	//
	private Animator glockanimator; 
	private Animator barettaanimator; 
	private Animator cz75animator;
	private Animator autoanimator;
	private Animator revolveranimator;
	private Animator mac10animator;
	private Animator mp5animator;
	private Animator spectreanimator;
	private Animator umpanimator;
	private Animator p90animator;
	private Animator xm8animator;
	private Animator galianimator;
	private Animator famasanimator;
	private Animator sganimator;
	private Animator m4a1animator;
	private Animator m32animator;
	private Animator bazookaanimator;
	private Animator awpanimator;
	private Animator bessyanimator;
	//private Animator laseranimator;
	private Animator bigsniperanimator;
	private Animator handturretanimator;
	private Animator shotgunanimator;
	//private Animator megaanimator;
	private float myrandom;
	private int quicktimer;

	public GameObject uiguns; 
	public GameObject bullethole;
	public int primary = 0;
	public int secondary = 0;
	public GameObject player;

	public int grenadeamount;
	public Text grenadeamountui; 
	public GameObject grenadesui;

	public Transform glocksight; 
	public Transform barettasight;
	public Transform cz75sight;
	public Transform autosight;
	public Transform revolversight;
	public Transform mac10sight;
	public Transform mp5sight;
	public Transform spectresight;
	public Transform umpsight;
	public Transform p90sight;
	public Transform xm8sight;
	public Transform galisight;
	public Transform famassight;
	public Transform sgsight;
	public Transform m4a1sight;
	public Transform m32sight;
	public Transform bazookasight;
	public Transform awpsight;
	public Transform bessysight;
	public Transform lasersight;
	public Transform bigsnipersight;
	public Transform handturretsight;
	public Transform shotgunsight;
	public Transform megasight;
	//
	public Transform glockmuzzleflash;
	public Transform barettamuzzleflash;
	public Transform cz75muzzleflash;
	public Transform automuzzleflash;
	public Transform revolvermuzzleflash;
	public Transform mac10muzzleflash;
	public Transform mp5muzzleflash;
	public Transform spectremuzzleflash;
	public Transform umpmuzzleflash;
	public Transform p90muzzleflash;
	public Transform xm8muzzleflash;
	public Transform galimuzzleflash;
	public Transform famasmuzzleflash;
	public Transform sgmuzzleflash;
	public Transform m4a1muzzleflash;
	public Transform m32muzzleflash;
	public Transform bazookamuzzleflash;
	public Transform awpmuzzleflash;
	public Transform bessymuzzleflash;
	public Transform lasermuzzleflash;
	public Transform bigsnipermuzzleflash;
	public Transform handturretmuzzleflash;
	public Transform shotgunmuzzleflash;
	public Transform megamuzzleflash;

	public Transform egghead;
	public Transform ricochet;
	public Transform ricochetBlood;
	public Transform bloodsplatter1;
	public Transform bloodsplatter2;
	public Transform bloodsplatter3;
	public GameObject glock; 
	public GameObject baretta;
	public GameObject cz75;
	public GameObject auto;
	public GameObject revolver;
	public GameObject mac10;
	public GameObject mp5;
	public GameObject spectre;
	public GameObject ump;
	public GameObject p90;
	public GameObject xm8;
	public GameObject gali;
	public GameObject famas;
	public GameObject sg;
	public GameObject m4a1;
	public GameObject m32;
	public GameObject bazooka;
	public GameObject rocket; 
	public GameObject grenade;
	public GameObject molotov;
	public GameObject awp;
	public GameObject bessy;
	public GameObject laser;
	public GameObject bigsniper; 
	public GameObject handturret;
	public GameObject shotgun;
	public GameObject mega;
	public GameObject megaeffect;

	public AudioSource soundplayer;

	public AudioClip glocksound;
	public AudioClip barettasound;
	public AudioClip autosound;
	public AudioClip cz75sound;
	public AudioClip revolversound;
	public AudioClip mac10sound;
	public AudioClip mp5sound;
	public AudioClip spectresound;
	public AudioClip umpsound;
	public AudioClip p90sound;
	public AudioClip xm8sound;
	public AudioClip galisound;
	public AudioClip famassound;
	public AudioClip sgsound;
	public AudioClip m4a1sound;
	public AudioClip m32sound;
	public AudioClip rocketsound;
	public AudioClip awpsound;
	public AudioClip bigbessysound;
	public AudioClip lasersound;
	public AudioClip bigsnipersound;
	public AudioClip handturretsound;
	public AudioClip shotgunsound;
	public AudioClip megasound;

	public AudioClip changeweapons;

	public Transform reloadbar;
	public Text currentammoui;
	public Text gunname;
	public LayerMask mylayermask;
	public int currentammo = 8;
	public int ammoleft = 99999;
	public int currentammoholder2 = 8;
	public int ammoleftholder2 = 99999;
	[HideInInspector] public GunUISprites GunUISpritescode; 
	[HideInInspector] public GunUISprites GunUISpritescode2;

	public Texture2D cursortexture;
	public Vector2 hotspot;


	public GameObject crosshair;

	void Start() {



		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		playercode = GameObject.Find ("EggHead").GetComponent<Character> ();
		gunvariables = GameObject.Find ("Main Camera").GetComponent<Gunvariables> ();
		GunUISpritescode = GameObject.Find ("GunsUIPrimary").GetComponent<GunUISprites> ();
		GunUISpritescode2 = GameObject.Find ("GunsUISecondary").GetComponent<GunUISprites> ();
		fadingendcode = GameObject.Find ("FadingEnd").GetComponent<Fading> ();

		glockanimator = glock.GetComponent<Animator> ();
		barettaanimator = baretta.GetComponent<Animator> ();
		cz75animator = cz75.GetComponent<Animator> ();
		autoanimator = auto.GetComponent<Animator> ();
		revolveranimator = revolver.GetComponent<Animator> ();
		mac10animator = mac10.GetComponent<Animator> ();
		mp5animator = mp5.GetComponent<Animator> ();
		spectreanimator = spectre.GetComponent<Animator> ();
		umpanimator = ump.GetComponent<Animator> ();
		p90animator = p90.GetComponent<Animator> ();
		xm8animator = xm8.GetComponent<Animator> ();
		galianimator = gali.GetComponent<Animator> ();
		famasanimator = famas.GetComponent<Animator> ();
		sganimator = sg.GetComponent<Animator> ();
		m4a1animator = m4a1.GetComponent<Animator> ();
		m32animator = m32.GetComponent<Animator> ();
		bazookaanimator = bazooka.GetComponent<Animator> ();
		awpanimator = awp.GetComponent<Animator> ();
		bessyanimator = bessy.GetComponent<Animator> ();
		bigsniperanimator = bigsniper.GetComponent<Animator> ();
		handturretanimator = handturret.GetComponent<Animator> ();
		shotgunanimator = shotgun.GetComponent<Animator> ();
		//megaanimator = mega.GetComponent<Animator> ();

		barvis = reloadbar.GetComponent<Image> ();
		barvis.enabled = false;
		barwidth = reloadbar.transform.localScale.x;
		glockmuzzleflash.GetComponent<SpriteRenderer>().enabled = false;

		laserLine = GetComponent<LineRenderer>();
		laserLine2 = GameObject.Find ("MyLine2").GetComponent<LineRenderer> ();
		laserLine3 = GameObject.Find ("MyLine3").GetComponent<LineRenderer> ();
		laserLine.enabled = false;
		laserLine2.enabled = false;
		laserLine3.enabled = false;

		currentammoui.text = currentammo.ToString () + " / " + "\u221E";
		hideguns ();
		glock.SetActive (true);
		sightholder = glocksight;
		hideatstart = true; 
		megaeffect.SetActive (false);
		///temp gun change
		////////////
//		awp.SetActive (true);
//		guntype = "awp";
//		primary = 19; 
//		GunUISpritescode.guntype = primary;
//		GunUISpritescode.switchweapons ();
//		gunname.text = guntype;
		/////////////////
	}

	void LateUpdate() {
		RotateArm ();
	}
	void Update() { 

	
		if (shopcode.isvisible == false && playercode.currenthealth > 0 && fadingendcode.paused == false) {
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = crosshair.transform.position.z - Camera.main.transform.position.z;
			crosshair.transform.position = Camera.main.ScreenToWorldPoint (mousePos);
			Cursor.visible = false;
			crosshair.SetActive (true);
		}
		if (shopcode.isvisible == true || playercode.currenthealth <= 0 || fadingendcode.paused == true) {
			crosshair.SetActive (false);
			Cursor.visible = true;
		}
		//
		RotateArm ();
		Shooting ();
		if (reloading == false) {
			switchweapons ();
		}
		myReloading ();
		throwgrenade ();
		///
		if (hideatstart == true) {
			uiguns.SetActive (false);
			hideatstart = false;
		}
	}
		
	void RotateArm() {
		if (Time.timeScale != 0) {
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 0f;

			Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
			mousePos.x = mousePos.x - objectPos.x;
			mousePos.y = mousePos.y - objectPos.y;

			float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;

			if (transform.localScale.x > 0) {
				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
			}
			if (transform.localScale.x < 0) {
				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
			}
		}
	}

	public void throwgrenade() {
		if (Input.GetButtonDown ("Throw")) {
			
			if (grenadetype == "hegrenade") {
				if (grenadeamount > 0) {
					Instantiate (grenade, sightholder.position, transform.rotation); 
					grenadeamount -= 1;
					grenadeamountui.text = "x" + grenadeamount;
				}
			}

			if (grenadetype == "molotov") {
				if (grenadeamount > 0) {
					Instantiate (molotov, sightholder.position, transform.rotation); 
					grenadeamount -= 1;
					grenadeamountui.text = "x" + grenadeamount;
				}

			}
				
			if (grenadeamount <= 0) {
				grenadesui.SetActive (false);
			}

		}

	}

	public void Shooting() {

		if (Input.GetMouseButtonUp(0)) {
			if (guntype == "mega") {
				megaeffect.SetActive (false);
			}
		}

		if (Input.GetMouseButton (0) && playercode.myrenderer == true && currentammo != 0 && shopcode.isvisible == false && Time.timeScale != 0 && reloading == false) {
			if (shootspeed <= 0) {



				gunmanager ();

				if (guntype == "m32") {
					Instantiate (grenade, sightholder.position, transform.rotation); 
					shootspeed = equippedshootspeed; 
				}


				if (guntype == "bazooka") {
					Instantiate (rocket, sightholder.position, transform.rotation); 
					shootspeed = equippedshootspeed; 
				}

				if (guntype == "mega") {
					megaeffect.SetActive (true);
				}

				if (guntype != "m32" && guntype != "bazooka") {
					//sniper fires
					if (guntype == "awp" || guntype == "bigsniper") {
						
						RaycastHit2D[] hitall = Physics2D.RaycastAll(sightholder.position, offset * 2, 10, mylayermask);

						for (int i = 0; i < hitall.Length; i++) {
							if (hitall [i].collider != null && hitall [i].transform.gameObject.layer == 9 && hitall [i].transform.gameObject.tag != "Dead") { 
								//Shoot heaps of zombie					
								Instantiate (ricochetBlood, hitall [i].point, transform.rotation);
								roll = Random.Range (1, 4);
								if (roll == 1) {
									Instantiate (bloodsplatter1, hitall [i].point, transform.rotation); 
								}
								if (roll == 2) {
									Instantiate (bloodsplatter2, hitall [i].point, transform.rotation); 
								}
								if (roll == 3) {
									Instantiate (bloodsplatter3, hitall [i].point, transform.rotation); 
								}

								//Damage
								if (hitall[i].transform.gameObject.tag == "Extra") {
									extraCode = hitall [i].transform.gameObject.GetComponent<Extra> ();
									if (extraCode.dying == false) {

										extraCode.bodydamage = gundamage; 
										extraCode.extraactive ();
										Instantiate (ricochet, hitall [i].point, transform.rotation); 
									}
								}

								if (hitall[i].transform.gameObject.tag == "CrabEnemy") {
									enemyCode = hitall [i].transform.gameObject.GetComponent<Enemy> ();
									if (enemyCode.dying == false) {

										enemyCode.bodydamage = gundamage; 

										if (hitall [i].collider.GetType () == typeof(CircleCollider2D)) {
											enemyCode.store = 1;
										}
										if (hitall [i].collider.GetType () == typeof(BoxCollider2D)) {
											enemyCode.store = 2; 
										}
										enemyCode.guntype = guntype;

										enemyCode.Damaged ();
									}
								}
								if (hitall [i].transform.gameObject.tag == "Enemy") {
									zombieCode = hitall [i].transform.gameObject.GetComponent<Zombie> ();
									if (zombieCode.dying == false) {
										
										zombieCode.bodydamage = gundamage; 

										if (hitall [i].collider.GetType () == typeof(CircleCollider2D)) {
											zombieCode.store = 1;
										}
										if (hitall [i].collider.GetType () == typeof(BoxCollider2D)) {
											zombieCode.store = 2; 
										}
										zombieCode.guntype = guntype;

										zombieCode.Damaged ();
									}
								}

							}

							if (hitall [i].transform.gameObject.layer == 8) {
								Instantiate (ricochet, hitall [i].point, transform.rotation); 
								if (hitall [i].collider.tag != "NoDecal") {
									Instantiate (bullethole, hitall [i].point, transform.rotation); 
								}
								laserLine.enabled = true;

								laserLine.SetPosition (0, sightholder.position);
								laserLine.SetPosition (1, hitall [i].point);
								break;
							}
							if (hitall [i].collider != null && hitall [i].transform.gameObject.tag == "Little" && hitall [i].transform.gameObject.tag != "Dead") {   

								//Move little bits
								pieces = hitall [i].transform.gameObject.GetComponent<Rigidbody2D> ();
								if (player.transform.position.x < transform.position.x) {
									pieces.AddForce (new Vector2 (-20, 5));
								}
								if (player.transform.position.x > transform.position.x) {
									pieces.AddForce (new Vector2 (20, 5));
								}
								Instantiate (ricochet, hitall [i].point, transform.rotation); 

								GameObject temp = Instantiate (bullethole, hitall [i].point, transform.rotation); 
								temp.transform.parent = hitall [i].transform;

								laserLine.enabled = true;
								laserLine.SetPosition (0, sightholder.position);
								laserLine.SetPosition (1, hitall [i].point);
								break;
							}
						}

						if (laserLine.enabled == false) {
							laserLine.enabled = true;
							laserLine.SetPosition (0, sightholder.position);
							laserLine.SetPosition (1, offset * 8 + transform.position);
						}

						shootspeed = equippedshootspeed; 

						if (shootspeed == equippedshootspeed + 10) {
							turnoffmuzzleflashes ();
							laserLine.enabled = false;
						}
						shootspeed--; 
					}



					if (guntype != "awp" && guntype != "bigsniper" && guntype != "mega") {


						RaycastHit2D hit = Physics2D.Raycast (sightholder.position, offset*2, 10, mylayermask);

						if (hit.collider != null && hit.transform.gameObject.layer == 8 && hit.transform.gameObject.tag != "Little" && hit.transform.gameObject.tag != "Dead") {    

							///Shoot line into ground
							Instantiate (ricochet, hit.point, transform.rotation); 

							///Bullet Holes
							if (hit.collider.tag != "NoDecal") {
								Instantiate (bullethole, hit.point, transform.rotation); 
							}

							laserLine.enabled = true;
							laserLine.SetPosition (0, sightholder.position);
							laserLine.SetPosition (1, hit.point);

						} else if (hit.collider != null && hit.transform.gameObject.tag == "Little" && hit.transform.gameObject.tag != "Dead") {                     
							///Shoot line into pieces
							Instantiate (ricochet, hit.point, transform.rotation); 

							GameObject temp = Instantiate (bullethole, hit.point, transform.rotation); 
							temp.transform.parent = hit.transform;

							laserLine.enabled = true;
							laserLine.SetPosition (0, sightholder.position);
							laserLine.SetPosition (1, hit.point);


							//Move little bits
							pieces = hit.transform.gameObject.GetComponent<Rigidbody2D> ();
							if (player.transform.position.x < transform.position.x) {
								pieces.AddForce (new Vector2 (-20, 5));
							}
							if (player.transform.position.x > transform.position.x) {
								pieces.AddForce (new Vector2 (20, 5));
							}

						} else if (hit.collider != null && hit.transform.gameObject.layer == 9 && hit.transform.gameObject.tag != "Dead") { 

							//&& hit.transform.GetComponent<SpriteRenderer> ().color.a >= 0.8
							//Shoot zombie
							Instantiate (ricochetBlood, hit.point, transform.rotation);

							roll = Random.Range (1, 4);
							if (roll == 1) {
								Instantiate (bloodsplatter1, hit.point, transform.rotation); 
							}
							if (roll == 2) {
								Instantiate (bloodsplatter2, hit.point, transform.rotation); 
							}
							if (roll == 3) {
								Instantiate (bloodsplatter3, hit.point, transform.rotation); 
							}

							laserLine.enabled = true;
							laserLine.SetPosition (0, sightholder.position);
							laserLine.SetPosition (1, hit.point);

							//Damage
							if (hit.transform.gameObject.tag == "Extra") {

								extraCode = hit.transform.gameObject.GetComponent<Extra> ();
								if (extraCode.dying == false) {

									extraCode.bodydamage = gundamage; 
									extraCode.extraactive ();
									Instantiate (ricochet, hit.point, transform.rotation); 
								}
							}

							if (hit.transform.gameObject.tag == "CrabEnemy") {
								
								enemyCode = hit.transform.gameObject.GetComponent<Enemy> ();
								enemyCode.bodydamage = gundamage; 

								if (hit.collider.GetType () == typeof(CircleCollider2D)) {
									enemyCode.store = 1;
								}
								if (hit.collider.GetType () == typeof(BoxCollider2D)) {
									enemyCode.store = 2; 
								}
								enemyCode.guntype = guntype;

								enemyCode.Damaged ();
							}
							if (hit.transform.gameObject.tag == "Enemy") {
								zombieCode = hit.transform.gameObject.GetComponent<Zombie> ();
								zombieCode.bodydamage = gundamage; 

								if (hit.collider.GetType () == typeof(CircleCollider2D)) {
									zombieCode.store = 1;
								}
								if (hit.collider.GetType () == typeof(BoxCollider2D)) {
									zombieCode.store = 2; 
								}
								zombieCode.guntype = guntype;

								zombieCode.Damaged ();
							}

						} else {
							//Shoot my line into sky
							laserLine.enabled = true;
							laserLine.SetPosition (0, sightholder.position);
							laserLine.SetPosition (1, offset * 8 + transform.position);
						}


						/////
						if (guntype == "shotgun") {
							RaycastHit2D hit2 = Physics2D.Raycast (sightholder.position, offset2 * 2, 10, mylayermask);

							if (hit2.collider != null && hit2.transform.gameObject.layer == 8 && hit2.transform.gameObject.tag != "Little" && hit2.transform.gameObject.tag != "Dead") {    

								///Shoot line into ground
								Instantiate (ricochet, hit2.point, transform.rotation); 

								///Bullet Holes
								if (hit2.collider.tag != "NoDecal") {
									Instantiate (bullethole, hit2.point, transform.rotation); 
								}

								laserLine2.enabled = true;
								laserLine2.SetPosition (0, sightholder.position);
								laserLine2.SetPosition (1, hit2.point);

							} else if (hit2.collider != null && hit2.transform.gameObject.tag == "Little" && hit2.transform.gameObject.tag != "Dead") {                     
								///Shoot line into pieces
								Instantiate (ricochet, hit2.point, transform.rotation); 

								GameObject temp = Instantiate (bullethole, hit2.point, transform.rotation); 
								temp.transform.parent = hit2.transform;

								laserLine2.enabled = true;
								laserLine2.SetPosition (0, sightholder.position);
								laserLine2.SetPosition (1, hit2.point);


								//Move little bits
								pieces = hit2.transform.gameObject.GetComponent<Rigidbody2D> ();
								if (player.transform.position.x < transform.position.x) {
									pieces.AddForce (new Vector2 (-20, 5));
								}
								if (player.transform.position.x > transform.position.x) {
									pieces.AddForce (new Vector2 (20, 5));
								}

							} else if (hit2.collider != null && hit2.transform.gameObject.layer == 9 && hit2.transform.gameObject.tag != "Dead") { 

								//&& hit.transform.GetComponent<SpriteRenderer> ().color.a >= 0.8
								//Shoot zombie
								Instantiate (ricochetBlood, hit2.point, transform.rotation);

								roll = Random.Range (1, 4);
								if (roll == 1) {
									Instantiate (bloodsplatter1, hit2.point, transform.rotation); 
								}
								if (roll == 2) {
									Instantiate (bloodsplatter2, hit2.point, transform.rotation); 
								}
								if (roll == 3) {
									Instantiate (bloodsplatter3, hit2.point, transform.rotation); 
								}

								laserLine2.enabled = true;
								laserLine2.SetPosition (0, sightholder.position);
								laserLine2.SetPosition (1, hit2.point);

								//Damage
								//Damage
								if (hit2.transform.gameObject.tag == "Extra") {
									extraCode = hit2.transform.gameObject.GetComponent<Extra> ();
									if (extraCode.dying == false) {

										extraCode.bodydamage = gundamage; 
										extraCode.extraactive ();
										Instantiate (ricochet, hit2.point, transform.rotation); 
									}
								}

								if (hit2.transform.gameObject.tag == "CrabEnemy") {

									enemyCode = hit2.transform.gameObject.GetComponent<Enemy> ();
									enemyCode.bodydamage = gundamage; 

									if (hit2.collider.GetType () == typeof(CircleCollider2D)) {
										enemyCode.store = 1;
									}
									if (hit2.collider.GetType () == typeof(BoxCollider2D)) {
										enemyCode.store = 2; 
									}
									enemyCode.guntype = guntype;

									enemyCode.Damaged ();
								}
								if (hit2.transform.gameObject.tag == "Enemy") {
									zombieCode = hit2.transform.gameObject.GetComponent<Zombie> ();
									zombieCode.bodydamage = gundamage; 

									if (hit2.collider.GetType () == typeof(CircleCollider2D)) {
										zombieCode.store = 1;
									}
									if (hit2.collider.GetType () == typeof(BoxCollider2D)) {
										zombieCode.store = 2; 
									}
									zombieCode.guntype = guntype;

									zombieCode.Damaged ();
								}

							} else {
								//Shoot my line into sky
								laserLine2.enabled = true;
								laserLine2.SetPosition (0, sightholder.position);
								laserLine2.SetPosition (1, offset2 * 8 + transform.position);
							}
						}
						if (guntype == "shotgun") {
							//3rd 
							RaycastHit2D hit3 = Physics2D.Raycast (sightholder.position, offset3 * 2, 10, mylayermask);

							if (hit3.collider != null && hit3.transform.gameObject.layer == 8 && hit3.transform.gameObject.tag != "Little" && hit3.transform.gameObject.tag != "Dead") {    

								///Shoot line into ground
								Instantiate (ricochet, hit3.point, transform.rotation); 

								///Bullet Holes
								if (hit3.collider.tag != "NoDecal") {
									Instantiate (bullethole, hit3.point, transform.rotation); 
								}

								laserLine3.enabled = true;
								laserLine3.SetPosition (0, sightholder.position);
								laserLine3.SetPosition (1, hit3.point);

							} else if (hit3.collider != null && hit3.transform.gameObject.tag == "Little" && hit3.transform.gameObject.tag != "Dead") {                     
								///Shoot line into pieces
								Instantiate (ricochet, hit3.point, transform.rotation); 

								GameObject temp = Instantiate (bullethole, hit3.point, transform.rotation); 
								temp.transform.parent = hit3.transform;

								laserLine3.enabled = true;
								laserLine3.SetPosition (0, sightholder.position);
								laserLine3.SetPosition (1, hit3.point);


								//Move little bits
								pieces = hit3.transform.gameObject.GetComponent<Rigidbody2D> ();
								if (player.transform.position.x < transform.position.x) {
									pieces.AddForce (new Vector2 (-20, 5));
								}
								if (player.transform.position.x > transform.position.x) {
									pieces.AddForce (new Vector2 (20, 5));
								}

							} else if (hit3.collider != null && hit3.transform.gameObject.layer == 9 && hit3.transform.gameObject.tag != "Dead") { 

								//&& hit.transform.GetComponent<SpriteRenderer> ().color.a >= 0.8
								//Shoot zombie
								Instantiate (ricochetBlood, hit3.point, transform.rotation);

								roll = Random.Range (1, 4);
								if (roll == 1) {
									Instantiate (bloodsplatter1, hit3.point, transform.rotation); 
								}
								if (roll == 2) {
									Instantiate (bloodsplatter2, hit3.point, transform.rotation); 
								}
								if (roll == 3) {
									Instantiate (bloodsplatter3, hit3.point, transform.rotation); 
								}

								laserLine3.enabled = true;
								laserLine3.SetPosition (0, sightholder.position);
								laserLine3.SetPosition (1, hit3.point);

								//Damage
								if (hit3.transform.gameObject.tag == "Extra") {
									extraCode = hit3.transform.gameObject.GetComponent<Extra> ();
									if (extraCode.dying == false) {

										extraCode.bodydamage = gundamage; 
										extraCode.extraactive ();
										Instantiate (ricochet, hit3.point, transform.rotation); 
									}
								}
								if (hit3.transform.gameObject.tag == "CrabEnemy") {
									enemyCode = hit3.transform.gameObject.GetComponent<Enemy> ();
									enemyCode.bodydamage = gundamage; 

									if (hit3.collider.GetType () == typeof(CircleCollider2D)) {
										enemyCode.store = 1;
									}
									if (hit3.collider.GetType () == typeof(BoxCollider2D)) {
										enemyCode.store = 2; 
									}
									enemyCode.guntype = guntype;

									enemyCode.Damaged ();
								}
								if (hit3.transform.gameObject.tag == "Enemy") {
									zombieCode = hit3.transform.gameObject.GetComponent<Zombie> ();
									zombieCode.bodydamage = gundamage; 

									if (hit3.collider.GetType () == typeof(CircleCollider2D)) {
										zombieCode.store = 1;
									}
									if (hit3.collider.GetType () == typeof(BoxCollider2D)) {
										zombieCode.store = 2; 
									}
									zombieCode.guntype = guntype;

									zombieCode.Damaged ();
								}

							} else {
								//Shoot my line into sky
								laserLine3.enabled = true;
								laserLine3.SetPosition (0, sightholder.position);
								laserLine3.SetPosition (1, offset3 * 8 + transform.position);
							}
						}
						//
						shootspeed = equippedshootspeed; 
					}
				}

			}
			//////

			}
			if (shootspeed == equippedshootspeed - 2) {
				turnoffmuzzleflashes ();
				laserLine.enabled = false;
				laserLine2.enabled = false;
				laserLine3.enabled = false;
				//megaeffect.SetActive (false);
			}
			shootspeed--; 

	}


	public void gunmanager() {

		//all
		laserLine.startColor = Color.white;
		laserLine.endColor = Color.white;

		if (guntype == "glock") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.glockaccuracy, gunvariables.glockaccuracy);
			offset.y += Random.Range (-gunvariables.glockaccuracy, gunvariables.glockaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.glockshootspeed;
			//clipsize
			clipsize = gunvariables.glockclipsize;
			//Shoot anim
			reloadspeed = gunvariables.glockreloadspeed;
			////
			glockanimator.SetTrigger ("shoot"); 
			///Set gun sight
			sightholder = glocksight;
			///Sound

			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (glocksound, 0.7f);


			////muzzleflashs
			glockmuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.glockdamage; 
		}
		if (guntype == "baretta") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.barettaaccuracy, gunvariables.barettaaccuracy);
			offset.y += Random.Range (-gunvariables.barettaaccuracy, gunvariables.barettaaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.barettashootspeed;
			//clipsize
			reloadspeed = gunvariables.barettareloadspeed;
			////
			clipsize = gunvariables.barettaclipsize;
			//Shoot anim
			barettaanimator.SetTrigger ("shoot"); 
			///Set gun sight
			sightholder = barettasight;
			///Sound
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (barettasound, 0.7f);
			////muzzleflashs
			barettamuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.barettadamage; 
		}
		if (guntype == "cz75") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.cz75accuracy, gunvariables.cz75accuracy);
			offset.y += Random.Range (-gunvariables.cz75accuracy, gunvariables.cz75accuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.cz75shootspeed;
			//clipsize
			reloadspeed = gunvariables.cz75reloadspeed;
			////
			clipsize = gunvariables.cz75clipsize;
			//Shoot anim
			cz75animator.SetTrigger ("shoot"); 
			///Set gun sight
			sightholder = cz75sight;
			///Sound
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (cz75sound, 0.7f);
			////muzzleflashs
			cz75muzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.cz75damage; 
		}
		if (guntype == "auto") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.autoaccuracy, gunvariables.autoaccuracy);
			offset.y += Random.Range (-gunvariables.autoaccuracy, gunvariables.autoaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.autoshootspeed;
			//clipsize
			reloadspeed = gunvariables.autoreloadspeed;
			////
			clipsize = gunvariables.autoclipsize;
			//Shoot anim
			autoanimator.SetTrigger ("shoot"); 
			///Set gun sight
			sightholder = autosight;
			///Sound
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (autosound, 0.7f);
			////muzzleflashs
			automuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.autodamage; 
		}
		if (guntype == "revolver") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.revolveraccuracy, gunvariables.revolveraccuracy);
			offset.y += Random.Range (-gunvariables.revolveraccuracy, gunvariables.revolveraccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.revolvershootspeed;
			//clipsize
			reloadspeed = gunvariables.revolverreloadspeed;
			////
			clipsize = gunvariables.revolverclipsize;
			//Shoot anim
			revolveranimator.SetTrigger ("shoot"); 
			///Set gun sight
			sightholder = revolversight;
			///Sound
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (revolversound, 0.7f);
			////muzzleflashs
			revolvermuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.revolverdamage; 
		}
		if (guntype == "mac10") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.mac10accuracy, gunvariables.mac10accuracy);
			offset.y += Random.Range (-gunvariables.mac10accuracy, gunvariables.mac10accuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.mac10shootspeed;
			//clipsize
			reloadspeed = gunvariables.mac10reloadspeed;
			////
			clipsize = gunvariables.mac10clipsize;
			//Shoot anim
			mac10animator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = mac10sight;
			////muzzleflashs
			mac10muzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.mac10damage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (mac10sound, 0.7f); 
		}
		if (guntype == "mp5") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.mp5accuracy, gunvariables.mp5accuracy);
			offset.y += Random.Range (-gunvariables.mp5accuracy, gunvariables.mp5accuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.mp5shootspeed;
			//clipsize
			reloadspeed = gunvariables.mp5reloadspeed;
			////
			clipsize = gunvariables.mp5clipsize;
			//Shoot anim
			mp5animator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = mp5sight;
			////muzzleflashs
			mp5muzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.mp5damage; 
			///
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (mp5sound, 0.7f); 
		}
		if (guntype == "spectre") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.spectreaccuracy, gunvariables.spectreaccuracy);
			offset.y += Random.Range (-gunvariables.spectreaccuracy, gunvariables.spectreaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.spectreshootspeed;
			//clipsize
			reloadspeed = gunvariables.spectrereloadspeed;
			////
			clipsize = gunvariables.spectreclipsize;
			//Shoot anim
			spectreanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = spectresight;
			////muzzleflashs
			spectremuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.spectredamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (spectresound, 0.7f); 
		}
		if (guntype == "ump") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.umpaccuracy, gunvariables.umpaccuracy);
			offset.y += Random.Range (-gunvariables.umpaccuracy, gunvariables.umpaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.umpshootspeed;
			//clipsize
			reloadspeed = gunvariables.umpreloadspeed;
			////
			clipsize = gunvariables.umpclipsize;
			//Shoot anim
			umpanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = umpsight;
			////muzzleflashs
			umpmuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.umpdamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (umpsound, 0.7f); 
		}
		if (guntype == "p90") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.p90accuracy, gunvariables.p90accuracy);
			offset.y += Random.Range (-gunvariables.p90accuracy, gunvariables.p90accuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.p90shootspeed;
			//clipsize
			reloadspeed = gunvariables.p90reloadspeed;
			////
			clipsize = gunvariables.p90clipsize;
			//Shoot anim
			p90animator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = p90sight;
			////muzzleflashs
			p90muzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.p90damage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (p90sound, 0.7f); 
		}
		if (guntype == "xm8") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.xm8accuracy, gunvariables.xm8accuracy);
			offset.y += Random.Range (-gunvariables.xm8accuracy, gunvariables.xm8accuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.xm8shootspeed;
			//clipsize
			reloadspeed = gunvariables.xm8reloadspeed;
			////
			clipsize = gunvariables.xm8clipsize;
			//Shoot anim
			xm8animator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = xm8sight;
			////muzzleflashs
			xm8muzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.xm8damage; 
			///
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (xm8sound, 0.7f); 
		}
		if (guntype == "gali") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.galiaccuracy, gunvariables.galiaccuracy);
			offset.y += Random.Range (-gunvariables.galiaccuracy, gunvariables.galiaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.galishootspeed;
			//clipsize
			reloadspeed = gunvariables.galireloadspeed;
			////
			clipsize = gunvariables.galiclipsize;
			//Shoot anim
			galianimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = galisight;
			////muzzleflashs
			galimuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.galidamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (galisound, 0.7f); 
		}
		if (guntype == "famas") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.famasaccuracy, gunvariables.famasaccuracy);
			offset.y += Random.Range (-gunvariables.famasaccuracy, gunvariables.famasaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.famasshootspeed;
			//clipsize
			reloadspeed = gunvariables.famasreloadspeed;
			////
			clipsize = gunvariables.famasclipsize;
			//Shoot anim
			famasanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = famassight;
			////muzzleflashs
			famasmuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.famasdamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (famassound, 0.7f); 
		}
		if (guntype == "sg") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.sgaccuracy, gunvariables.sgaccuracy);
			offset.y += Random.Range (-gunvariables.sgaccuracy, gunvariables.sgaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.sgshootspeed;
			//clipsize
			reloadspeed = gunvariables.sgreloadspeed;
			////
			clipsize = gunvariables.sgclipsize;
			//Shoot anim
			sganimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = sgsight;
			////muzzleflashs
			sgmuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.sgdamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (sgsound, 0.7f); 
		}
		if (guntype == "m4a1") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.m4a1accuracy, gunvariables.m4a1accuracy);
			offset.y += Random.Range (-gunvariables.m4a1accuracy, gunvariables.m4a1accuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.m4a1shootspeed;
			//clipsize
			reloadspeed = gunvariables.m4a1reloadspeed;
			////
			clipsize = gunvariables.m4a1clipsize;
			//Shoot anim
			m4a1animator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = m4a1sight;
			////muzzleflashs
			m4a1muzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.m4a1damage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (m4a1sound, 0.7f); 
		}
		if (guntype == "m32") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.m32accuracy, gunvariables.m32accuracy);
			offset.y += Random.Range (-gunvariables.m32accuracy, gunvariables.m32accuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.m32shootspeed;
			//clipsize
			reloadspeed = gunvariables.m32reloadspeed;
			////
			clipsize = gunvariables.m32clipsize;
			//Shoot anim
			m32animator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = m32sight;
			////muzzleflashs
			m32muzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.m32damage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (m32sound, 0.7f); 
		}
		if (guntype == "bazooka") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.bazookaaccuracy, gunvariables.bazookaaccuracy);
			offset.y += Random.Range (-gunvariables.bazookaaccuracy, gunvariables.bazookaaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.bazookashootspeed;
			//clipsize
			reloadspeed = gunvariables.bazookareloadspeed;
			////
			clipsize = gunvariables.bazookaclipsize;
			//Shoot anim
			bazookaanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = bazookasight;
			////muzzleflashs
			bazookamuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.bazookadamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (rocketsound, 0.7f); 
		}
		if (guntype == "awp") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.awpaccuracy, gunvariables.awpaccuracy);
			offset.y += Random.Range (-gunvariables.awpaccuracy, gunvariables.awpaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.awpshootspeed;
			//clipsize
			reloadspeed = gunvariables.awpreloadspeed;
			////
			clipsize = gunvariables.awpclipsize;
			//Shoot anim
			awpanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = awpsight;
			////muzzleflashs
			awpmuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.awpdamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (awpsound, 0.7f); 
		}
		if (guntype == "bessy") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.bessyaccuracy, gunvariables.bessyaccuracy);
			offset.y += Random.Range (-gunvariables.bessyaccuracy, gunvariables.bessyaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.bessyshootspeed;
			//clipsize
			reloadspeed = gunvariables.bessyreloadspeed;
			////
			clipsize = gunvariables.bessyclipsize;
			//Shoot anim
			bessyanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = bessysight;
			////muzzleflashs
			bessymuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.bessydamage;
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (bigbessysound, 0.7f); 
		}
		if (guntype == "laser") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.laseraccuracy, gunvariables.laseraccuracy);
			offset.y += Random.Range (-gunvariables.laseraccuracy, gunvariables.laseraccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.lasershootspeed;
			//clipsize
			reloadspeed = gunvariables.laserreloadspeed;
			////
			clipsize = gunvariables.laserclipsize;
			//Shoot anim
			//laseranimator.SetTrigger ("shoot"); 
			laserLine.startColor = Color.red;
			laserLine.endColor = Color.red;
			///set gun sight
			sightholder = lasersight;
			////muzzleflashs
			//lasermuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.laserdamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (lasersound, 0.7f); 
		}
		if (guntype == "bigsniper") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.bigsniperaccuracy, gunvariables.bigsniperaccuracy);
			offset.y += Random.Range (-gunvariables.bigsniperaccuracy, gunvariables.bigsniperaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.bigsnipershootspeed;
			//clipsize
			reloadspeed = gunvariables.bigsniperreloadspeed;
			////
			clipsize = gunvariables.bigsniperclipsize;
			//Shoot anim
			bigsniperanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = bigsnipersight;
			////muzzleflashs
			bigsnipermuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.bigsniperdamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (bigsnipersound, 0.7f); 
		}
		if (guntype == "handturret") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.handturretaccuracy, gunvariables.handturretaccuracy);
			offset.y += Random.Range (-gunvariables.handturretaccuracy, gunvariables.handturretaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.handturretshootspeed;
			//clipsize
			reloadspeed = gunvariables.handturretreloadspeed;
			////
			clipsize = gunvariables.handturretclipsize;
			//Shoot anim
			handturretanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = handturretsight;
			////muzzleflashs
			handturretmuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.handturretdamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (handturretsound, 0.7f); 
		}
		if (guntype == "shotgun") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (gunvariables.shotgunaccuracy, gunvariables.shotgunaccuracy);
			offset.y += Random.Range (gunvariables.shotgunaccuracy, gunvariables.shotgunaccuracy);
			//
			offset2 = transform.right;
			offset2.x += Random.Range (-gunvariables.shotgunaccuracy, -gunvariables.shotgunaccuracy);
			offset2.y += Random.Range (-gunvariables.shotgunaccuracy, -gunvariables.shotgunaccuracy);
			//
			offset3 = transform.right;
			offset3.x += Random.Range (gunvariables.shotgunaccuracy+gunvariables.shotgunaccuracy, gunvariables.shotgunaccuracy+gunvariables.shotgunaccuracy);
			offset3.y += Random.Range (gunvariables.shotgunaccuracy+gunvariables.shotgunaccuracy, gunvariables.shotgunaccuracy+gunvariables.shotgunaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.shotgunshootspeed;
			//clipsize
			reloadspeed = gunvariables.shotgunreloadspeed;
			////
			clipsize = gunvariables.shotgunclipsize;
			//Shoot anim
			shotgunanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = shotgunsight;
			////muzzleflashs
			shotgunmuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.shotgundamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (shotgunsound, 0.7f); 
		}
		if (guntype == "mega") {
			///accuracy
			offset = transform.right;
			offset.x += Random.Range (-gunvariables.megaaccuracy, gunvariables.megaaccuracy);
			offset.y += Random.Range (-gunvariables.megaaccuracy, gunvariables.megaaccuracy);
			//Shootspeed
			equippedshootspeed = gunvariables.megashootspeed;
			//clipsize
			reloadspeed = gunvariables.megareloadspeed;
			////
			clipsize = gunvariables.megaclipsize;
			//Shoot anim
			//megaanimator.SetTrigger ("shoot"); 
			///set gun sight
			sightholder = megasight;
			////muzzleflashs
			//megamuzzleflash.GetComponent<SpriteRenderer> ().enabled = true;
			///damage
			gundamage = gunvariables.megadamage; 
			//
			myrandom = Random.Range (1f, 1.1f);
			soundplayer.pitch = myrandom;
			soundplayer.PlayOneShot (megasound, 0.7f); 
		}
		///////////////////////////////////////////////////	
		currentammo -= 1;
		currentammoui.text = currentammo.ToString () + " / " + ammoleft;
		if (guntype == "glock") {
			currentammoui.text = currentammo.ToString () + " / " + "\u221E";
		}
	
	}

	void myReloading() {

		if (Input.GetButtonDown ("Reload") && reloading == false && ammoleft != 0 && Time.timeScale == 1 && currentammo != clipsize) {
			reloadbar.transform.localScale = new Vector2 (1.26801f, 0.05084f);
			reloading = true;
			barwidth = 1.28f;
		}
		////
		if (currentammo <= 0 && reloading == false && ammoleft != 0 && Time.timeScale == 1) {
			reloadbar.transform.localScale = new Vector2 (1.26801f, 0.05084f);
			reloading = true;
			barwidth = 1.28f;
		}

		if (reloading && Time.timeScale == 1) {
			barvis.enabled = true;
			reloadbar.transform.localScale = new Vector2 (barwidth, 0.05084f);
			barwidth -= reloadspeed;
			if (barwidth <= 0) {
				
				if (currentammo <= 0 && ammoleft >= clipsize) {
					currentammo += clipsize;
					ammoleft -= clipsize;
				}

				if (currentammo <= 0 && ammoleft < clipsize) {
					currentammo += ammoleft;
					ammoleft -= ammoleft;
				}
				//pressed R
				if (currentammo > 0 && ammoleft >= clipsize) {
					ammoleft -= clipsize - currentammo;
					currentammo += clipsize - currentammo;
				}
				if (currentammo > 0 && ammoleft < clipsize) {
					ammoleft -= ammoleft;
					currentammo += ammoleft;
				}

				barvis.enabled = false;
				currentammoui.text = currentammo.ToString () + " / " + ammoleft;
				if (guntype == "glock") {
					currentammoui.text = currentammo.ToString () + " / " + "\u221E";
				}
				reloading = false;
			}
		

		}

	}

	void switchweapons() {


		if (Input.GetButtonDown ("Switch") && shopcode.isvisible == false && playercode.myrenderer == true && Time.timeScale == 1) {

			if (reloading == false) {


				
				soundplayer.PlayOneShot (changeweapons, 0.7f); 

				//Switch currentammo
				currentammoholder = currentammo;
				currentammo = currentammoholder2;
				currentammoholder2 = currentammoholder;

				//Switch ammoleft
				ammoleftholder = ammoleft;
				ammoleft = ammoleftholder2;
				ammoleftholder2 = ammoleftholder;

				///Actiate switch
				GunUISpritescode.guntype = secondary;
				GunUISpritescode.switchweapons ();

				GunUISpritescode2.guntype = primary;
				GunUISpritescode2.switchweapons ();

				///Switch the gunUI
				switchholder = primary;
				primary = secondary;
				secondary = switchholder;

				//Switch the guntype
				switchtheguntype();
				currentammoui.text = currentammo.ToString () + " / " + ammoleft;
				if (guntype == "glock") {
					currentammoui.text = currentammo.ToString () + " / " + "\u221E";
				}
			//	gunmanager ();

			}


		}
			


	}

	public void switchtheguntype() {
		if (primary == 0) {
			guntype = "glock";
			hideguns ();
			glock.SetActive (true);
			clipsize = gunvariables.glockclipsize;
			reloadspeed = gunvariables.glockreloadspeed;
		}
		if (primary == 1) {
			guntype = "baretta";
			hideguns ();
			baretta.SetActive(true);
			clipsize = gunvariables.barettaclipsize;
			reloadspeed = gunvariables.barettareloadspeed;
		}
		if (primary == 2) {
			guntype = "cz75";
			hideguns ();
			cz75.SetActive(true);
			clipsize = gunvariables.cz75clipsize;
			reloadspeed = gunvariables.cz75reloadspeed;
		}
		if (primary == 3) {
			guntype = "auto";
			hideguns ();
			auto.SetActive(true);
			clipsize = gunvariables.autoclipsize;
			reloadspeed = gunvariables.autoreloadspeed;
		}
		if (primary == 4) {
			guntype = "revolver";
			hideguns ();
			revolver.SetActive(true);
			clipsize = gunvariables.revolverclipsize;
			reloadspeed = gunvariables.revolverreloadspeed;
		}
		if (primary == 5) {
			guntype = "mac10";
			hideguns ();
			mac10.SetActive (true);
			clipsize = gunvariables.mac10clipsize;
			reloadspeed = gunvariables.mac10reloadspeed;
		}
		if (primary == 6) {
			guntype = "mp5";
			hideguns ();
			mp5.SetActive (true);
			clipsize = gunvariables.mp5clipsize;
			reloadspeed = gunvariables.mp5reloadspeed;
		}
		if (primary == 7) {
			guntype = "spectre";
			hideguns ();
			spectre.SetActive (true);
			clipsize = gunvariables.spectreclipsize;
			reloadspeed = gunvariables.spectrereloadspeed;
		}
		if (primary == 8) {
			guntype = "ump";
			hideguns ();
			ump.SetActive (true);
			clipsize = gunvariables.umpclipsize;
			reloadspeed = gunvariables.umpreloadspeed;
		}
		if (primary == 9) {
			guntype = "p90";
			hideguns ();
			p90.SetActive (true);
			clipsize = gunvariables.p90clipsize;
			reloadspeed = gunvariables.p90reloadspeed;
		}
		if (primary == 10) {
			guntype = "xm8";
			hideguns ();
			xm8.SetActive (true);
			clipsize = gunvariables.xm8clipsize;
			reloadspeed = gunvariables.xm8reloadspeed;
		}
		if (primary == 11) {
			guntype = "gali";
			hideguns ();
			gali.SetActive (true);
			clipsize = gunvariables.galiclipsize;
			reloadspeed = gunvariables.galireloadspeed;
		}
		if (primary == 12) {
			guntype = "famas";
			hideguns ();
			famas.SetActive (true);
			clipsize = gunvariables.famasclipsize;
			reloadspeed = gunvariables.famasreloadspeed;
		}
		if (primary == 13) {
			guntype = "sg";
			hideguns ();
			sg.SetActive (true);
			clipsize = gunvariables.sgclipsize;
			reloadspeed = gunvariables.sgreloadspeed;
		}
		if (primary == 14) {
			guntype = "m4a1";
			hideguns ();
			m4a1.SetActive (true);
			clipsize = gunvariables.m4a1clipsize;
			reloadspeed = gunvariables.m4a1reloadspeed;
		}
		if (primary == 15) {
			guntype = "m32";
			hideguns ();
			m32.SetActive (true);
			clipsize = gunvariables.m32clipsize;
			reloadspeed = gunvariables.m32reloadspeed;
		}
		if (primary == 16) {
			guntype = "bazooka";
			hideguns ();
			bazooka.SetActive (true);
			clipsize = gunvariables.bazookaclipsize;
			reloadspeed = gunvariables.bazookareloadspeed;
		}
		if (primary == 19) {
			guntype = "awp";
			hideguns ();
			awp.SetActive (true);
			clipsize = gunvariables.awpclipsize;
			reloadspeed = gunvariables.awpreloadspeed;
		}
		if (primary == 20) {
			guntype = "bessy";
			hideguns ();
			bessy.SetActive (true);
			clipsize = gunvariables.bessyclipsize;
			reloadspeed = gunvariables.bessyreloadspeed;
		}
		if (primary == 21) {
			guntype = "laser";
			hideguns ();
			laser.SetActive (true);
			clipsize = gunvariables.laserclipsize;
			reloadspeed = gunvariables.laserreloadspeed;
		}
		if (primary == 22) {
			guntype = "bigsniper";
			hideguns ();
			bigsniper.SetActive (true);
			clipsize = gunvariables.bigsniperclipsize;
			reloadspeed = gunvariables.bigsniperreloadspeed;
		}
		if (primary == 23) {
			guntype = "handturret";
			hideguns ();
			handturret.SetActive (true);
			clipsize = gunvariables.handturretclipsize;
			reloadspeed = gunvariables.handturretreloadspeed;
		}
		if (primary == 24) {
			guntype = "shotgun";
			hideguns ();
			shotgun.SetActive (true);
			clipsize = gunvariables.shotgunclipsize;
			reloadspeed = gunvariables.shotgunreloadspeed;
		}
		if (primary == 25) {
			guntype = "mega";
			hideguns ();
			mega.SetActive (true);
			clipsize = gunvariables.megaclipsize;
			reloadspeed = gunvariables.megareloadspeed;
		}
		gunname.text = guntype;




	}

	public void hideguns() {
		glock.SetActive (false);
		baretta.SetActive(false);
		cz75.SetActive(false);
		auto.SetActive(false);
		revolver.SetActive(false);
		mac10.SetActive (false);
		mp5.SetActive (false);
		spectre.SetActive (false);
		ump.SetActive (false);
		p90.SetActive (false);
		xm8.SetActive (false);
		gali.SetActive (false);
		famas.SetActive (false);
		sg.SetActive (false);
		m4a1.SetActive (false);
		m32.SetActive (false);
		bazooka.SetActive (false);
		awp.SetActive (false);
		bessy.SetActive (false);
		laser.SetActive (false);
		bigsniper.SetActive (false);
		handturret.SetActive (false);
		shotgun.SetActive (false);
		mega.SetActive (false);
	}
		

	public void resetammo() {
		/////glock
		if (primary == 0) {
			currentammo = gunvariables.glockclipsize;
			ammoleft = gunvariables.glockammoleft;
		}
		////baretta
		if (primary == 1) {
			currentammo = gunvariables.barettaclipsize;
			ammoleft = gunvariables.barettaammoleft;
		}
		////CZ75
		if (primary == 2) {
			currentammo = gunvariables.cz75clipsize;
			ammoleft = gunvariables.cz75ammoleft;
		}
		////Auto
		if (primary == 3) {
			currentammo = gunvariables.autoclipsize;
			ammoleft = gunvariables.autoammoleft;
		}
		////Revolver
		if (primary == 4) {
			currentammo = gunvariables.revolverclipsize;
			ammoleft = gunvariables.revolverammoleft;
		}
		////mac10
		if (primary == 5) {
			currentammo = gunvariables.mac10clipsize;
			ammoleft = gunvariables.mac10ammoleft;
		}
		////mp5
		if (primary == 6) {
			currentammo = gunvariables.mp5clipsize;
			ammoleft = gunvariables.mp5ammoleft;
		}
		////spectre
		if (primary == 7) {
			currentammo = gunvariables.spectreclipsize;
			ammoleft = gunvariables.spectreammoleft;
		}
		////ump
		if (primary == 8) {
			currentammo = gunvariables.umpclipsize;
			ammoleft = gunvariables.umpammoleft;
		}
		////p90
		if (primary == 9) {
			currentammo = gunvariables.p90clipsize;
			ammoleft = gunvariables.p90ammoleft;
		}
		////xm8
		if (primary == 10) {
			currentammo = gunvariables.xm8clipsize;
			ammoleft = gunvariables.xm8ammoleft;
		}
		////gali
		if (primary == 11) {
			currentammo = gunvariables.galiclipsize;
			ammoleft = gunvariables.galiammoleft;
		}
		////famas
		if (primary == 12) {
			currentammo = gunvariables.famasclipsize;
			ammoleft = gunvariables.famasammoleft;
		}
		////sg
		if (primary == 13) {
			currentammo = gunvariables.sgclipsize;
			ammoleft = gunvariables.sgammoleft;
		}
		////m4a1
		if (primary == 14) {
			currentammo = gunvariables.m4a1clipsize;
			ammoleft = gunvariables.m4a1ammoleft;
		}
		////m32
		if (primary == 15) {
			currentammo = gunvariables.m32clipsize;
			ammoleft = gunvariables.m32ammoleft;
		}
		////bazooka
		if (primary == 16) {
			currentammo = gunvariables.bazookaclipsize;
			ammoleft = gunvariables.bazookaammoleft;
		}
		////awp
		if (primary == 19) {
			currentammo = gunvariables.awpclipsize;
			ammoleft = gunvariables.awpammoleft;
		}
		////bessy
		if (primary == 20) {
			currentammo = gunvariables.bessyclipsize;
			ammoleft = gunvariables.bessyammoleft;
		}
		////laser
		if (primary == 21) {
			currentammo = gunvariables.laserclipsize;
			ammoleft = gunvariables.laserammoleft;
		}
		////Big sniper
		if (primary == 22) {
			currentammo = gunvariables.bigsniperclipsize;
			ammoleft = gunvariables.bigsniperammoleft;
		}
		////Hand Turret
		if (primary == 23) {
			currentammo = gunvariables.handturretclipsize;
			ammoleft = gunvariables.handturretammoleft;
		}
		////Shotgun
		if (primary == 24) {
			currentammo = gunvariables.shotgunclipsize;
			ammoleft = gunvariables.shotgunammoleft;
		}
		////Mega
		if (primary == 25) {
			currentammo = gunvariables.megaclipsize;
			ammoleft = gunvariables.megaammoleft;
		}
		///grenades
		//grenadeamount = 0;
		//grenadesui.SetActive (false);
		///////////
		currentammoui.text = currentammo.ToString () + " / " + ammoleft;
		if (primary == 0) {
			currentammoui.text = currentammo.ToString () + " / " + "\u221E";
		}
	}

	public void resetammo2() {


		/////glock
		if (primary == 0) {
			currentammo = gunvariables.glockclipsize;
			ammoleft = gunvariables.glockammoleft;
		}
		if (secondary == 0) {
			currentammoholder2 = gunvariables.glockclipsize;
			ammoleftholder2 = gunvariables.glockammoleft;
		}
		////baretta
		if (primary == 1) {
			currentammo = gunvariables.barettaclipsize;
			ammoleft = gunvariables.barettaammoleft;
		}
		if (secondary == 1) {
			currentammoholder2 = gunvariables.barettaclipsize;
			ammoleftholder2 = gunvariables.barettaammoleft;
		}
		////CZ75
		if (primary == 2) {
			currentammo = gunvariables.cz75clipsize;
			ammoleft = gunvariables.cz75ammoleft;
		}
		if (secondary == 2) {
			currentammoholder2 = gunvariables.cz75clipsize;
			ammoleftholder2 = gunvariables.cz75ammoleft;
		}
		////Auto
		if (primary == 3) {
			currentammo = gunvariables.autoclipsize;
			ammoleft = gunvariables.autoammoleft;
		}
		if (secondary == 3) {
			currentammoholder2 = gunvariables.autoclipsize;
			ammoleftholder2 = gunvariables.autoammoleft;
		}
		////Revolver
		if (primary == 4) {
			currentammo = gunvariables.revolverclipsize;
			ammoleft = gunvariables.revolverammoleft;
		}
		if (secondary == 4) {
			currentammoholder2 = gunvariables.revolverclipsize;
			ammoleftholder2 = gunvariables.revolverammoleft;
		}
		////mac10
		if (primary == 5) {
			currentammo = gunvariables.mac10clipsize;
			ammoleft = gunvariables.mac10ammoleft;
		}
		if (secondary == 5) {
			currentammoholder2 = gunvariables.mac10clipsize;
			ammoleftholder2 = gunvariables.mac10ammoleft;
		}
		////mp5
		if (primary == 6) {
			currentammo = gunvariables.mp5clipsize;
			ammoleft = gunvariables.mp5ammoleft;
		}
		if (secondary == 6) {
			currentammoholder2 = gunvariables.mp5clipsize;
			ammoleftholder2 = gunvariables.mp5ammoleft;
		}
		////spectre
		if (primary == 7) {
			currentammo = gunvariables.spectreclipsize;
			ammoleft = gunvariables.spectreammoleft;
		}
		if (secondary == 7) {
			currentammoholder2 = gunvariables.spectreclipsize;
			ammoleftholder2 = gunvariables.spectreammoleft;
		}
		////ump
		if (primary == 8) {
			currentammo = gunvariables.umpclipsize;
			ammoleft = gunvariables.umpammoleft;
		}
		if (secondary == 8) {
			currentammoholder2 = gunvariables.umpclipsize;
			ammoleftholder2 = gunvariables.umpammoleft;
		}
		////p90
		if (primary == 9) {
			currentammo = gunvariables.p90clipsize;
			ammoleft = gunvariables.p90ammoleft;
		}
		if (secondary == 9) {
			currentammoholder2 = gunvariables.p90clipsize;
			ammoleftholder2 = gunvariables.p90ammoleft;
		}
		////xm8
		if (primary == 10) {
			currentammo = gunvariables.xm8clipsize;
			ammoleft = gunvariables.xm8ammoleft;
		}
		if (secondary == 10) {
			currentammoholder2 = gunvariables.xm8clipsize;
			ammoleftholder2 = gunvariables.xm8ammoleft;
		}
		////gali
		if (primary == 11) {
			currentammo = gunvariables.galiclipsize;
			ammoleft = gunvariables.galiammoleft;
		}
		if (secondary == 11) {
			currentammoholder2 = gunvariables.galiclipsize;
			ammoleftholder2 = gunvariables.galiammoleft;
		}
		////famas
		if (primary == 12) {
			currentammo = gunvariables.famasclipsize;
			ammoleft = gunvariables.famasammoleft;
		}
		if (secondary == 12) {
			currentammoholder2 = gunvariables.famasclipsize;
			ammoleftholder2 = gunvariables.famasammoleft;
		}
		////sg
		if (primary == 13) {
			currentammo = gunvariables.sgclipsize;
			ammoleft = gunvariables.sgammoleft;
		}
		if (secondary == 13) {
			currentammoholder2 = gunvariables.sgclipsize;
			ammoleftholder2 = gunvariables.sgammoleft;
		}
		////m4a1
		if (primary == 14) {
			currentammo = gunvariables.m4a1clipsize;
			ammoleft = gunvariables.m4a1ammoleft;
		}
		if (secondary == 14) {
			currentammoholder2 = gunvariables.m4a1clipsize;
			ammoleftholder2 = gunvariables.m4a1ammoleft;
		}
		////m32
		if (primary == 15) {
			currentammo = gunvariables.m32clipsize;
			ammoleft = gunvariables.m32ammoleft;
		}
		if (secondary == 15) {
			currentammoholder2 = gunvariables.m32clipsize;
			ammoleftholder2 = gunvariables.m32ammoleft;
		}
		////bazooka
		if (primary == 16) {
			currentammo = gunvariables.bazookaclipsize;
			ammoleft = gunvariables.bazookaammoleft;
		}
		if (secondary == 16) {
			currentammoholder2 = gunvariables.bazookaclipsize;
			ammoleftholder2 = gunvariables.bazookaammoleft;
		}
		////awp
		if (primary == 19) {
			currentammo = gunvariables.awpclipsize;
			ammoleft = gunvariables.awpammoleft;
		}
		if (secondary == 19) {
			currentammoholder2 = gunvariables.awpclipsize;
			ammoleftholder2 = gunvariables.awpammoleft;
		}
		////bessy
		if (primary == 20) {
			currentammo = gunvariables.bessyclipsize;
			ammoleft = gunvariables.bessyammoleft;
		}
		if (secondary == 20) {
			currentammoholder2 = gunvariables.bessyclipsize;
			ammoleftholder2 = gunvariables.bessyammoleft;
		}
		////laser
		if (primary == 21) {
			currentammo = gunvariables.laserclipsize;
			ammoleft = gunvariables.laserammoleft;
		}
		if (secondary == 21) {
			currentammoholder2 = gunvariables.laserclipsize;
			ammoleftholder2 = gunvariables.laserammoleft;
		}
		////Big sniper
		if (primary == 22) {
			currentammo = gunvariables.bigsniperclipsize;
			ammoleft = gunvariables.bigsniperammoleft;
		}
		if (secondary == 22) {
			currentammoholder2 = gunvariables.bigsniperclipsize;
			ammoleftholder2 = gunvariables.bigsniperammoleft;
		}
		////Hand Turret
		if (primary == 23) {
			currentammo = gunvariables.handturretclipsize;
			ammoleft = gunvariables.handturretammoleft;
		}
		if (secondary == 23) {
			currentammoholder2 = gunvariables.handturretclipsize;
			ammoleftholder2 = gunvariables.handturretammoleft;
		}
		////Shotgun
		if (primary == 24) {
			currentammo = gunvariables.shotgunclipsize;
			ammoleft = gunvariables.shotgunammoleft;
		}
		if (secondary == 24) {
			currentammoholder2 = gunvariables.shotgunclipsize;
			ammoleftholder2 = gunvariables.shotgunammoleft;
		}
		////Mega
		if (primary == 25) {
			currentammo = gunvariables.megaclipsize;
			ammoleft = gunvariables.megaammoleft;
		}
		if (secondary == 25) {
			currentammoholder2 = gunvariables.megaclipsize;
			ammoleftholder2 = gunvariables.megaammoleft;
		}
		///grenades
		//grenadeamount = 0;
		//grenadesui.SetActive (false);
		///////////
		currentammoui.text = currentammo.ToString () + " / " + ammoleft;
		if (primary == 0) {
			currentammoui.text = currentammo.ToString () + " / " + "\u221E";
		}
	}

	public void turnoffmuzzleflashes() {

		glockmuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		barettamuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		cz75muzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		automuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		revolvermuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		mac10muzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		mp5muzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		spectremuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		umpmuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		p90muzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		xm8muzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		galimuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		famasmuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		sgmuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		m4a1muzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		m32muzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		bazookamuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		awpmuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		bessymuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		lasermuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		bigsnipermuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		handturretmuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		shotgunmuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
		megamuzzleflash.GetComponent<SpriteRenderer> ().enabled = false;
	}
		

}
