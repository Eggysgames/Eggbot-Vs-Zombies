using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

	private Rigidbody2D thisobject;
	private Shop shopcode;
	private Vector3 position;
	private Quaternion rotation;

	void Start () {
		thisobject = GetComponent<Rigidbody2D> ();
		shopcode = GameObject.Find ("Shop").GetComponent<Shop> ();
		position = transform.position;
		rotation = transform.rotation;
		thisobject.Sleep ();
	}
	

	void Update () {
		if (shopcode.isvisible == true) {
			thisobject.velocity = Vector3.zero;
			transform.position = position;
			transform.rotation = rotation;
		}
	}
}
