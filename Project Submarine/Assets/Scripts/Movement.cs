using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float roatationThrust = 100f;
    [SerializeField] float mainThrust = 1000f;
    Rigidbody rb; 



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.right * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApllyRotation(roatationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApllyRotation(-roatationThrust);
        }
    }

    void ApllyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing rotation so i can manually rotate 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing rotation so engine can rotate the object
    }
}
