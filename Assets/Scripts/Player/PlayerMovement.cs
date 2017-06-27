using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 6f;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;
    private int floorMask;
    private float camRayLength = 100f;


	void Awake ()
	{
	    floorMask = LayerMask.GetMask("Floor");

	    playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

	}
	
	
	void FixedUpdate ()
	{
	    float h = Input.GetAxisRaw("Horizontal");
	    float v = Input.GetAxisRaw("Vertical");

	    Move(h, v);
	    Turning();
        Animating(h, v);

	}
    
    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * Speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        // Returns true if it hits anything
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    // Ready for animations!
    void Animating(float h, float v)
    {
        bool running = h != 0f || v != 0f;
        anim.SetBool("Running", running);
    }

}
