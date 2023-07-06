using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody2D bullet; 
	private Character playercode;

	public GameObject blood;
	public GameObject ricochet;
	//private int angle;

	void Start () {
		bullet = GetComponent<Rigidbody2D> ();
		//angle = 90;
		//transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
		//Debug.Log(transform.rotation);
	}

	void Update () {
		bullet.velocity = transform.right*3;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.layer == 8) {
			Instantiate (ricochet, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		if (col.gameObject.tag == "Player") {
			playercode = GameObject.Find ("EggHead").GetComponent<Character> ();
			Instantiate (blood, transform.position, transform.rotation);
			if (playercode.myrenderer == true) {
				playercode.hurtplayer ();
				//playercode.hitholder = hitholder;
				playercode.enemyhitting = "headcrab";
			}
			Destroy (gameObject);
		}
	}
}
