using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
	}

	public void Load()
	{
		SaveGame.Load ();
		transform.position = SaveGame.Instance.PlayerPosition;
	}

	public void Save()
	{
		SaveGame.Instance.PlayerPosition = transform.position;
		SaveGame.Save (); 
	}
		
}
