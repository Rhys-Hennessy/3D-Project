﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    //public Rigidbody myRb;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public Animator anim;

    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

	// Use this for initialization
	void Start ()
    {
        //myRb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
	}

    // Update is called once per frame
    void Update()
    {
        //myRb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, myRb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        /*if (Input.GetButtonDown("Jump"))
        {
            myRb.velocity = new Vector3(myRb.velocity.x, jumpForce, myRb.velocity.z);
        }*/

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + transform.right * Input.GetAxis("Horizontal");
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore; 

        if (controller.isGrounded)
        {
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed) + (transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed);
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y*gravityScale*Time.deltaTime);
        controller.Move(moveDirection*Time.deltaTime);

        //move player in different direction based on camera look direction
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y,0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x + 0.001f, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}
