using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public string mouseXInputName, mouseYInputName;
    public float mouseSensivity;
    public Transform playerBody;

    public KeyCode agacharKey;

    private float xAxisClamp;

    public bool agachado;
    //private PlayerMove agachando;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
        //agachando = GetComponent<PlayerMove>();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

	void Update ()
    {
        CameraRotation();
        Agachando();

        if(agachado == false && transform.localPosition.y < 1)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10);
        }
    }

    private void Agachando()
    {
        if(Input.GetKey(agacharKey))
        {
            //transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
            if(transform.localPosition.y > 0)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 10);
            }
            agachado = true;
        }   
        else if (Input.GetKeyUp(agacharKey))
        {
            //transform.localPosition = new Vector3(transform.localPosition.x, 1, transform.localPosition.z)
            agachado = false;
        }

        /*if (!agachando.mantener)
        {
            if (Input.GetKey(agacharKey))
                transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
            else if (Input.GetKeyUp(agacharKey))
                transform.localPosition = new Vector3(transform.localPosition.x, 1, transform.localPosition.z);
        }
        else
        {
            if (Input.GetKeyDown(agacharKey))
            {
                if (Input.GetKey(agacharKey))
                {
                    if(!agachando.yaAgachado)
                    {
                        transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
                    }
                    else
                    {
                        transform.localPosition = new Vector3(transform.localPosition.x, 1, transform.localPosition.z);
                    }
                }
            }
        }*/
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXaxisrotationToValue(270.0f);
        }
        else if(xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXaxisrotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXaxisrotationToValue(float value)
    {
        Vector2 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
