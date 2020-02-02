using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float thereshold = 0.0001f;
    public float quacks = 0.5f;
    public float deployTime = 0.0f;

    public Animator Animar;
    public GameObject path;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 thrshy = Vector3.zero;
    private Vector3 playerPos = Vector3.zero;
    private Vector3 transf2Vec3 = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Animar = gameObject.GetComponentInParent<Animator>();
        //characterPosition = GetComponent<Trasform>();
        deployTime = 0.0f;
    }

    void Update()
    {
    deployTime += Time.deltaTime;
    thrshy = new Vector3(1.0f,1.0f,1.0f);
 
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            
            playerPos = transform.localPosition;

            if( moveDirection.magnitude > thereshold )
                {
                //if (deployTime > quacks)
                //    {
                        Instantiate(path, playerPos + thrshy , Quaternion.identity);
                //        deployTime = 0.0f;
                //    }
                //Animar.SetBool("IsWalking", true);
                }//else Animar.SetBool("IsWalking", false);

            /*
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            */

            //if (Input.GetButton("Jump"))
            //{
            //    Animar.SetBool("IsPunching", true);
            //}else Animar.SetBool("IsPunching", false);
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Mover charactercontroller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}