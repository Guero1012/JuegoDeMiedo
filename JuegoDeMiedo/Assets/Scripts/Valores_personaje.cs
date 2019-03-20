using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Valores_personaje : MonoBehaviour {

    public int vida;
    public float miedo;
    public float stamina;
    public bool armado;
    public bool patito;
    //public AudioClip s_pato;
    public AudioSource s_pato;


    
    

    public Transform camTransform;


    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.02f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;



    void Start () {
        //animacion del enemigo, cuando salga hace daño
        vida = 100;
        //raycast al enemigo para aumentar
        //cerca de enemigo aumentar
        //sin armas aumenta 
        //si llega a numero alto.- mover mira y reproduir sonido
        miedo = 0;
        //al correr 
        //casi acabandose sonido
        // si se acaba.- no podras correr
        stamina = 100;
        armado = false;


        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }

    }

    IEnumerator Todo()
    {

        yield return new WaitForSeconds(3);
    }
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(Todo());
        if (Input.GetKeyDown(KeyCode.O))
        {
            armado = !armado;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            patito = !patito;
            if (patito == true)
            {
                s_pato.Play(0);
            }
            else
            {
                s_pato.Stop();
            }
        }

        if (patito == true && miedo > 0)
        {
            miedo -= 1;
        }


        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
       
        //Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f);
        //Debug.DrawRay(transform.position, , Color.green);
        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        //Debug.DrawRay(transform.position, forward, Color.green);
        /*if (hit.transform.tag == "Enemy")
            {
            print("spooky");
                miedo += 1;
            }*/
        
            if(miedo >= 200)
        {
            miedo = 200;
        }

        if (miedo >= 100)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        }
        else
        {
            camTransform.localPosition = originalPos;
        }

        if(vida <= 0)
        {
            print("muerto");
            SceneManager.LoadScene("Dentro", LoadSceneMode.Single);
        }


    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            miedo += 1;
        }
    }
}
