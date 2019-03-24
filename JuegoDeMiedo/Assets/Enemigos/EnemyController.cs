using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10.0f;
    public int patron;
    float algo;

    Transform target;
    NavMeshAgent agent;
    public Animator anim;

	void Start ()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
    }
	
	void Update ()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            anim.SetBool("camina", true);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                anim.SetBool("camina", false);
            }
            
        }
        else
        {
            anim.SetBool("camina", false);
        }
        /*else
        { ///Movimiento cuando no ataca
            if(patron == 1)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * .5f);
                transform.Rotate(0, Time.deltaTime * 10, 0);
            }
            if(patron == 2)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * .5f);
                transform.Rotate(0, 180, 0);
            }
        }*/
    }

    /*IEnumerator Example()
    {
        transform.Rotate(0, 180, 0);
        yield return new WaitForSeconds(5);
    }*/

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
