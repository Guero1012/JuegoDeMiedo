using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public string horizontalInputName;
    public string verticalInputName;

    public float walkSpeed, runSpeed;
    public float runBuildUpSpeed;
    public KeyCode runKey;

    public float slopeForce;
    public float slopeForceRayLenght;

    public AnimationCurve jumpFallOff;
    public float jumpMultiplier;
    public KeyCode jumpKey;

    private CharacterController charController;
    private float movementSpeed;
    private bool isJumping;

    public KeyCode agacharKey;
    /*public bool yaAgachado;
    public bool mantener;*/

    private void Awake()
    {
        walkSpeed = 6;
        runSpeed = 25;
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
        Agachar();
    }

    private void Agachar()
    {
        if (Input.GetKey(agacharKey))
        {
            walkSpeed = 2;
            runSpeed = 15;
        }
        else if (Input.GetKeyUp(agacharKey))
        {
            walkSpeed = 6;
            runSpeed = 25;
        }

        /*if (!mantener)
        {
            if (Input.GetKey(agacharKey))
            {
                walkSpeed = 2;
                runSpeed = 15;
            }
            else if (Input.GetKeyUp(agacharKey))
            {
                walkSpeed = 6;
                runSpeed = 25;
            }
        }
        else
        {
            if(Input.GetKeyDown(agacharKey))
            {
                if(!yaAgachado)
                {
                    walkSpeed = 2;
                    runSpeed = 15;
                    yaAgachado = true;
                }
                else
                {
                    walkSpeed = 6;
                    runSpeed = 25;
                    yaAgachado = false;
                }
            }
        }*/
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);

        if ((vertInput != 0 || horizInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);

        SetMovementSpeed();
        JumpInput();
    }

    private void SetMovementSpeed()
    {
        if (Input.GetKey(runKey))
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
        else
            movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
    }

    private bool OnSlope()
    {
        if (isJumping)
            return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLenght))
            if (hit.normal != Vector3.up)
                return true;
        return false;
    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

}
