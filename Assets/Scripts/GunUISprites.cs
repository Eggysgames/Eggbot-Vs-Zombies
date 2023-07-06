using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunUISprites : MonoBehaviour {


	public Sprite[] uiguns;
	public int guntype;

	public Vector3 widthOriginal;
	public Vector3 widthRifles;
	public Vector3 widthGrenades;

	public bool changeable; 

	void Start() {

		widthOriginal = transform.localScale;

	}

	public void switchweapons() {
		
		if (guntype <= uiguns.Length) {
			GetComponent<Image> ().sprite = uiguns [guntype];
		}

		if (changeable == true) {
			if (guntype <= 9) {
				transform.localScale = widthOriginal; 
			}
			if (guntype >= 10 && guntype <= 16) {
				transform.localScale = widthRifles; 
			}
			if (guntype >= 17 && guntype <= 18) {
				transform.localScale = widthGrenades; 
			}
			if (guntype >= 19) {
				transform.localScale = widthRifles; 
			}

		}
	}

	public void switchweaponssprites() {
		GetComponent<SpriteRenderer> ().sprite = uiguns [guntype];


	}

}
