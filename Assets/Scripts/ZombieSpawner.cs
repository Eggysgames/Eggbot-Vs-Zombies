using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

	private Shop shopcode;
	public int spawntimer;
	public int spawnspeed;
	public GameObject zombie; 
	public Transform spawnpoint;
	public GameObject holder;
	public int increaseorder; 

	void Start () {
		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		increaseorder = 0;
	}
	

	void Update () {

		if (shopcode.isvisible == false) {
			spawntimer++;

			if (spawntimer > spawnspeed) {

				holder = Instantiate (zombie, spawnpoint.transform.position, transform.rotation);
				increaseorder++;
				holder.GetComponent<SpriteRenderer> ().sortingOrder = increaseorder;

				spawntimer = 0;

			}
		}	
	}
}
