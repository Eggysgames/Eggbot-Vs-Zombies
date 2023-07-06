using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {


	private Zombie zombieCode; 
	private Enemy enemycode; 

	public int damage;
	public int timer; 
	public int firetimer; 
	public float xpos; 
	public bool bigexplosion;
	public bool smallexplosion;
	public bool megaparticles;
	public bool fire;
	public int firedamage;

	void Update() {
		timer++; 
	}


	void OnTriggerStay2D (Collider2D col) {

		if (fire) {
			if (col.gameObject.tag == "Enemy") {

				zombieCode = col.transform.gameObject.GetComponent<Zombie> ();

				firetimer++;

				if (zombieCode.dying == false && firetimer > 10) {
					zombieCode.bodydamage = firedamage;
					zombieCode.store = 2; 
					//xpos = transform.position.x;
					zombieCode.xposholder = xpos;
					//zombieCode.guntype = "m32";
					zombieCode.Damaged ();
					firetimer = 0;
				}
			}
			if (col.gameObject.tag == "CrabEnemy") {

				enemycode = col.transform.gameObject.GetComponent<Enemy> ();

				firetimer++;

				if (enemycode.dying == false && firetimer > 10) {
					enemycode.bodydamage = firedamage;
					enemycode.store = 2; 
					//xpos = transform.position.x;
					enemycode.xposholder = xpos;
					//zombieCode.guntype = "m32";
					enemycode.Damaged ();
					firetimer = 0;
				}
			}
		}


		if (col.gameObject.tag == "Enemy") {

			zombieCode = col.transform.gameObject.GetComponent<Zombie> ();

			if (timer < 10) {
				if (bigexplosion) {
					if (zombieCode.dying == false) {
						zombieCode.bodydamage = damage;
						zombieCode.store = 2; 
						xpos = transform.position.x;
						zombieCode.xposholder = xpos;
						zombieCode.guntype = "bazooka";
						zombieCode.Damaged ();
					}
				}
				if (smallexplosion) {
					if (zombieCode.dying == false) {
						zombieCode.bodydamage = damage;
						zombieCode.store = 2; 
						xpos = transform.position.x;
						zombieCode.xposholder = xpos;
						zombieCode.guntype = "m32";
						zombieCode.Damaged ();
					}
				}
			}
			if (megaparticles) {
				if (zombieCode.dying == false) {
					zombieCode.bodydamage = damage;
					zombieCode.store = 2; 
					xpos = transform.position.x;
					zombieCode.xposholder = xpos;
					zombieCode.guntype = "mega";
					zombieCode.Damaged ();
				}
			}


		}
		///
		if (col.gameObject.tag == "CrabEnemy") {

			enemycode = col.transform.gameObject.GetComponent<Enemy> ();

			if (timer < 10) {
				if (bigexplosion) {
					if (enemycode.dying == false) {
						enemycode.bodydamage = damage;
						enemycode.store = 2; 
						xpos = transform.position.x;
						enemycode.xposholder = xpos;
						enemycode.guntype = "bazooka";
						enemycode.Damaged ();
					}
				}
				if (smallexplosion) {
					if (enemycode.dying == false) {
						enemycode.bodydamage = damage;
						enemycode.store = 2; 
						xpos = transform.position.x;
						enemycode.xposholder = xpos;
						enemycode.guntype = "m32";
						enemycode.Damaged ();
					}
				}
			}
			if (megaparticles) {
				if (enemycode.dying == false) {
					enemycode.bodydamage = damage;
					enemycode.store = 2; 
					xpos = transform.position.x;
					enemycode.xposholder = xpos;
					enemycode.guntype = "mega";
					enemycode.Damaged ();
				}
			}


		}
	}


}
