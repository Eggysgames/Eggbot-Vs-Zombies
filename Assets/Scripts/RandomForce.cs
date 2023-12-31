using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour {

	private Rigidbody2D myrigidbody;
	private Shop shopcode;
	private int roll; 

	public int forceAmount;

	void Start () {

		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		myrigidbody = GetComponent<Rigidbody2D> ();
		roll = Random.Range (1, 3);

		if (roll == 1) {
			myrigidbody.AddForce (new Vector2 (forceAmount, forceAmount));
		}
		if (roll == 2) {
			myrigidbody.AddForce (new Vector2 (-forceAmount, forceAmount));
		}

	}
	

	void Update () {

		if (shopcode.isvisible == true) {
			Destroy (gameObject);
		}
		
	}
}
