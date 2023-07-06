using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHitPoint : MonoBehaviour {


	private Zombie zombiecode;
	private Enemy enemycode;
	public int hitspots; 

	public bool isHeadcrab;

	void Start () {
		zombiecode = GetComponentInParent<Zombie> ();
		if (isHeadcrab == true) {
			enemycode = GetComponentInParent<Enemy> ();
		}
	}
	

	void OnTriggerStay2D (Collider2D col) {
		if (isHeadcrab == false) {
			if (col.gameObject.tag == "Player") {
				zombiecode.hurtplayer ();
				zombiecode.hitholder = hitspots;
			}
		}
		if (isHeadcrab == true) {
			if (col.gameObject.tag == "Player") {
				enemycode.hurtplayer ();
				enemycode.hitholder = 1;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (isHeadcrab == true) {
			if (col.gameObject.tag == "Player") {
				enemycode.resettimer();
			}
		}
	}
}
