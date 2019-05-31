using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaSalir : MonoBehaviour
{
    public bool abrirP;
    public KeyCode abrirKey;
    public GameObject texto;

    private void Update()
    {
        if(abrirP && Input.GetKeyDown(abrirKey))
        {
            texto.SetActive(false);
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        abrirP = true;
        texto.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        abrirP = false;
        texto.SetActive(false);
    }
}
