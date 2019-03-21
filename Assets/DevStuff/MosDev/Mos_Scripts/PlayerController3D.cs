using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController3D : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    //[SerializeField] private RigidBody theRB;
    [SerializeField] private float jumpForce;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravityScale;
    [SerializeField] private Transform pivot;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private GameObject playerModel;

       private Vector3 moveDirection;
 // Start is called before the first frame update
    void Start()
    {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    //#TODO: Change this to a function and call from player
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
          
        }
        //theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed;

        /* if(Input.GetButtonDown("Jump"))
           {
                theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
           } */

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDirection.y;
      
        moveDirection = (transform.forward * Input.GetAxis ("Vertical") + (transform.right * Input.GetAxis("Horizontal")));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log(moveDirection);
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //Move the player in different directions based on camera look direction.
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
