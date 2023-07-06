using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFadeOut : MonoBehaviour {

	private float colourfade = 1;
	private Color mycolour; 

	public float deathremovetimer;
	public bool isThisParticle;
	public bool isThisMesh;
	public bool isThisSprite;


	public int layerOrder;

	void Start () {
		if (isThisParticle) {
			mycolour = GetComponent<Renderer> ().material.GetColor ("_TintColor");
		}
		if (isThisMesh) {
			mycolour = GetComponent<MeshRenderer> ().material.color;
		}
		if (isThisSprite) {
			mycolour = GetComponent<SpriteRenderer> ().material.color;
		}
		mycolour.a = 1f;
	}
	

	void Update () {

			deathremovetimer -= Time.deltaTime;

			if (deathremovetimer <= 0) {
				colourfade -= 0.03f;
				mycolour.a = colourfade;
				///
				if (isThisParticle) {
					GetComponent<Renderer> ().material.SetColor ("_TintColor", mycolour);
				}
				else if (isThisMesh) {
					GetComponent<MeshRenderer> ().material.color = mycolour;
				}
				else if (isThisSprite) {
					GetComponent<SpriteRenderer> ().material.color = mycolour;
				}
				///
				//Use CrossFade for Images//
				if (colourfade <= 0) {
					Destroy (gameObject);
				}
			}
		
	}
}
