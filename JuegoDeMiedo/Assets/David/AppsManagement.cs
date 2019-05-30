using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppsManagement : MonoBehaviour {

    public GameObject Linterna;

    public GameObject PanelLinterna;
    public Button LintOn;
    public Sprite[] LintSprites;

    public GameObject PanelVida;
    public GameObject PanelAjustes;

    AudioSource myAudio;
    public AudioClip click;

	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void AppLinterna()
    {
        myAudio.PlayOneShot(click);
        PanelLinterna.SetActive(true);
    }

    public void AppVida()
    {
        myAudio.PlayOneShot(click);
        PanelVida.SetActive(true);
    }

    public void AppAjustes()
    {
        myAudio.PlayOneShot(click);
        PanelAjustes.SetActive(true);
    }

    public void GenericApp()
    {
        myAudio.PlayOneShot(click);
    }

    public void BotonLinterna()
    {
        myAudio.PlayOneShot(click);

        if (Linterna.activeSelf)
        {
            LintOn.image.sprite = LintSprites[0];
            Linterna.SetActive(false);
        } else
        {
            LintOn.image.sprite = LintSprites[1];
            Linterna.SetActive(true);
        }
    }

    public void CloseApp()
    {
        myAudio.PlayOneShot(click);

        if (PanelLinterna.activeSelf)
        {
            PanelLinterna.SetActive(false);
            LintOn.image.sprite = LintSprites[0];

        }

        if (PanelVida.activeSelf)
        {
            PanelVida.SetActive(false);
        }

        if (PanelAjustes.activeSelf)
        {
            PanelAjustes.SetActive(false);
        }
    }

    public void MainMenu()
    {
        myAudio.PlayOneShot(click);
        //LoadScene
    }

    public void ExitGame()
    {
        myAudio.PlayOneShot(click);
        Application.Quit();
    }
}
