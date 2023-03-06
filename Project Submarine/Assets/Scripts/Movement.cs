using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float rotationThrust = 30f;
    [SerializeField] float mainThrust = 750f;
    [SerializeField] float sideThrust = 350f;
    Rigidbody rb; 
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        ProcessSideThrust();
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
        if (Input.GetKey(KeyCode.Q))
        {
            ApllyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            ApllyRotation(-rotationThrust);
        }
    }

    void ProcessSideThrust()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.up * sideThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.down * sideThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        
    }

    void ApllyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing rotation so i can manually rotate 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing rotation so engine can rotate the object
    }
}
