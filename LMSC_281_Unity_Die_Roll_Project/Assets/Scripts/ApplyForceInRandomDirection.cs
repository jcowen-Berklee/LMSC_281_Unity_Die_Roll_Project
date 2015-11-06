//example provided by http://www.cookingwithunity.com/
// modified by Raz Ezra
//rezra@berklee.edu
//Automatically rolls die and sends results to a different script to store it

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public float forceAmount = 10.0f; // stores the force factor
	public float torqueAmount = 10.0f; // stores the torque factor
	public ForceMode forceMode; // stores the force mode

	private bool rollComplete = false; //stores if a single roll has completes
	private GameController gameController; //to create an relationship with game controller script
	private DisplayCurrentDieValue displayCurrentValue; //to create an relationship with display current value script

	void Start(){
		//create a relationship with GameController script
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find 'GameController' Script");
		}
		//create a relationship with DisplayCurrentValue script
		displayCurrentValue = GetComponent<DisplayCurrentDieValue> ();
		//Call function to start rolling the die
		StartCoroutine (StartRolling ());

	}

	void Update(){
		if (!GetComponent<Rigidbody> ().IsSleeping ()) { //if the die is still moving (not asleep)
			rollComplete = false; //set rall complete to false
		}
	}
	
	void RollDie (){ //function to roll die
		if (GetComponent<Rigidbody> ().IsSleeping () && !rollComplete) { // if the cube is sleeping, and rollcomplete is false
			rollComplete = true; //set rollComplete true				
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode); //add force to rigidbody with random
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode); //add torque to rigidbody with random
		} 
			
	}


	IEnumerator StartRolling(){
		yield return new WaitForSeconds(1); //wait foe 1 second
		for (int i=0; i<gameController.rolls; i++) { //repeat the number of times set in GameController script
			RollDie(); //call function to roll die
			yield return new WaitForSeconds(5); //wait for five seconds (let the current roll end)
			displayCurrentValue.InsertResults (); //call a function in DisplayCurrentValue to store result
		}
		displayCurrentValue.GetRatio (); //call a function in DisplayCurrentValue to calculate and show ratio
	}
}


