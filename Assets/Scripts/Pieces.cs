using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour {

	private Rigidbody2D pieces;
	private float colourfade = 1;
	private Color mycolour; 
	private Shop shopcode;

	private bool beginremove = false;
	public float deathremove = 60f;
	public Main maincode;
	public GameObject player;
	public int min;
	public int max; 
	public Sprite[] mysprites;


	private int roll;

	void Start () {

		beginremove = true;
		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		this.GetComponent<SpriteRenderer> ().sortingOrder = maincode.piecesorder;
		maincode.piecesorder += 1;


		player = GameObject.Find ("EggHead");
		pieces = GetComponent<Rigidbody2D> ();
		mycolour = GetComponent<SpriteRenderer> ().color;
		mycolour.a = 1f;
		GetComponent<SpriteRenderer> ().color = mycolour;

		if (player != null) {
			if (player.transform.position.x < transform.position.x) {
				pieces.AddForce (new Vector2 (2, 2));
			}
			if (player.transform.position.x > transform.position.x) {
				pieces.AddForce (new Vector2 (-2, 2));
			}
		}


		roll = Random.Range (min, max);

		GetComponent<SpriteRenderer> ().sprite = mysprites [roll];


	}
	
	void Update() {

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

		if (shopcode.isvisible == true) {
			Destroy (gameObject);
		}
		if (transform.position.y < -55) {
			Destroy (gameObject);
		}

	}

}
