using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPistola : MonoBehaviour {

    Rigidbody rb;
    float speed = 1.0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.velocity = transform.forward * speed;
        
    }

    void Update()
    {
        Destroy(gameObject, 3.0f);
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider _col)
    {
        Destroy(gameObject);
    }
}
