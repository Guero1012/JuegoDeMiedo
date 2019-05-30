using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManagement : MonoBehaviour {

    public int vel;
    public int vel2;

    int cond;
    int cond2;

    float Ritmo = 0;
    float Ritmo2 = 0;

    public LineRenderer HealthBar;
    public LineRenderer FearBar;

    public bool useCurve = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CambioVida();
        CambioMiedo();

	}

    void CambioVida()
    {
        if (cond == 0)
        {
            Ritmo += Time.deltaTime * vel;

            if (Ritmo >= 0 && Ritmo <= 2)
            {
                HealthBar.SetPosition(2, new Vector3(-0.1f, 1.58f, -0.13f));
            }

            else if (Ritmo >= 2.1 && Ritmo <= 4)
            {
                HealthBar.SetPosition(3, new Vector3(0, 1.42f, -0.13f));
            }

            else if (Ritmo >= 4.1 && Ritmo <= 6)
            {
                HealthBar.SetPosition(6, new Vector3(0.3f, 1.65f, -0.13f));
            }

            else if (Ritmo >= 6.1 && Ritmo <= 8)
            {
                HealthBar.SetPosition(7, new Vector3(0.4f, 1.35f, -0.13f));
            }

            else if (Ritmo >= 10)
            {
                Ritmo = 0;
                cond = 1;
            }


        }

        else if (cond == 1)
        {
            Ritmo += Time.deltaTime * vel;

            if (Ritmo >= 0 && Ritmo <= 2)
            {
                HealthBar.SetPosition(2, new Vector3(-0.1f, 1.54f, -0.13f));
            }

            else if (Ritmo >= 2.1 && Ritmo <= 4)
            {
                HealthBar.SetPosition(3, new Vector3(0, 1.46f, -0.13f));
            }

            else if (Ritmo >= 4.1 && Ritmo <= 6)
            {
                HealthBar.SetPosition(6, new Vector3(0.3f, 1.58f, -0.13f));
            }

            else if (Ritmo >= 6.1 && Ritmo <= 8)
            {
                HealthBar.SetPosition(7, new Vector3(0.4f, 1.42f, -0.13f));
            }

            else if (Ritmo >= 10)
            {
                Ritmo = 0;
                cond = 0;
            }

        }
    }

    void CambioMiedo()
    {
        if (cond2 == 0)
        {
            Ritmo2 += Time.deltaTime * vel2;

            if (Ritmo2 >= 0 && Ritmo2 <= 2)
            {
                FearBar.SetPosition(2, new Vector3(-0.1f, 0.73f, -0.13f));
            }

            else if (Ritmo2 >= 2.1 && Ritmo2 <= 4)
            {
                FearBar.SetPosition(3, new Vector3(0, 0.57f, -0.13f));
            }

            else if (Ritmo2 >= 4.1 && Ritmo2 <= 6)
            {
                FearBar.SetPosition(6, new Vector3(0.3f, 0.8f, -0.13f));
            }

            else if (Ritmo2 >= 6.1 && Ritmo2 <= 8)
            {
                FearBar.SetPosition(7, new Vector3(0.4f, 0.5f, -0.13f));
            }

            else if (Ritmo2 >= 10)
            {
                Ritmo2 = 0;
                cond2 = 1;
            }


        }

        else if (cond2 == 1)
        {
            Ritmo2 += Time.deltaTime * vel2;

            if (Ritmo2 >= 0 && Ritmo2 <= 2)
            {
                FearBar.SetPosition(2, new Vector3(-0.1f, 0.69f, -0.13f));
            }

            else if (Ritmo2 >= 2.1 && Ritmo2 <= 4)
            {
                FearBar.SetPosition(3, new Vector3(0, 0.61f, -0.13f));
            }

            else if (Ritmo2 >= 4.1 && Ritmo2 <= 6)
            {
                FearBar.SetPosition(6, new Vector3(0.3f, 0.71f, -0.13f));
            }

            else if (Ritmo2 >= 6.1 && Ritmo2 <= 8)
            {
                FearBar.SetPosition(7, new Vector3(0.4f, 0.57f, -0.13f));
            }

            else if (Ritmo2 >= 10)
            {
                Ritmo2 = 0;
                cond2 = 0;
            }

        }
    }
}
