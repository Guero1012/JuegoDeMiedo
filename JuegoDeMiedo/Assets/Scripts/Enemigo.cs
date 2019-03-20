using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    public bool vista;
    public Valores_personaje personaje;

    IEnumerator Ataque()
    {
        Renderer rend = GetComponent<Renderer>();

        yield return new WaitForSeconds(2);

        

        yield return new WaitForSeconds(1);
        

    }

	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        Renderer rend = GetComponent<Renderer>();
        if (vista == true)
        {
            personaje.vida -= 1;
            rend.material.SetColor("_Color", Color.red);
            StartCoroutine(Ataque());
        }
        else
        {
            rend.material.SetColor("_Color", Color.blue);
        }

        
	}
    private void OnTriggerEnter(Collider other)
    {
        
        vista = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        vista = false;
    }
}
