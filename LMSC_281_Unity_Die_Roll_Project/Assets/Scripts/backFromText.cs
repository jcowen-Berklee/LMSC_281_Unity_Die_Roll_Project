//Antonio Espinosa Holguín
//November 17th, 2016
//based on walkthrough
using UnityEngine;
using System.Collections;
using System.IO;

public class backFromText : MonoBehaviour {

	string allTextString;
	public bool readText = false;
	public int [] intArray = new int[100];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (readText) {
			ReadTextFromFile ();
			readText = false;
	
	}
	}
	public void ReadTextFromFile () {
		allTextString = File.ReadAllText (Application.dataPath + "/Resources/Data.txt");
		Debug.Log (allTextString);
		readText = false;

		for (int i = 0; i < 100; i++){
			string tempString = allTextString [i].ToString ();

			intArray [i] = System.Int32.Parse (tempString);
			//Debug.Log (tempString);
			
			
}
}
}