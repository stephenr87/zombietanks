using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float thrustSpeed;
    public float maxRotationSpeed;
    private float rotationSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
        // Hvis vi bare flyver fremad
        if (Input.GetKey("w"))
        {
            //Sættes rotationsacceleration til 75 %
            rotationSpeed = maxRotationSpeed * 0.5f;
            Thrust();
        }

        if (Input.GetKey("s"))
        {
            rotationSpeed = maxRotationSpeed * 1.20f;
            Thrust(false);
        }


        //Hvis der drejes og vi flyver bagud, så roterer vi maksimalt
        if (Input.GetAxis("Horizontal") != 0)
        {
            Rotate();
            rotationSpeed = maxRotationSpeed;
        }
        else
            rotationSpeed = maxRotationSpeed;
        Rotate(false);
        {

        }
    }

    void Thrust(bool forward = true)
    {
        if (forward == true)
        {
            rb.AddRelativeForce(Vector3.right * thrustSpeed * 1000);
        }
        else
        {
            rb.AddRelativeForce(-(Vector3.right * thrustSpeed * 500));
        }
    }

    void Rotate(bool enabled = true)
    {
        if (enabled == true)
        {
            rb.AddRelativeTorque(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * 1000);
        }
    }

}
