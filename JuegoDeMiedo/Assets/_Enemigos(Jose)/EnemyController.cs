using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10.0f; //Radio para buscar al jugador

    public int tipoNavegacion = 0; //Tipo de patrullaje
    public Transform[] puntos; //Puntos para patrullaje
    private int destinoActual = 0; //A cual punto va
    public Transform directDest; //Destino unico para patrullaje aletoria

    public GameObject ataqueCol;

    float temporizador;
    float t_ataque;

    public bool jefe;
    bool atacando;
    int vidaEnemigo;

    Transform objetivo;
    NavMeshAgent zombi;
    public Animator anim;

    void Awake()
    {
        if (jefe)
            vidaEnemigo = 300;
        else
            vidaEnemigo = 100;
    }

    void Start ()
    {
        objetivo = PlayerManager.instance.player.transform;
        zombi = GetComponent<NavMeshAgent>();

        Debug.Log("Presiona '1' para matar al enemigo");
        Debug.Log("Presiona '2' para matar al jefe");
    }
	
	void Update ()
    {
        float distancia = Vector3.Distance(objetivo.position, transform.position);
        anim.SetBool("camina", true);

        if (distancia <= lookRadius) //Encontró al jugador y lo que persigue
        {
            zombi.SetDestination(objetivo.position);

            if (distancia <= zombi.stoppingDistance + 0.25f && !atacando && vidaEnemigo <= 0) //Llegó con el jugador y lo ataca
            {
                if(!jefe)
                    StartCoroutine(AtacarJugador());
                else
                    StartCoroutine(AtacarJugadorB());

                atacando = true;
                MirarObjetivo();
            }
            else
                anim.SetBool("ataca", false);
        }
        else //Patrullaje
        {
            if (tipoNavegacion == 1)
            {
                zombi.destination = directDest.position;

                temporizador += Time.deltaTime;
                if (temporizador >= 4.0f)
                {
                    CambioDireccion();
                    temporizador = 0;
                }
            }
            else if (tipoNavegacion == 2)
            {
                zombi.destination = puntos[destinoActual].position;

                if (!zombi.pathPending)
                {
                    if (zombi.remainingDistance <= zombi.stoppingDistance)
                    {
                        if (!zombi.hasPath || zombi.velocity.sqrMagnitude == 0f)
                            SiguientePunto();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !jefe)
            RecibirDanio(vidaEnemigo);

        /*if(Input.GetKeyDown(KeyCode.Alpha3) && jefe)
            RecibirDanio(vidaEnemigo);*/
    }

    void CambioDireccion()
    {
        int randNav = Random.Range(0, 4);
        switch (randNav)
        {
            case 0: transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
                break;
            case 1: transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 90, transform.rotation.z);
                break;
            case 2: transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                break;
            case 3: transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
                break;
        }
    }

    void SiguientePunto()
    {
        if (puntos.Length == 0)
            return;
        destinoActual = (destinoActual + 1) % puntos.Length;
    }

    void MirarObjetivo()
    {
        Vector3 direction = (objetivo.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator AtacarJugador() //Función para que el jugador ataque
    {
        t_ataque += Time.deltaTime;
        zombi.speed = 0;
        anim.SetBool("ataca", true);
        yield return new WaitForSeconds(1.0f);
        ataqueCol.SetActive(true);
        yield return new WaitForSeconds(1.6f);
        ataqueCol.SetActive(false);
        zombi.speed = 2;
        t_ataque = 0;
        atacando = false;
    }

    IEnumerator AtacarJugadorB() //Función para que el jefe ataque
    {
        t_ataque += Time.deltaTime;
        zombi.speed = 0;
        anim.SetBool("ataca", true);
        yield return new WaitForSeconds(1.5f);
        ataqueCol.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        ataqueCol.SetActive(false);
        yield return new WaitForSeconds(2.6f);
        zombi.speed = 2;
        t_ataque = 0;
        atacando = false;
    }

    void RecibirDanio(int cantidad_d) //Funcíon para que el enemigo reciba una canditdad de daño asignada. 
    {
        vidaEnemigo -= cantidad_d;
        if(vidaEnemigo <= 0)
        {
            zombi.speed = 0;
            anim.SetBool("muerto", true);
            if (jefe)
                StartCoroutine(Revivivendo());
        }
    }

    IEnumerator Revivivendo() //El jefe después de de un tiempo resusitará
    {
        yield return new WaitForSeconds(5.0f);
        anim.SetBool("muerto", false);
        yield return new WaitForSeconds(3.1f);
        zombi.speed = 2;
        //anim.SetBool("muerto", false);
        vidaEnemigo = 300;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void OnTriggerEnter(Collider _col)
    {
        if(_col.tag == "Cuchillo")
        {
            vidaEnemigo -= 10;
        }
        if (_col.tag == "Macana")
        {
            vidaEnemigo -= 12;
        }
        if (_col.tag == "Hacha")
        {
            vidaEnemigo -= 20;
        }
        if (_col.tag == "BalaPistola")
        {
            vidaEnemigo -= 15;
        }
        if (_col.tag == "BalaEscopeta")
        {
            vidaEnemigo -= 25;
        }
    }
}
