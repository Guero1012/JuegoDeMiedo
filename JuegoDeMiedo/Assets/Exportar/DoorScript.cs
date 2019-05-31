using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public int index = -1;
	public bool open = false;
	public float DoorOpenAngle = 90f;
	public float DoorCloseAngle = 0f;
	public float smooth = 2f;

	// Use this for initialization
	void Start () {
		
	}

	public void ChangeDoorState()
	{
		open = !open;
		GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (open) 
		{
			Quaternion targetRotation = Quaternion.Euler (0, DoorOpenAngle, 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, smooth * Time.deltaTime);
		} 
		else 
		{
			Quaternion targetRotation2 = Quaternion.Euler (0, DoorCloseAngle, 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation2, smooth * Time.deltaTime);
		}
	}
}
