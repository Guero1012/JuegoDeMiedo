using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour {

    public Light Sun;
    public float sunInit_Intensity;

    public Slider Daytime_Slider;

    public Image SliderHandle;
    public Sprite SunImage;
    public Sprite NightImage;

    public float secondsInDay = 120f;
    public float minutesInDay = 60f;
    public float timeVel;


    [Range(0, 1)]
    public float currentTime;


    void Start () {
        sunInit_Intensity = Sun.intensity;
	}
	
	void Update () {
        LightUpdate();

        currentTime += (Time.deltaTime / secondsInDay) * timeVel;

        if (currentTime >= 1)
        {
            currentTime = 0;
        }

        if(currentTime >= 0.25f && currentTime <= 0.75f)
        {
            Debug.Log("Día");
            SliderHandle.sprite = SunImage;
            
        }
        else
        {
            Debug.Log("Noche");
            SliderHandle.sprite = NightImage;
        }
	}

    void LightUpdate()
    {
        Sun.transform.localRotation = Quaternion.Euler((currentTime * 360f) - 90, 170, 0);

        float newIntensity = 1;

         if (currentTime <= 0.25f)
        {
            newIntensity = 0;
            newIntensity = Mathf.Clamp01((currentTime - 0.25f) * (1 / 0.02f));

        }
        else if (currentTime >= 0.73f)
        {
            newIntensity = 0;
            newIntensity = Mathf.Clamp01(1 - ((currentTime - 0.75f) * (1 / 0.02f)));
        }

        Sun.intensity = sunInit_Intensity * newIntensity;

        Daytime_UI(currentTime);
        
    }

    void Daytime_UI(float _time)
    {
        Daytime_Slider.value = _time;
    }
}
