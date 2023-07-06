using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadingBasic : MonoBehaviour {

	public Image blackbox; 
	public bool faderunning;
	public Text loading;
	public string myscene;

	private float timer; 
	private bool runonce;
	public bool IsThisFadingIn;

	void Start () {
		timer = 20;
		IsThisFadingIn = true;
		runonce = false;
		faderunning = false;
		blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (20);
		loading.GetComponent<Text> ().canvasRenderer.SetAlpha (0);
	}
	

	void Update () {

		//Appearing
		if (IsThisFadingIn == true) {
			timer -= 0.2f; 
			///
			if (timer > 0) {

			
				blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (timer);
				//loading.GetComponent<Text> ().canvasRenderer.SetAlpha (timer);
			}
			if (timer <= 0) {
				IsThisFadingIn = false;
			}
		}

		///Dissapearing
		if (faderunning == true) {
			timer += 0.2f; 
			///
			if (timer < 20) {
				blackbox.GetComponent<Image> ().canvasRenderer.SetAlpha (timer);
				loading.GetComponent<Text> ().canvasRenderer.SetAlpha (timer);
			}
			if (timer >= 20 && runonce == false) {
				SceneManager.LoadSceneAsync (myscene); 
				runonce = true;
			}
		}
	}
}
