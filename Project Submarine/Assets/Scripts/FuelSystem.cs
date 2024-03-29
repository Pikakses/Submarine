using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    [HideInInspector] public static bool isMoving;
    [SerializeField] float baseInterval = 0.25f;
    [SerializeField] Text fuelMeter;
    float countDown;
    static float currentFuel = 100f;


    // Start is called before the first frame update
    void Start()
    {
        countDown = baseInterval;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFuel();
    }

    public static void AddFuel(float amount)
    {
        currentFuel += amount;
    }

    public static void ResetFuel()
    {
        currentFuel = 100f;
    }

    public static bool CheckIfHasFuel()
    {
        if(currentFuel <= 0) { return false; }
        else                 { return true; }
    }

    void ProcessFuel()
    {       
        if(!isMoving) { return; }
        if(currentFuel > 100f) { currentFuel = 100f; }
        if(currentFuel < 0)    { currentFuel = 0f; }
        if(countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            countDown = baseInterval;
            currentFuel -= 1f;
        }

        fuelMeter.text = "FUEL : " + currentFuel + '%'; 
    }

}
