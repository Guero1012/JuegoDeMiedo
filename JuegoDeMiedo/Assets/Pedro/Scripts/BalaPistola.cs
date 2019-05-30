using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPistola : MonoBehaviour {

    Rigidbody rb;
    float speed = 20.0f;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        Destroy(gameObject, 3.0f);
    }

    void OnTriggerEnter(Collider _col)
    {
        Destroy(gameObject);
    }
}
