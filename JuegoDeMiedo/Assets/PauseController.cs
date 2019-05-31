using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    bool enMenu;

    public GameObject Canvas1;

    public GameObject MainCamera;
    public GameObject Cam_Celular;

    public TPCameraController pausarC;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!enMenu)
            {
                pausarC.UnlockCursorTP();

                //Canvas1.SetActive(false);

                MainCamera.SetActive(false);
                Cam_Celular.SetActive(true);

                Time.timeScale = 0;

                enMenu = true;
            } else
            {
                pausarC.LockCursorTP();

                //Canvas1.SetActive(false);

                MainCamera.SetActive(true);
                Cam_Celular.SetActive(false);

                Time.timeScale = 1;

                enMenu = false;
            }
            
        }
	}
}
