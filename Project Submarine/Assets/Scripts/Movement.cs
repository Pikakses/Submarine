using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float rotationThrust = 30f;
    [SerializeField] float mainThrust = 750f;
    [SerializeField] float sideThrust = 350f;
    [SerializeField] AudioClip rotorSFX;
    [SerializeField] ParticleSystem rotorParticles;
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
        ProcessSideThrust();
    }
    

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(Vector3.right * mainThrust * Time.deltaTime);
        }

    }


    void ProcessSideThrust()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            StartSideThrust(sideThrust);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            StartSideThrust(-sideThrust);
        }
        else
        {
            StopSideThrust();
        }

    }

    void StopSideThrust()
    {
        audioSource.Stop();
        rotorParticles.Stop();
    }

    void StartSideThrust(float sideThrust)
    {
        rb.AddRelativeForce(Vector3.up * sideThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rotorSFX);
        }
        if (!rotorParticles.isPlaying)
        {
            rotorParticles.Play();
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

    void ApllyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing rotation so i can manually rotate 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing rotation so engine can rotate the object
    }
}
