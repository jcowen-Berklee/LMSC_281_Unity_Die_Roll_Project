//Raz Ezra
//rezra@berklee.edu
//Manage game

using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class GameController : MonoBehaviour {

	public int rolls; //store number of rolls
	public int timeScale; //store time scale


	// Use this for initialization
	void Start () {
		Time.timeScale = timeScale; //set time scale
	}
	
	public void Restart(){ //restart level
		Application.LoadLevel (Application.loadedLevel);
	}

	public void DeleteLogs() { //replace text in all files to nothing
		
		//the WriteAllText will delete any existing text from the file it is writing to
		File.WriteAllText ("Assets/Text/ResultsRatio.txt","");
		File.WriteAllText ("Assets/Text/AllResults.txt","");
		
		//the AppendAllText will start writing to the file from wherever the last bit of data is found
//		File.AppendAllText ("Assets/Text/ResultsRatio.txt",myTextData);
	}
}
