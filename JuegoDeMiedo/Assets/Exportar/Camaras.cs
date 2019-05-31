using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaras : MonoBehaviour {
	[SerializeField]
	Camera FirstPCamera;
	[SerializeField]
	Camera SecondCamera;
	[SerializeField]
	Camera ThirdCamera;
    [SerializeField]
    Camera ForCamera;
    [SerializeField]
    Camera FivCamera;
    [SerializeField]
    Camera SixCamera;
    [SerializeField]
    Camera SevenCamera;
    [SerializeField]
    Camera EiCamera;
    [SerializeField]
    Camera NainCamera;
    [SerializeField]
    Camera TenCamera;
    [SerializeField]
    Camera ElevenCamera;
    [SerializeField]
    Camera TwelveCamera;

    private bool switchCam = false;
    public float con = 0;
	private bool CharchCam = true;
	public GameObject guiObject;
    public GameObject Flashlight;
    //public flashlight Script;
	// Use this for initialization
	void Start () 
	{
		FirstPCamera.GetComponent<Camera> ().enabled = true;
		SecondCamera.GetComponent<Camera> ().enabled = false;
		ThirdCamera.GetComponent<Camera> ().enabled = false;
        ForCamera.GetComponent<Camera>().enabled = false;
        FivCamera.GetComponent<Camera>().enabled = false;
        SixCamera.GetComponent<Camera>().enabled = false;
        SevenCamera.GetComponent<Camera>().enabled = false;
        EiCamera.GetComponent<Camera>().enabled = false;
        NainCamera.GetComponent<Camera>().enabled = false;
        TenCamera.GetComponent<Camera>().enabled = false;
        ElevenCamera.GetComponent<Camera>().enabled = false;
        TwelveCamera.GetComponent<Camera>().enabled = false;

        guiObject.SetActive (false);
	}
		
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			guiObject.SetActive (true);
			if (Input.GetKeyDown ("t")) 
			{
				switchCam = true;
				CharchCam = false;
                //Flashlight.SetActive(false);

                con += 0.5f;
                
                if(con==12)
                {
                    con = 0;
                }
			}
			if (Input.GetKeyDown ("r")) 
			{
				switchCam = false;
				CharchCam = true;
                //Flashlight.SetActive(true);
            }
			
			if(CharchCam == true)
			{
				FirstPCamera.GetComponent<Camera> ().enabled = true;
				SecondCamera.GetComponent<Camera> ().enabled = false;
				ThirdCamera.GetComponent<Camera> ().enabled = false;
                ForCamera.GetComponent<Camera>().enabled = false;
                FivCamera.GetComponent<Camera>().enabled = false;
                SixCamera.GetComponent<Camera>().enabled = false;
                SevenCamera.GetComponent<Camera>().enabled = false;
                EiCamera.GetComponent<Camera>().enabled = false;
                NainCamera.GetComponent<Camera>().enabled = false;
                TenCamera.GetComponent<Camera>().enabled = false;
                ElevenCamera.GetComponent<Camera>().enabled = false;
                TwelveCamera.GetComponent<Camera>().enabled = false;
            }
			else //Otra camara debe estar activa
			{
				if(switchCam == true)
				{
                    if (con == 0)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = true;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }


                    if (con == 1)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = true;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }

                    if (con == 2)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = true;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }

                    if (con == 3)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = true;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }

                    if (con == 4)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = true;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }

                    if (con == 5)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = true;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }

                    if (con == 6)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = true;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }

                    if (con == 7)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = true;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }

                    if (con == 8)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = true;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }

                    if (con == 9)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = true;
                        TwelveCamera.GetComponent<Camera>().enabled = false;
                    }

                    if (con == 10)
                    {
                        FirstPCamera.GetComponent<Camera>().enabled = false;
                        SecondCamera.GetComponent<Camera>().enabled = false;
                        ThirdCamera.GetComponent<Camera>().enabled = false;
                        ForCamera.GetComponent<Camera>().enabled = false;
                        FivCamera.GetComponent<Camera>().enabled = false;
                        SixCamera.GetComponent<Camera>().enabled = false;
                        SevenCamera.GetComponent<Camera>().enabled = false;
                        EiCamera.GetComponent<Camera>().enabled = false;
                        NainCamera.GetComponent<Camera>().enabled = false;
                        TenCamera.GetComponent<Camera>().enabled = false;
                        ElevenCamera.GetComponent<Camera>().enabled = false;
                        TwelveCamera.GetComponent<Camera>().enabled = true;
                        
                    }

                   
                }
			}
			
			
			
			
		

		}
	}
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerExit()
	{
		guiObject.SetActive (false);
	}
}
