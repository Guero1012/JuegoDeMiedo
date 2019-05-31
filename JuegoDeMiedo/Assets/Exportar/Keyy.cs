using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyy : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        print("Hola");
    }
}
