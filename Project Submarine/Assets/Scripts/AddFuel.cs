using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.parent.gameObject.name.Equals("Submarine"))
        {
            FuelSystem.AddFuel(20);
            Destroy(gameObject);
        }
    }

}


