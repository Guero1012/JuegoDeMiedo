using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animation>().Play("Ataque2");
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            GetComponent<Animation>().Play("Ataque1");
        }
    }
}
