using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCameraController : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    bool menu = false;

	void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void LateUpdate ()
    {
        CanControl();
	}

    public void LockCursorTP()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menu = false;
    }

    public void UnlockCursorTP()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        menu = true;
    }

    void CanControl()
    {
        if (menu) return;
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
