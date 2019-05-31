using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoPistola : MonoBehaviour
{
    public Transform prefapProjectil;
    public Transform instancia;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Instantiate(prefapProjectil, instancia.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x+Random.Range(-5.0f,5.0f), transform.eulerAngles.y + Random.Range(-5.0f, 5.0f), transform.eulerAngles.z)));
    }
}