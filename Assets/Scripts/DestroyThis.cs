using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour {

	public float destroyspeed; 

	void Start () {
		Destroy (gameObject, destroyspeed);
	}
	

}
