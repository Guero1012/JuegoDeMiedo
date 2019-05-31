using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    public GameObject PanelCelular;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            PanelCelular.SetActive(true);
            Time.timeScale = 0;
        }
	}
}
