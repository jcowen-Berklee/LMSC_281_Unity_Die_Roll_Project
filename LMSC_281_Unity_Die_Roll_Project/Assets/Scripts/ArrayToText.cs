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

	// Use this for initialization
	void Start () {
		//test
		stringOfValues = "test text";

		fileToWriteTo = Application.dataPath + "/Resources/Data.txt";
	}
	
	// Update is called once per frame
	void Update () {
		if (runWriteArray) {
			WriteArray ();
		}
	}
	public void WriteArray () {
		File.AppendAllText (fileToWriteTo, stringOfValues);
}
}
