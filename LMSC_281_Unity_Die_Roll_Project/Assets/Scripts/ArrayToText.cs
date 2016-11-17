//Antonio Espinosa Holguín
//November 17th, 2016
//Based on text to file walkthrough
using UnityEngine;
using System.Collections;
using System.IO;

public class ArrayToText : MonoBehaviour {

	string fileToWriteTo;
	public string stringOfValues;
	public bool runWriteArray = false;
	GameObject dieObject;

	// Use this for initialization
	void Start () {
		//test
		stringOfValues = "";

		fileToWriteTo = Application.dataPath + "/Resources/Data.txt";

		dieObject = GameObject.Find ("Die");
	}
	
	// Update is called once per frame
	void Update () {
		if (runWriteArray) {
			WriteArray ();
			runWriteArray = false;
		}
	}
	public void WriteArray () {

		for (int i = 0; i < dieObject.GetComponent<DisplayCurrentDieValue> ().rollResults.Length; i++) {
			int intArrayValue = dieObject.GetComponent<DisplayCurrentDieValue> ().rollResults [i];
			stringOfValues = stringOfValues + intArrayValue.ToString ();
		}
		stringOfValues = stringOfValues + "/r/n";

		File.AppendAllText (fileToWriteTo, stringOfValues);
		//for cleanup
		//File.WriteAllText (fileToWriteTo, stringOfValues);
}
}
