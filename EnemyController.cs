using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float gravity = 9.6f; 
    private Vector3 verticalVelocity;
    public CharacterController cr;
    public float enemyJump = 4f;
    public Transform player;
    public float enemySpeed = 7f;
    Vector3 velocityHorizontal = new Vector3(0f,0f,0f);
    public float range = 50f;
    bool inRange = false;
    Vector3 move;
    public float rotateTime = 8f;
    public Material mr;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (player.position.x < transform.position.x - range || player.position.x > transform.position.x + range || player.position.z < transform.position.z - range || player.position.z > transform.position.z + range)
        {
            inRange = false;
            Wandering();
        }
        else 
        {
            inRange = true;
        }

        if (cr.isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f;
        }

        if (player.position.x - 1 < transform.position.x && inRange == true) 
        {
            velocityHorizontal.x = -enemySpeed;
        }
        else if (player.position.x + 1 > transform.position.x && inRange == true)
        {
            velocityHorizontal.x = enemySpeed;
        }
        else 
        {
            velocityHorizontal.x = 0;
        }
        if (player.position.z < transform.position.z && inRange == true)
        {
            velocityHorizontal.z = -enemySpeed;
        }
        else if (player.position.z > transform.position.z && inRange == true)
        {
            velocityHorizontal.z = enemySpeed;
        }
        else 
        {
            Wandering();
        }
        move = new Vector3(velocityHorizontal.x, 0, velocityHorizontal.z);
        verticalVelocity.y += -gravity * Time.deltaTime;
        cr.Move(verticalVelocity * Time.deltaTime);
        cr.Move(move * Time.deltaTime);
	}
    void Wandering() 
    {
        float wanderingSpeed = 7f;
        rotateTime -= Time.deltaTime;
        float rotateAngle;
        rotateAngle = Random.Range(-90, 90);
        move = transform.right * wanderingSpeed * -0.7f;
        if (rotateTime <= 0) 
        {
            transform.Rotate(0,rotateAngle,0);
            rotateTime = 5f;
        }
        cr.Move(move * Time.deltaTime);
    }
}
