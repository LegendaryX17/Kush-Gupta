using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController cr;
    public float speed = 10f;
    float i = 0f;
    float r = 0.1f;
    public float jumpSpeed = 10f;
    public float gravity = 14f;
    public Vector3 verticalVelocity;
    public float stamina;
    public float staminaRecoverTime;
    float staminaSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (cr.isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f;
        }

        if (stamina < 100) 
        {
            staminaSpeed = 1f;
        }

        if (staminaRecoverTime <= 0)
        {
            stamina += staminaSpeed * 2;
            staminaRecoverTime = .1f;
        }

        if (Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = 12 * 2f;
            stamina -= 1;
        }

        else
        {
            staminaRecoverTime -= Time.deltaTime;
            speed = 12f;
        }

        if (stamina >= 100) {
            staminaSpeed = 0f;
            stamina = 100;
        }

        if (Input.GetButtonDown("Jump") && cr.isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(jumpSpeed * -2 * -gravity);
        }

        verticalVelocity.y += -gravity * Time.deltaTime;
        Vector3 move = transform.right * x + transform.forward * z;
        cr.Move(move * speed * Time.deltaTime);
        cr.Move(verticalVelocity * Time.deltaTime);
	}

}
