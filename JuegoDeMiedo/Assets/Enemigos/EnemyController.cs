using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10.0f;
    public Transform[] points; //Puntos para Nav
    private int destPoint = 0;
    public Transform directDest; //Destino unico para random Nav
    public int enemNav = 0; //Tipo de Navegación
    float timer;

    //bool enterado;
    public int vida;
    public float enemyDistanceRun = 20.0f;

    Transform target;
    NavMeshAgent agent;
    public Animator anim;

	void Start ()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
    }
	
	void Update ()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        anim.SetBool("camina", true);

        if (distance <= lookRadius)
        {
            if (vida > 40)
            {
                agent.SetDestination(target.position);
            }
            else
            {
                Vector3 dirToPlayer = transform.position - target.transform.position;
                Vector3 newPos = transform.position + dirToPlayer;
                agent.SetDestination(newPos);
            }
            
            /*if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                anim.SetBool("camina", false);
            }*/
        }
        else 
        {
            if (enemNav == 1)
            {
                agent.destination = directDest.position;

                timer += Time.deltaTime;
                if (timer >= 4.0f)
                {
                    WaitAndPrint();
                    timer = 0;
                }
            }
            else if (enemNav == 2)
            {
                agent.destination = points[destPoint].position;

                if (!agent.pathPending)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            GotoNextPoint();
                        }
                    }
                }
            }
            //anim.SetBool("camina", false);
        }
    }

    void WaitAndPrint()
    {
        int randNav = Random.Range(0, 4);
        switch (randNav)
        {
            case 0:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
                break;
            case 1:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 90, transform.rotation.z);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
                break;
        }
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        destPoint = (destPoint + 1) % points.Length;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
