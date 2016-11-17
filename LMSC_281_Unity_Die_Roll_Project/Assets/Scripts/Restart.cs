//Antonio Espinosa Holguín
//November 17th, 2016
//Very simple restart function
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	public string buttonName = "Fire1";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown(buttonName)) {
			SceneManager.LoadScene("DiceRoller3d");
		}
	}
}
