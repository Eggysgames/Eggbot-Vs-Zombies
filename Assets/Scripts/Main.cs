using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Main : MonoBehaviour {
	 
	private Shop shopcode;
	private GunBox gunboxcode;
	private Extra extramotorbikecode;

	public int enemieskilled;
	public int headshots; 
	public int wavessurvived;

	public int zombiespawnamountholder;
	private float zombiespeedholder;
	public int zombieshealthholder;
	private int spawnspeedholder;
	private int spawntimerholder;
	private int missioncounter;
	private float playernearby;
	private float playernearby2;

	public Text gamemoneyui;
	public Text wavesui;
	public Text zombiesleftui;
	public Text nextwaveui; 
	public int gamemoney; 
	public int zombiesleft;
	public int zombiespawnamount = 0;
	public float zombiespeed; 
	public int zombieshealth; 
	public int piecesorder = 0;
	public int wave; 
	public float globaltimer; 
	public bool runonce = false;
	public bool boxtimeractive;
	public int boxtimer;
	public bool slowmotimeractive;
	public int slowmotimer;
	public bool killthemall;
	public int quicktimer; 
	public GameObject chatboxobject;
	public Text chat; 
	public int chatroll; 
	public bool chattrue;
	public int chattimer;
	public bool missionsactive; 
	public int whichmission;
	public int obeliskamount;
	public int hostageamount;
	public int alienamount;
	public int intelamount;
	public int turretamount;
	public int motorbikeamount;
	public int missionscomplete;


	public GameObject zombie; 
	public GameObject headcrab;
	public GameObject headcrabright;
	public int ragdollorder;
	public int increaseorder; 
	public int spawntimer;
	public int spawnspeed;
	public GameObject holder;
	public GameObject lockeddoor1; 
	public GameObject lockeddoor2; 
	public GameObject lockeddoor3; 
	public GameObject lockeddoor4; 
	public GameObject lockeddoor5; 
	public GameObject lockeddoor6; 
	public GameObject lockeddoor7; 
	public GameObject doorspawnpoint1; 
	public GameObject doorspawnpoint2; 
	public GameObject doorspawnpoint3; 
	public GameObject doorspawnpoint4; 
	public GameObject doorspawnpoint5; 
	public GameObject doorspawnpoint6; 
	public GameObject doorspawnpoint7; 
	public GameObject doorspawnpoint8; 
	public GameObject holeinwall1; 
	public GameObject holeinwall2;
	public GameObject holeinwall3;
	public GameObject holeinwall4;
	public GameObject holeinwall5;
	public GameObject holeinwall6;
	public GameObject poof;
	public GameObject obelisk1;
	public GameObject obelisk2;
	public GameObject obelisk3;
	public GameObject hostage1;
	public GameObject hostage2;
	public GameObject hostage3;
	public GameObject alien1;
	public GameObject alien2;
	public GameObject alien3;
	public GameObject alien4;
	public GameObject alien5;
	public GameObject intel1;
	public GameObject intel2;
	public GameObject turret1;
	public GameObject turret2;
	public GameObject turret3;
	public GameObject motorbike;
	public GameObject bikespawn;
	public GameObject player;

	public AudioSource soundplayermusic;
	public AudioSource soundplayer;

	public AudioClip infestationmusic;

	public AudioClip startvoice1;
	public AudioClip startvoice2;
	public AudioClip startvoice3;
	public AudioClip startvoice4;
	public AudioClip startvoice5;
	public AudioClip startvoice6;
	public AudioClip startvoice7;
	public AudioClip startvoice8;
	public AudioClip startvoice9;
	public AudioClip startvoice10;
	public AudioClip startvoice11;
	public AudioClip startvoice12;
	public AudioClip startvoice13;
	public AudioClip startvoice14;
	public AudioClip startvoice15;
	public AudioClip startvoice16;
	public AudioClip mission1start;
	public AudioClip mission2start;
	public AudioClip mission3start;
	public AudioClip mission4start;
	public AudioClip mission5start;
	public AudioClip mission6start;
	public AudioClip missioncomplete1;
	public AudioClip missioncomplete2;
	public AudioClip missioncomplete3;
	public AudioClip missioncomplete4;
	public AudioClip missioncomplete5;
	public AudioClip missioncomplete6;

	void Start () {
		Destroy (GameObject.Find ("MusicHolderNotDestroy"));
		soundplayermusic.clip = infestationmusic;
		soundplayermusic.Play (); 
		///
		missionsactive = false;
		chatboxobject.SetActive (false);
		lockeddoor1 = GameObject.Find ("LockedDoor1");
		lockeddoor2 = GameObject.Find ("LockedDoor2");
		lockeddoor3 = GameObject.Find ("LockedDoor3");
		lockeddoor4 = GameObject.Find ("LockedDoor4");
		lockeddoor5 = GameObject.Find ("LockedDoor5");
		lockeddoor6 = GameObject.Find ("LockedDoor6");
		lockeddoor7 = GameObject.Find ("LockedDoor7");
		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		gunboxcode = GameObject.Find ("GunBox").GetComponent<GunBox> ();
		extramotorbikecode = GameObject.Find ("Motorbike Zombie").GetComponent<Extra> ();
		increaseorder = 0;
		ragdollorder = 0;
		gamemoney = 0; 
		gamemoneyui.text = "$" + gamemoney.ToString ();
		wave = 1; 
		wavesui.text = "Wave - " + wave.ToString ();
		wavesui.gameObject.SetActive (false);
		zombiesleft = 0;
		zombiesleftui.text = "Zombies Left - " + zombiesleft.ToString ();
		zombiesleftui.gameObject.SetActive (false);
		globaltimer = 5;
		nextwaveui.text = "Next Wave - " + globaltimer.ToString ();
		nextwaveui.gameObject.SetActive (false);
		zombieshealth = 2; 
		///Infinity Ones
		zombiespawnamountholder = 50;
		zombieshealthholder = 16;
		boxtimer = 0;
		boxtimeractive = false;
		killthemall = false;
		quicktimer = 0;
		missionscomplete = 0;
		//
		enemieskilled = 0;
		headshots = 0;
		wavessurvived = 0;
		//
		missioncounter = 0;
		hidethemissions();
	}

	public void hidethemissions() {
		obelisk1.SetActive (false);
		obelisk2.SetActive (false);
		obelisk3.SetActive (false);
		hostage1.SetActive (false);
		hostage2.SetActive (false);
		hostage3.SetActive (false);
		alien1.SetActive (false);
		alien2.SetActive (false);
		alien3.SetActive (false);
		alien4.SetActive (false);
		alien5.SetActive (false);
		intel1.SetActive (false);
		intel2.SetActive (false);
		turret1.SetActive (false);
		turret2.SetActive (false);
		turret3.SetActive (false);
		motorbike.SetActive (false);
	}

	void Update() {

//		if (zombiesleft <= 0) {
//			zombiesleft = 0;
//		}

		if (chattrue == true && missionsactive == false) {
			chattimer++; 
			if (chattimer >= 250) {
				chattrue = false;
				chattimer = 0;
				chatboxobject.SetActive (false);
			}

		}



		if (globaltimer <= 0 && runonce == false) {
			///Spawning
			thewaves();
			///
			zombiesleftui.text = "Zombies Left : " + zombiespawnamount.ToString ();
			runonce = true;
		}

		spawn ();

		if (zombiesleft <= 0 && runonce == true && globaltimer <= 0) {
			wave++; 
			wavesui.text = "Wave - " + wave.ToString ();
			runonce = false;
			nextwaveui.gameObject.SetActive (true);
			globaltimer = 5; 
		}


		if (shopcode.isvisible == false) {
			globaltimer -= Time.deltaTime;
			nextwaveui.text = "Next Wave - " + globaltimer.ToString ("f1");
			if (globaltimer <= 0) {
				nextwaveui.gameObject.SetActive (false);
			}


		}
			
		////Box Re-appear countdown
		if (boxtimeractive == true) {
			boxtimer++;
			if (boxtimer >= 2000) {
				gunboxcode.newspawn ();
				boxtimer = 0;
				boxtimeractive = false;
			}
		}
		////Slow Mo Countdown
		if (slowmotimeractive == true) {
			slowmotimer++;

			if (slowmotimer >= 600) {
				Time.timeScale = 1f;
				slowmotimer = 0;
				slowmotimeractive = false;
			}
		}
		if (killthemall == true) {
			quicktimer++;
			if (quicktimer >= 10) {
				quicktimer = 0;
				killthemall = false;
			}
		}
	}


	///Main Functions

	public void startgame() {
		wavesui.gameObject.SetActive (true);
		zombiesleftui.gameObject.SetActive (true);
		nextwaveui.gameObject.SetActive (true);
		gamemoney = 0; 
		runonce = false;
		spawnspeed = 100; 
		zombieshealth = 2; 
		wave = 1; 
		increaseorder = 0;
		ragdollorder = 0;
		globaltimer = 5;
		zombiesleft = 0;
		zombiespawnamount = 0;
		UpdateText ();
	}

	void spawn() {
		spawntimer++;

		if (shopcode.isvisible == false) {
			////Start Room
			if (spawntimer > spawnspeed) {

				if (zombiespawnamount > 0) {
					holder = Instantiate (zombie, doorspawnpoint1.transform.position, transform.rotation);
					increaseorder += 6;
					holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
					zombiespawnamount--;
				}

				///Hole1
				if (wave >= 5) {
					if (zombiespawnamount > 0) {
						holder = Instantiate (headcrab, holeinwall1.transform.position, Quaternion.Euler (new Vector3 (0, 0, 90)));
						holder.GetComponent<Enemy> ().transform.localScale = new Vector3 (0.223f, 0.223f, 0.223f);
						increaseorder += 6;
						holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
						zombiespawnamount--;
					}
				}
				if (wave >= 7) {
					if (zombiespawnamount > 0) {
						holder = Instantiate (headcrab, holeinwall2.transform.position, Quaternion.Euler (new Vector3 (0, 0, -90)));
						holder.GetComponent<Enemy> ().transform.localScale = new Vector3 (-0.223f, 0.223f, 0.223f);
						increaseorder += 6;
						holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
						zombiespawnamount--;
					}
				}
				///
				//////
				////TopMiddleleftArea
				if (lockeddoor1.activeSelf == false && zombiespawnamount > 0) {
					holder = Instantiate (zombie, doorspawnpoint8.transform.position, transform.rotation);
					increaseorder += 6;
					holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
					///////////
					zombiespawnamount--;
				}
				///TopMiddleRightArea
				if (lockeddoor2.activeSelf == false && zombiespawnamount > 0) {
					holder = Instantiate (zombie, doorspawnpoint2.transform.position, transform.rotation);
					increaseorder += 6;
					holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
					///////////
					zombiespawnamount--;
				}
				///BottomRightOnly
				if (lockeddoor4.activeSelf == false && zombiespawnamount > 0) {
					holder = Instantiate (zombie, doorspawnpoint4.transform.position, transform.rotation);
					increaseorder += 6;
					holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
					///////////
					zombiespawnamount--;
					if (zombiespawnamount > 0) {
						holder = Instantiate (headcrab, holeinwall4.transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
						holder.GetComponent<Enemy> ().transform.localScale = new Vector3 (-0.223f, 0.223f, 0.223f);
						increaseorder += 6;
						holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
						zombiespawnamount--;
					}
				}
				///BottomLeftOnly
				if (lockeddoor6.activeSelf == false && zombiespawnamount > 0) {
					holder = Instantiate (zombie, doorspawnpoint6.transform.position, transform.rotation);
					increaseorder += 6;
					holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
					///////////
					zombiespawnamount--;
					if (zombiespawnamount > 0) {
						holder = Instantiate (headcrab, holeinwall6.transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
						holder.GetComponent<Enemy> ().transform.localScale = new Vector3 (-0.223f, 0.223f, 0.223f);
						increaseorder += 6;
						holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
						zombiespawnamount--;
					}
				}
				///TopRightAreaIncludingBottomRight
				if (lockeddoor3.activeSelf == false && zombiespawnamount > 0) {
					holder = Instantiate (zombie, doorspawnpoint3.transform.position, transform.rotation);
					increaseorder += 6;
					holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
					///////////
					zombiespawnamount--;
					//holes
					if (zombiespawnamount > 0) {
						holder = Instantiate (headcrab, holeinwall3.transform.position, Quaternion.Euler (new Vector3 (0, 0, -90)));
						holder.GetComponent<Enemy> ().transform.localScale = new Vector3 (-0.223f, 0.223f, 0.223f);
						increaseorder += 6;
						holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
						zombiespawnamount--;
					}
					////
					///

					playernearby2 = Vector2.Distance (doorspawnpoint4.transform.position, player.transform.position);

					if (playernearby2 < 8) {
						if (zombiespawnamount > 0) {
							holder = Instantiate (zombie, doorspawnpoint4.transform.position, transform.rotation);
							increaseorder += 6;
							holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
							///////////
							zombiespawnamount--;
						}
						//holes
						if (zombiespawnamount > 0) {
							holder = Instantiate (headcrab, holeinwall4.transform.position, Quaternion.Euler (new Vector3 (0, 0, -90)));
							holder.GetComponent<Enemy> ().transform.localScale = new Vector3 (-0.223f, 0.223f, 0.223f);
							increaseorder += 6;
							holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
							zombiespawnamount--;
						}
					}
				}

				//bottomdoor
				if (lockeddoor5.activeSelf == false && zombiespawnamount > 0 && lockeddoor4.activeSelf == false) {
					holder = Instantiate (zombie, doorspawnpoint5.transform.position, transform.rotation);
					increaseorder += 6;
					holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
					zombiespawnamount--;
				}

				///TopLeftAreaIncludingBottomLeft
				if (lockeddoor7.activeSelf == false && zombiespawnamount > 0) {
					holder = Instantiate (zombie, doorspawnpoint7.transform.position, transform.rotation);
					increaseorder += 6;
					holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
					zombiespawnamount--;
					///////////
					///Hole1
					if (zombiespawnamount > 0) {
						holder = Instantiate (headcrab, holeinwall5.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
						holder.GetComponent<Enemy> ().transform.localScale = new Vector3 (0.223f, 0.223f, 0.223f);
						increaseorder += 6;
						holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
						zombiespawnamount--;
					}
				

					playernearby = Vector2.Distance (doorspawnpoint6.transform.position, player.transform.position);

					if (playernearby < 6) {
						if (zombiespawnamount > 0) {
							holder = Instantiate (zombie, doorspawnpoint6.transform.position, transform.rotation);
							increaseorder += 6;
							holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
							///////////
							zombiespawnamount--;
						}
						///Hole2
						if (zombiespawnamount > 0) {
							holder = Instantiate (headcrab, holeinwall6.transform.position, Quaternion.Euler (new Vector3 (0, 0, 90)));
							holder.GetComponent<Enemy> ().transform.localScale = new Vector3 (0.223f, 0.223f, 0.223f);
							increaseorder += 6;
							holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;
							zombiespawnamount--;
						}
					}




				}


				spawntimer = 0; 
			}
				
		}
	}
		
	public void UpdateText() {
		zombiesleftui.text = "Zombies Left : " + zombiesleft.ToString ();
		gamemoneyui.text = "$" + gamemoney.ToString ();
		wavesui.text = "Wave - " + wave.ToString ();
		nextwaveui.text = "Next Wave - " + globaltimer.ToString ("f1");
	}
		

	void thewaves() {

		//spawnspeed start 100
		if (wave == 1) {
			zombiespeed = -0.4f; 
			zombiespawnamount = 5;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 2) {
			zombiespeed = -0.5f; 
			zombiespawnamount = 6;
			spawnspeed = 80; 
			zombieshealth = 3; 
			zombiesleft = zombiespawnamount;
		}
		if (wave == 3) {
			zombiespeed = -0.7f; 
			zombiespawnamount = 7;
			zombieshealth = 4; 
			zombiesleft = zombiespawnamount;
			///
			whichmission = Random.Range (0, 2);
			startmissions();
		}
		if (wave == 4) {
			zombiespeed = -0.8f; 
			zombiespawnamount = 7;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 5) {
			zombiespeed = -0.9f; 
			zombiespawnamount = 8;
			spawnspeed = 75; 
			zombieshealth = 5; 
			zombiesleft = zombiespawnamount;
		}
		if (wave == 6) {
			zombiespeed = -1f; 
			zombiespawnamount = 8;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 7) {
			zombiespeed = -1.1f; 
			zombiespawnamount = 8;
			spawnspeed = 75; 
			zombiesleft = zombiespawnamount;
		}
		if (wave == 8) {
			zombiespeed = -1.2f; 
			zombiespawnamount = 9;
			spawnspeed = 70; 
			zombieshealth = 6;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 9) {
			zombiespeed = -1.2f; 
			zombiespawnamount = 12;
			spawnspeed = 65; 
			zombiesleft = zombiespawnamount;
		}
		if (wave == 10) {
			zombiespeed = -1.3f; 
			zombiespawnamount = 13;
			spawnspeed = 65; 
			zombieshealth = 7; 
			zombiesleft = zombiespawnamount;
			///
			if (missionsactive == false) {
				whichmission = Random.Range (2, 5);
				startmissions();
			}
		}
		if (wave == 11) {
			zombiespeed = -1.4f; 
			zombiespawnamount = 15;
			spawnspeed = 65; 
			zombieshealth = 8; 
			zombiesleft = zombiespawnamount;
		}
		if (wave == 12) {
			zombiespeed = -1.5f; 
			zombiespawnamount = 18;
			spawnspeed = 65; 
			zombieshealth = 9; 
			zombiesleft = zombiespawnamount;
		}
		if (wave == 13) {
			zombiespeed = -1.6f; 
			zombiespawnamount = 22;
			spawnspeed = 60; 
			zombieshealth = 10;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 14) {
			zombiespeed = -1.7f; 
			zombiespawnamount = 25;
			spawnspeed = 55; 
			zombieshealth = 11;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 15) {
			zombiespeed = -1.8f; 
			zombiespawnamount = 30;
			spawnspeed = 54; 
			zombieshealth = 12;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 16) {
			zombiespeed = -1.8f; 
			zombiespawnamount = 35;
			spawnspeed = 50; 
			zombieshealth = 13;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 17) {
			zombiespeed = -1.8f; 
			zombiespawnamount = 40;
			spawnspeed = 45; 
			zombieshealth = 14;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 18) {
			zombiespeed = -1.8f; 
			zombiespawnamount = 45;
			spawnspeed = 40; 
			zombieshealth = 15;
			zombiesleft = zombiespawnamount;
		}
		if (wave == 19) {
			zombiespeed = -1.8f; 
			zombiespawnamount = 50;
			spawnspeed = 35; 
			zombieshealth = 16;
			zombiesleft = zombiespawnamount;
		}
		//Infinity Wave
		if (wave >= 20) {
			increaseforever ();
			zombiespawnamount = zombiespawnamountholder;
			zombieshealth = zombieshealthholder;
			zombiesleft = zombiespawnamount;
			//
			missioncounter += 1; 
			if (missioncounter >= 4) {
				if (missionsactive == false) {
					whichmission = Random.Range (0, 6);
					startmissions();
					missioncounter = 0;
				}
			}
		}
	}

	void increaseforever() {
		zombiespawnamountholder += 3; 
		zombieshealthholder += 3; 
	}


	public void randomchatter() {

		chattrue = true;
		chatboxobject.SetActive (true);

		chatroll = Random.Range (0, 16);

		if (chatroll == 0) {
			soundplayer.PlayOneShot (startvoice1, 0.7f); 
			chat.text = "Oh you're so gonna die eggbot...Uhh I mean good luck";
		}
		if (chatroll == 1) {
			soundplayer.PlayOneShot (startvoice2, 0.7f); 
			chat.text = "Get ready eggbot! These grueling monsters won't go easy";
		}
		if (chatroll == 2) {
			soundplayer.PlayOneShot (startvoice3, 0.7f); 
			chat.text = "Remember that unlocking new areas will stop you getting trapped and help you find new things!";
		}
		if (chatroll == 3) {
			soundplayer.PlayOneShot (startvoice4, 0.7f); 
			chat.text = "The better guns are in the other areas! Make your way there quick eggbot";
		}
		if (chatroll == 4) {
			soundplayer.PlayOneShot (startvoice5, 0.7f); 
			chat.text = "I remember the day before the zombies took over...we got to kill all the humans without competition";
		}
		if (chatroll == 5) {
			soundplayer.PlayOneShot (startvoice6, 0.7f); 
			chat.text = "If you get stuck down the bottom, turn on both levers to use the teleporter!";
		}
		if (chatroll == 6) {
			soundplayer.PlayOneShot (startvoice7, 0.7f); 
			chat.text = "You can use the revive vending machine 3 times before it blows up. Whoever made it was a bad engineer.";
		}
		if (chatroll == 7) {
			soundplayer.PlayOneShot (startvoice8, 0.7f); 
			chat.text = "The glock is completely useless. Get a new gun as soon as possible. Whoever made it is a terrible programmer";
		}
		if (chatroll == 8) {
			soundplayer.PlayOneShot (startvoice9, 0.7f); 
			chat.text = "Arghhh walking bugs on the walls gives me the jeebers, shoot them down! We ran out of bug spray";
		}
		if (chatroll == 9) {
			soundplayer.PlayOneShot (startvoice10, 0.7f); 
			chat.text = "The Anti-Grav gun is awesome! you should unlock it as soon as possible";
		}
		if (chatroll == 10) {
			soundplayer.PlayOneShot (startvoice11, 0.7f); 
			chat.text = "Theres grenades on the left, or theres an SMG on the right. Which would you prefer?";
		}
		if (chatroll == 11) {
			soundplayer.PlayOneShot (startvoice12, 0.7f); 
			chat.text = "How many zombies does it take to change a lightbulb? Probably about 50 as they pile up";
		}
		if (chatroll == 12) {
			soundplayer.PlayOneShot (startvoice13, 0.7f); 
			chat.text = "If you run out of ammo just go to the glock-o-matic for a free glock! even though its a bad weapon it will keep you alive";
		}
		if (chatroll == 13) {
			soundplayer.PlayOneShot (startvoice14, 0.7f); 
			chat.text = "I hate to tell you this eggbot but we could only afford to make one eggbot so it's just you with no backup";
		}
		if (chatroll == 14) {
			soundplayer.PlayOneShot (startvoice15, 0.7f); 
			chat.text = "The more you kill the more money you make! budget your money just like your mumma told ya too";
		}
		if (chatroll == 15) {
			soundplayer.PlayOneShot (startvoice16, 0.7f); 
			chat.text = "Shooting a zombie in the head will do double the damage of the gun";
		}
	}



	public void startmissions() {

		chattrue = true;
		missionsactive = true;
		chatboxobject.SetActive (true);

		//whichmission = Random.Range (0, 5);


		if (whichmission == 0) {
			soundplayer.PlayOneShot (mission1start, 0.7f); 
			chat.text = "3 Evil Obelisks have spawned in the top left Area! Quick kill them all for an extra $100!";
			obelisk1.SetActive (true);
			Instantiate (poof, obelisk1.transform.position, obelisk1.transform.rotation);
			obelisk2.SetActive (true);
			Instantiate (poof, obelisk2.transform.position, obelisk1.transform.rotation);
			obelisk3.SetActive (true);
			Instantiate (poof, obelisk3.transform.position, obelisk1.transform.rotation);
			obeliskamount = 3; 
		}
		if (whichmission == 1) {
			soundplayer.PlayOneShot (mission2start, 0.7f); 
			chat.text = "3 Egg Hostages are captured in the top right area! Quick rescue them for $100!";
			hostage1.SetActive (true);
			Instantiate (poof, hostage1.transform.position, hostage1.transform.rotation);
			hostage2.SetActive (true);
			Instantiate (poof, hostage2.transform.position, hostage2.transform.rotation);
			hostage3.SetActive (true);
			Instantiate (poof, hostage3.transform.position, hostage3.transform.rotation);
			hostageamount = 3; 
		}
		if (whichmission == 2) {
			soundplayer.PlayOneShot (mission3start, 0.7f); 
			chat.text = "5 alien pods have appeared in the bottom right! Destroy the scourge for $100!";
			alien1.SetActive (true);
			Instantiate (poof, alien1.transform.position, alien1.transform.rotation);
			alien2.SetActive (true);
			Instantiate (poof, alien2.transform.position, alien2.transform.rotation);
			alien3.SetActive (true);
			Instantiate (poof, alien3.transform.position, alien3.transform.rotation);
			alien4.SetActive (true);
			Instantiate (poof, alien4.transform.position, alien4.transform.rotation);
			alien5.SetActive (true);
			Instantiate (poof, alien5.transform.position, alien5.transform.rotation);
			alienamount = 5; 
		}
		if (whichmission == 3) {
			soundplayer.PlayOneShot (mission4start, 0.7f); 
			intelamount = 2; 
			chat.text = "Eggbot we need you to recover 2 intel pieces in the top right and top left of the map!";
			intel1.SetActive (true);
			Instantiate (poof, intel1.transform.position, intel1.transform.rotation);
			intel2.SetActive (true);
			Instantiate (poof, intel2.transform.position, intel2.transform.rotation);
		}
		///
		if (whichmission == 4) {
			soundplayer.PlayOneShot (mission5start, 0.7f); 
			turretamount = 3; 
			chat.text = "Eggbot the security system has been activated. Destroy the turrets in the bottom areas for $150!";
			turret1.SetActive (true);
			Instantiate (poof, turret1.transform.position, turret1.transform.rotation);
			turret2.SetActive (true);
			Instantiate (poof, turret2.transform.position, turret2.transform.rotation);
			turret3.SetActive (true);
			Instantiate (poof, turret3.transform.position, turret3.transform.rotation);
		}
		if (whichmission == 5) {
			soundplayer.PlayOneShot (mission6start, 0.7f); 
			motorbikeamount = 1; 
			chat.text = "Holy moly theres a zombie riding a motorbike in the bottom area! Kill it quick! Reward is $200";
			Instantiate (poof, bikespawn.transform.position, bikespawn.transform.rotation);
			extramotorbikecode.health = 50; 
			motorbike.transform.position = bikespawn.transform.position;
			motorbike.SetActive (true);
		}
			
	}


	public void endingsound() {

		if (whichmission == 0) {
			soundplayer.PlayOneShot (missioncomplete1, 1f); 
		}
		if (whichmission == 1) {
			soundplayer.PlayOneShot (missioncomplete2, 1f); 
		}
		if (whichmission == 2) {
			soundplayer.PlayOneShot (missioncomplete3, 1f); 
		}
		if (whichmission == 3) {
			soundplayer.PlayOneShot (missioncomplete4, 1f); 
		}
		if (whichmission == 4) {
			soundplayer.PlayOneShot (missioncomplete5, 1f); 
		}
		if (whichmission == 5) {
			soundplayer.PlayOneShot (missioncomplete6, 1f); 
		}

	}

}
