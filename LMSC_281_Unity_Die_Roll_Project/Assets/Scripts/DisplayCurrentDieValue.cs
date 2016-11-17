//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	//Array setup as copied from the Midterm Concepts walkthrough.
	public int[] rollResults = new int[100];
	private int arrayPosition = 0;
	public int currentValue = 1;

	public LayerMask dieValueColliderLayer = -1;


	private bool rollComplete = false;

	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}

		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
		{
			rollComplete = true;
			Debug.Log("Die roll complete, die is at rest");
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;
		}
	}
	public void CaptureToArray () {
		if (arrayPosition < rollResults.Length) {
			//for some reason, even though the system displays the correct "currentvalue" to the GUI Label, it prints out only 0s to the Debug, and I have been
			//unable to locate the problem. This of course means that the rest of the project is faulty.
			rollResults [arrayPosition] = currentValue;
			Debug.Log ("The current array position is " + arrayPosition + " with a value of " + rollResults[arrayPosition]);
			arrayPosition++;
		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
