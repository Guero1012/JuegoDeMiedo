using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject[] botones;
    public GameObject[] imagenes;
    public GameObject[] titulos;
    public GameObject[] sliders;
    public GameObject[] dropDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        botones[0].SetActive(false);
        botones[1].SetActive(false);
        botones[2].SetActive(false);
        botones[3].SetActive(false);
        botones[4].SetActive(true);
        botones[5].SetActive(true);
        botones[6].SetActive(true);
        botones[7].SetActive(false);
    }

    public void Regresar()
    {
        botones[0].SetActive(true);
        botones[1].SetActive(true);
        botones[2].SetActive(true);
        botones[3].SetActive(true);
        botones[4].SetActive(false);
        botones[5].SetActive(false);
        botones[6].SetActive(false);

        titulos[0].SetActive(true);
        titulos[1].SetActive(false);
        titulos[2].SetActive(false);
    }

    public void Regresar2()
    {
        botones[0].SetActive(true);
        botones[1].SetActive(true);
        botones[2].SetActive(true);
        botones[3].SetActive(true);
        botones[4].SetActive(false);
        botones[5].SetActive(false);
        botones[6].SetActive(false);
        botones[7].SetActive(false);

        imagenes[0].SetActive(true);
        imagenes[1].SetActive(false);

        titulos[0].SetActive(true);
        titulos[1].SetActive(false);
        titulos[2].SetActive(false);
    }

    public void Regresar3()
    {
        botones[0].SetActive(true);
        botones[1].SetActive(true);
        botones[2].SetActive(true);
        botones[3].SetActive(true);
        botones[4].SetActive(false);
        botones[5].SetActive(false);
        botones[6].SetActive(false);
        botones[7].SetActive(false);
        botones[8].SetActive(false);

        imagenes[0].SetActive(true);
        imagenes[1].SetActive(false);

        titulos[0].SetActive(true);
        titulos[1].SetActive(false);
        titulos[2].SetActive(false);
        titulos[3].SetActive(false);
        titulos[4].SetActive(false);
        titulos[5].SetActive(false);
        titulos[6].SetActive(false);
        titulos[7].SetActive(false);
        titulos[8].SetActive(false);

        sliders[0].SetActive(false);
        sliders[1].SetActive(false);
        sliders[2].SetActive(false);

        dropDown[0].SetActive(false);
        dropDown[1].SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("PruebasFinal_Dentro");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        botones[0].SetActive(false);
        botones[1].SetActive(false);
        botones[2].SetActive(false);
        botones[3].SetActive(false);
        botones[4].SetActive(false);
        botones[5].SetActive(false);
        botones[6].SetActive(false);
        botones[7].SetActive(false);
        botones[8].SetActive(true);

        imagenes[0].SetActive(true);
        imagenes[1].SetActive(false);

        titulos[0].SetActive(false);
        titulos[1].SetActive(false);
        titulos[2].SetActive(true);
        titulos[3].SetActive(true);
        titulos[4].SetActive(true);
        titulos[5].SetActive(true);
        titulos[6].SetActive(true);
        titulos[7].SetActive(true);
        titulos[8].SetActive(true);

        sliders[0].SetActive(true);
        sliders[1].SetActive(true);
        sliders[2].SetActive(true);

        dropDown[0].SetActive(true);
        dropDown[1].SetActive(true);

    }

    public void Controls()
    {
        botones[0].SetActive(false);
        botones[1].SetActive(false);
        botones[2].SetActive(false);
        botones[3].SetActive(false);
        botones[4].SetActive(false);
        botones[5].SetActive(false);
        botones[6].SetActive(false);
        botones[7].SetActive(true);

        imagenes[0].SetActive(false);
        imagenes[1].SetActive(true);

        titulos[0].SetActive(false);
        titulos[1].SetActive(true);
        titulos[2].SetActive(false);
    }
}
