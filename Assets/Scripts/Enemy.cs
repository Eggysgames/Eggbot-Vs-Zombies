using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

	private Main maincode;
	private Shop shopcode;
	private Rigidbody2D zombie; 
	private Rigidbody2D player; 
	private Animator myanimator;
	private Character playercode;
	private bool beginremove = false; 
	private int timer;
	private int jumptimer;
	private bool grounded = false;
	private bool grounded2 = false;
	private float colourfade;
	private Color mycolour; 
	private float nearby;
	private float Ydifference;
	private float zombieY;
	private float playerY;
	private bool stopfade = false;
	//private bool resetspeed = false;
	private int resetanimtimer; 
	private int myanimationstate = 0;
	private float leftdistancecheck;
	private float rightdistancecheck;
	private float door4pos;
	private float door5pos;
	private float door6pos;
	private bool walkdirection = false;
	private bool runonce = false;
	private bool runonce2 = false;
	private float holdlowest;
	private float zombieDistanceToDoor; 
	private float zombieDistanceToClosestDoor; 
	private int poweruproll; 
	private GameObject door1;
	private GameObject door3;
	private GameObject door4;
	private GameObject door5;
	private GameObject door6;
	private GameObject door7;
	private GameObject locked1;
	private GameObject locked2;
	private GameObject locked3;
	private GameObject locked4;
	//private GameObject locked5;
	private GameObject locked6;
	private GameObject locked7;
	private GameObject topleftmarker;
	private GameObject toprightmarker;
	private GameObject closestdoor;
	private bool wasattacking; 
	private int sortingorder;
	private Ragdoll ragdollcode;
	private Rigidbody2D holderrigidbody;
	private GameObject holder;
	private float holdspeed;
	private GameObject[] doorsarray;
	private int waittimer; 
	private bool waittimergo;
	private bool onthewall; 
	private bool wallgrounded;
	private int waittillattack;

	[HideInInspector] public float xposholder;
	[HideInInspector] public bool dying;
	[HideInInspector] public int bodydamage; 
	[HideInInspector] public int hitholder; 
	[HideInInspector] public string guntype;
	[HideInInspector] public int store; 

	public bool flip;
	public int health; 
	public float speed;
	public int jumpheight;
	public float deathremove;
	public GameObject hitpoint;
	public GameObject blood;
	public GameObject head; 
	public GameObject chest;
	public GameObject skulls; 
	public GameObject chestpieces;
	public GameObject bloodsplosion;
	public GameObject explosion;
	public GameObject attackpoint2;
	public GameObject Powerup;
	public GameObject crablegs;
	public Transform myleft;
	public Transform myright;
	public Transform myleftwall;
	public Transform myrightwall;
	public Transform fronthitgroundleft;
	public Transform fronthitgroundright;
	public bool stopit;

	void Awake () {
		stopit = false;
		door1 = GameObject.Find ("Spawnpointdoor1");
		door3 = GameObject.Find ("Evildoor3Top");
		door4 = GameObject.Find ("Evildoor4Bottom");
		door5 = GameObject.Find ("Evildoor5Bottom");
		door6 = GameObject.Find ("Evildoor6Bottom");
		door7 = GameObject.Find ("Evildoor7Top");
		locked1 = GameObject.Find ("LockedDoor1");
		locked2 = GameObject.Find ("LockedDoor2");
		locked3 = GameObject.Find ("LockedDoor3");
		locked4 = GameObject.Find ("LockedDoor4");
		//locked5 = GameObject.Find ("LockedDoor5");
		locked6 = GameObject.Find ("LockedDoor6");
		locked7 = GameObject.Find ("LockedDoor7");
		doorsarray = new GameObject[] {door4, door5, door6};
		closestdoor = doorsarray [0];
		topleftmarker = GameObject.Find ("TopLeftMarker");
		toprightmarker = GameObject.Find ("TopRightMarker");
		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		player = GameObject.Find ("EggHead").GetComponent<Rigidbody2D> ();
		playercode = GameObject.Find ("EggHead").GetComponent<Character> ();
		zombie = GetComponent<Rigidbody2D> (); 
		myanimator = GetComponent<Animator> ();
		mycolour = GetComponent<SpriteRenderer> ().color;
		mycolour.a = 0f;
		GetComponent<SpriteRenderer> ().color = mycolour;
		speed = Random.Range (maincode.zombiespeed-0.1f, maincode.zombiespeed+0.1f);
		health = maincode.zombieshealth / 2;
		holdspeed = speed;
		dying = false;
		wasattacking = false;
		waittimer = 0;
		waittimergo = false;
		onthewall = true;
		zombie.gravityScale = 0; 
		//
//		if (flip == false) {
//			zombie.rotation = 90;
//			Vector3 theScale = transform.localScale;
//			theScale.x = 0.223f;
//			transform.localScale = theScale;
//		}

		//


	}


	void Update () {

		if (maincode == null) {
			Debug.Log ("its null");
		}



		downwallmovement ();

		grounded = Physics2D.Linecast (myleft.position, myright.position, 1 << LayerMask.NameToLayer ("Ground"));



		if (maincode.killthemall == true && stopit == false) {
			dying = true;
			maincode.gamemoney += 5;
			maincode.UpdateText ();
			Instantiate (explosion, transform.position, transform.rotation);
			stopit = true;
			Death2 ();
		}

		fadein ();

		if (player != null) {
			nearby = Vector2.Distance (transform.position, player.transform.position);
		}
		leftdistancecheck = Vector2.Distance (transform.position, topleftmarker.transform.position);
		rightdistancecheck = Vector2.Distance (transform.position, toprightmarker.transform.position);
		door4pos = Vector2.Distance (transform.position, door4.transform.position);
		door5pos = Vector2.Distance (transform.position, door5.transform.position);
		door6pos = Vector2.Distance (transform.position, door6.transform.position);

		zombieY = zombie.position.y;
		playerY = player.position.y;

		Ydifference = zombieY - playerY;

		FindPlayerFunction ();

		if (shopcode.isvisible == true) {
			Destroy (gameObject);
		}
		///attack
		if (waittillattack >= 40) {
			if (nearby < 2 && nearby > 1 && grounded == true && wasattacking == false && onthewall == false) {
				if (wasattacking == false) {
					//zombie.velocity = Vector3.zero;
					speed = Random.Range (-2f, -3f); 
					zombie.AddForce (new Vector2 (zombie.velocity.x, jumpheight));

				}
				wasattacking = true;
				myanimator.SetTrigger ("attack");
				waittimergo = true;

				//this.GetComponent<BoxCollider> ().size.y = new Vector2 (10, 10);

			}
		}

		if (waittimergo == true) {
			waittimer++;
		}
		if (grounded == true && wasattacking == true && waittimer>= 10) {
			wasattacking = false;
			myanimator.SetTrigger ("stop");
			speed = holdspeed;
			waittimergo = false;
			waittimer = 0;
			speed = holdspeed;

		}

		//Debug.Log (grounded);

		/////////////////
		if (beginremove == true) {

			deathremove -= Time.deltaTime;
			if (deathremove < 0) {

				colourfade -= 0.03f;
				mycolour.a = colourfade;
				GetComponent<SpriteRenderer> ().color = mycolour;
				if (colourfade <= 0) {
					Destroy (gameObject);
				}


			}
		}


	}

	public void hurtplayer() {
		if (playercode.myrenderer == true && health >= 1) {
			playercode.hurtplayer ();
			playercode.hitholder = hitholder;
			playercode.enemyhitting = "headcrab";
		}
	}

	public void resettimer() {
		playercode.hurtplayer ();
	}

	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Player" && Ydifference < -1) {
			//speed = 0;
			//Debug.Log("here?");
			if (myanimationstate != 1) {
				//myanimator.SetTrigger ("attackup");
				myanimationstate = 1;
				attackpoint2.SetActive (true);
			}
		}
	}




	void Death2() {
		
		if (maincode != null) {
			maincode.zombiesleft -= 1;
			maincode.UpdateText ();
		}

		//Full explode
		Instantiate (blood, head.transform.position, transform.rotation);
		Instantiate (bloodsplosion, chest.transform.position, transform.rotation);
		Instantiate (crablegs, chest.transform.position, transform.rotation);
		//
		Instantiate (chestpieces, chest.transform.position, transform.rotation);
		Instantiate (skulls, head.transform.position, transform.rotation);
		Destroy (gameObject);
	}

	void downwallmovement() {

		grounded2 = Physics2D.Linecast (fronthitgroundleft.position, fronthitgroundright.position, 1 << LayerMask.NameToLayer ("Ground"));

			if (onthewall == true) {
				wallgrounded = Physics2D.Linecast (myleftwall.position, myrightwall.position, 1 << LayerMask.NameToLayer ("Ground"));

				if (wallgrounded == false) {
					zombie.gravityScale = 1;
					zombie.rotation = 0;
					onthewall = false;
				}
			}

			if (onthewall == true) {
				zombie.velocity = new Vector2 (zombie.velocity.x, speed);
			}
			if (grounded2 == true) {
				zombie.gravityScale = 1;
				zombie.rotation = 0;
				onthewall = false;
			}


	}

	void normalmovement() {
		if (grounded == true && onthewall == false) {
			zombie.rotation = 0;
			waittillattack++;
			if (player != null) {
				if (player.transform.position.x < transform.position.x) {
					zombie.velocity = new Vector2 (speed, zombie.velocity.y);
					//
					Vector3 theScale = transform.localScale;
					theScale.x = 0.223f;
					transform.localScale = theScale;
				} else if (player.transform.position.x > transform.position.x) {
					zombie.velocity = new Vector2 (-speed, zombie.velocity.y);
					//
					Vector3 theScale = transform.localScale;
					theScale.x = -0.223f;
					transform.localScale = theScale;
				}
			}
		}
	}

	void leftmovement() {
		if (grounded == true) {
			zombie.velocity = new Vector2 (speed, zombie.velocity.y);
			Vector3 theScale = transform.localScale;
			theScale.x = 0.223f;
			transform.localScale = theScale;
		}
	}

	void rightmovement() {
		if (grounded == true) {
			zombie.velocity = new Vector2 (-speed, zombie.velocity.y);
			Vector3 theScale = transform.localScale;
			theScale.x = -0.223f;
			transform.localScale = theScale;
		}
	}

	public void Damaged() {
		//Getting Shot
		if (store == 1) {
			//headshot
			gundamagehead(); 
			if (health <= 0) {
				dying = true;

				if (maincode != null) {
					maincode.UpdateText ();
					maincode.enemieskilled += 1;
				}
				if (grounded == true) {
					if (maincode != null) {
						maincode.gamemoney += 10;
						maincode.UpdateText ();
					}
					powerupspawn ();
					Death2 ();
				} else if (grounded == false) {
					if (maincode != null) {
						maincode.gamemoney += 10;
						maincode.UpdateText ();
					}
					powerupspawn();
					Death2 ();
				}
			}
		}
		if (store == 2) {
			//bodyshot
			gundamagebody();
			if (health <= 0) {
				dying = true;
				if (maincode != null) {
					maincode.UpdateText ();
					maincode.enemieskilled += 1;
				}
				if (grounded == true) {
					if (maincode != null) {
						maincode.gamemoney += 10;
						maincode.UpdateText ();
					}
					Death2 ();
				} else if (grounded == false) {
					if (maincode != null) {
						maincode.gamemoney += 10;
						maincode.UpdateText ();
					}
					Death2 ();
				}
			}
		}
	}

	void gundamagebody() {
		health -= bodydamage; 
	}

	void gundamagehead() {
		health -= bodydamage * 2; 
	}

	void fadein() {
		if (colourfade < 1 && stopfade == false) {
			colourfade += 0.03f;
			mycolour.a = colourfade;
			GetComponent<SpriteRenderer> ().color = mycolour;
			if (colourfade >= 1) {
				stopfade = true;
			}
		}
	}
	void powerupspawn() {

		poweruproll = Random.Range (0, 15);
		if (poweruproll == 10) {
			Instantiate (Powerup, head.transform.position, transform.rotation);
		}
	}

	void FindPlayerFunction() {
		if (health > 0) {
			//Movement
			if (nearby > 1) {

				//Debug.Log (Ydifference);

				if (Ydifference < 7 && Ydifference > -5) {
					speed = holdspeed;
					normalmovement ();
					runonce = false;
					runonce2 = false;
				}

				if (Ydifference <= -7) {

					if (runonce2 == false) {

						foreach (GameObject door in doorsarray) {

							zombieDistanceToDoor = Vector2.Distance (door.transform.position, transform.position);
							zombieDistanceToClosestDoor = Vector2.Distance (closestdoor.transform.position, transform.position);

							if (zombieDistanceToDoor < zombieDistanceToClosestDoor) {
								closestdoor = door;
							}

						}

						runonce2 = true;

					}



					if (closestdoor.name == "Evildoor4Bottom") {
						if (door4.transform.position.x < transform.position.x) {
							leftmovement ();
						}
						else if (door4.transform.position.x > transform.position.x) {
							rightmovement ();
						}

					}
					else if (closestdoor.name == "Evildoor5Bottom") {
						if (door5.transform.position.x < transform.position.x) {
							leftmovement ();
						}
						else if (door5.transform.position.x > transform.position.x) {
							rightmovement ();
						}
					}
					else if (closestdoor.name == "Evildoor6Bottom") {
						if (door6.transform.position.x < transform.position.x) {
							leftmovement ();
						}
						else if (door6.transform.position.x > transform.position.x) {
							rightmovement ();
						}

					}


					if (door6pos < 1) {
						colourfade -= 0.03f;
						mycolour.a = colourfade;
						GetComponent<SpriteRenderer> ().color = mycolour;
						if (colourfade <= 0) {
							if (locked7 != null) {
								transform.position = door1.transform.position;
							}
							if (locked7 == null) {
								transform.position = door7.transform.position;
							}
							stopfade = false;
						}
					}
					if (door5pos < 1) {
						colourfade -= 0.03f;
						mycolour.a = colourfade;
						GetComponent<SpriteRenderer> ().color = mycolour;
						if (colourfade <= 0) {
							transform.position = door1.transform.position;
							stopfade = false;
						}
					}
					if (door4pos < 1) {
						colourfade -= 0.03f;
						mycolour.a = colourfade;
						GetComponent<SpriteRenderer> ().color = mycolour;
						if (colourfade <= 0) {
							
							if (locked4 != null) {
								transform.position = door1.transform.position;
							}

							if (locked4 == null) {
								transform.position = door3.transform.position;
							}

							stopfade = false;
						}
					}

				}

				if (Ydifference >= 6) {

					speed = -4;

					if (runonce == false) {
						if (leftdistancecheck > rightdistancecheck) {
							walkdirection = false;
						} else if (leftdistancecheck < rightdistancecheck) {
							walkdirection = true;
						}
						runonce = true;
						if (locked1 != null) {
							if (locked1.activeSelf == true) {
								walkdirection = false;
							}
						}
						if (locked2 != null) {
							if (locked2.activeSelf == true) {
								walkdirection = true;
							}
						}
						//
						if (locked7 != null) {
							if (locked7.activeSelf == true) {
								walkdirection = false;
							}
						}
						if (locked3 != null) {
							if (locked3.activeSelf == true) {
								walkdirection = true;
							}
						}
						if (locked7 != null && locked3 != null) {
							if (locked7.activeSelf == true && locked3.activeSelf == true) {
								if (toprightmarker.transform.position.x < player.position.x) {
									walkdirection = false;
								} else if (toprightmarker.transform.position.x > player.position.x) {
									walkdirection = true;
								}
							}
						}
						//
						if (locked6 != null) {
							if (locked6.activeSelf == true) {
								walkdirection = false;
							}
						}
						if (locked4 != null) {
							if (locked4.activeSelf == true) {
								walkdirection = true;
							}
						}
						if (locked6 != null && locked4 != null) {
							if (locked6.activeSelf == true && locked4.activeSelf == true) {
								if (toprightmarker.transform.position.x < player.position.x) {
									walkdirection = false;
								} else if (toprightmarker.transform.position.x > player.position.x) {
									walkdirection = true;
								}
							}
						}
						//
//						if (locked5 != null) {
//							if (locked5.activeSelf == true) {
//								walkdirection = true;
//							}
//						}
					}
						


					if (walkdirection == true) {
						leftmovement ();
					}
					if (walkdirection == false) {
						rightmovement ();
					}
				}

			}
		}
	}

}




//jumptimer++;
//if (jumptimer > 100) {
//	speed = -1;
//	zombie.velocity = Vector3.zero;
//	zombie.AddForce (new Vector2 (0, jumpheight));
//	jumptimer = 0;
//}


