using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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

	public float resistencia = 0;
	public bool tired;
	public float targetTime = 1.0f; 
	public float resistenciaRegen = 1;
	public float resistenciaRegen2 = 1;
	public AudioClip caerseClip;
	AudioSource sonidito;
	public float resistenciaDec = 1;
	public int cansado;
	public float maxRes;
	public bool caerse;
	Animator anim;

    private void Awake()
    {
        walkSpeed = 6;
        runSpeed = 25;
        charController = GetComponent<CharacterController>();
		sonidito = GetComponent<AudioSource> ();
		tired = true;
		caerse = false;
		anim = GetComponent<Animator> ();
    }

    private void Update()
    {
        PlayerMovement();
        Agachar();
		Stamina ();
		Fall ();

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

	private void Fall()
	{
		targetTime -= Time.deltaTime;
		if (resistencia <= Random.Range(10,15) ) 
		{
			caerse = true;
		}
		if (caerse == true) 
		{
			Debug.Log ("se cayo");
			movementSpeed = 0;
			if (targetTime <= 0) 
			{
				targetTime = 4.0f;
				movementSpeed = Mathf.Lerp (movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
				caerse = false;
			}
		}

	}

	private void Stamina()
	{
		
		if (walkSpeed == 0) 
		{
			resistencia += Time.deltaTime / resistenciaRegen2;
		}
		if (resistencia >= maxRes) 
		{
			resistencia = maxRes;
		}

		if(resistencia <= cansado && !sonidito.isPlaying && tired == true)
		{
			AudioSource.PlayClipAtPoint(caerseClip, transform.position);
			Debug.Log ("audio");
			tired = false;

		}
		else
		{
			sonidito.Stop ();
		}

		if (resistencia >= cansado) 
		{
			tired = true;
		}

		if (resistencia <= 0) 
		{
			resistencia = 0;
		}
	}

    private void PlayerMovement()
    {
		targetTime -= Time.deltaTime;
        float horizInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);

        if ((vertInput != 0 || horizInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);


		SetMovementSpeed ();
		JumpInput ();
		
        
    }

    private void SetMovementSpeed()
    {
		
		if (Input.GetKey (runKey)) 
		{
			movementSpeed = Mathf.Lerp (movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
			resistencia-=Time.deltaTime / resistenciaDec;

		} 
		else
		{
			movementSpeed = Mathf.Lerp (movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
			resistencia+=Time.deltaTime / resistenciaRegen;
		}

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
