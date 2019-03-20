using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saverino : MonoBehaviour {

	public GameObject Save;
	public GameObject Load;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player")) 
		{
			Save.SetActive (true);
			Load.SetActive (true);		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player")) 
		{
			Save.SetActive (false);
			Load.SetActive (false);		}
	}
}
