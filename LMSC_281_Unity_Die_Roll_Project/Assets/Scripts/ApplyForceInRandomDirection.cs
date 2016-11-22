//example provided by http://www.cookingwithunity.com/
//Antonio Espinosa Holguín
//November 17th, 2016
using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;
	//Variable that captures the number of rolls performed.
	public int rolls = 0;

	//JC - a bool to control when the die is rolled
	public bool readyToRoll = true;

	// Update is called once per frame
	void Update ()
	{
		//JC - we also need to only roll once the die comes to rest, so we will need another boolean to contro that

		if (readyToRoll) {
			//automation of 100 die rolls
			if (rolls < 100) {
				GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
				GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
				rolls++;
			}
			readyToRoll = false;
		}
	}
}
