using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject objectToFollow;
	public float speed = 2.0f;



	void FixedUpdate () {


			float inter = speed * Time.deltaTime;

			Vector3 position = this.transform.position;
			position.x = Mathf.Lerp (transform.position.x, objectToFollow.transform.position.x, inter); 
			position.y = Mathf.Lerp (transform.position.y, objectToFollow.transform.position.y, inter); 

			if (position.x < -50) {
				position.x = -50;
			}
			if (position.y < -47) {
				position.y = -47;
			}

			this.transform.position = position;

	}
}
