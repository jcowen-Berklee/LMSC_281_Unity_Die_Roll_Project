//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	//Array setup as copied from the Midterm Concepts walkthrough.
	public int[] rollResults = new int[100];
	private int arrayPosition = 0;
	private int currentValue = 1;

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
