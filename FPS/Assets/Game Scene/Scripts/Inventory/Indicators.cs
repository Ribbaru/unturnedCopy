using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicators : MonoBehaviour
{
    public CharacterMovement characterMovement;
    
    public Image healthBar, foodBar, waterBar, airBar;
    public float healthAmount = 100;
    public float uiHealthAmount = 100;
    public float foodAmount = 100;
    public float uiFoodAmount = 100;
    public float waterAmount = 100;
    public float uiWaterAmount = 100;
    public float airAmount = 100;

    public float secondsToEmptyFood = 60f;
    public float secondsToEmptyWater = 30f;
    public float secondsToEmptyHealth = 60f;
    public float secondsToEmptyAir = 10f;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = healthAmount / 100;
        foodBar.fillAmount = foodAmount / 100;
        waterBar.fillAmount = waterAmount / 100;
        airBar.fillAmount = airAmount / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (foodAmount > 0)
        {
            foodAmount -= 100 / secondsToEmptyFood * Time.deltaTime;
            uiFoodAmount = Mathf.Lerp(uiFoodAmount, foodAmount, Time.deltaTime * 6f);
            foodBar.fillAmount = uiFoodAmount / 100;

        }
        if (waterAmount > 0)
        {
            waterAmount -= 100 / secondsToEmptyWater * Time.deltaTime;
            uiWaterAmount = Mathf.Lerp(uiWaterAmount, waterAmount, Time.deltaTime * 6f);
            waterBar.fillAmount = uiWaterAmount / 100;
        }
        if(airAmount > 0 && characterMovement.inLayer3)
        {
            airAmount -= 100 / secondsToEmptyAir * Time.deltaTime;
            airBar.fillAmount = airAmount / 100;
        }
        if(airAmount<=100 &&characterMovement.inLayer3 == false)
        {
            airAmount += 100 / secondsToEmptyAir * Time.deltaTime;
            airBar.fillAmount = airAmount / 100;
        }

        if (foodAmount <= 0)
        {
            healthAmount -= 100 / secondsToEmptyHealth * Time.deltaTime;
        }
        if (waterAmount <= 0)
        {
            healthAmount -= 100 / secondsToEmptyHealth * Time.deltaTime;
        }
        if (airAmount <= 0)
        {
            healthAmount -= 100 / secondsToEmptyHealth * Time.deltaTime;
        }

        healthBar.fillAmount = uiHealthAmount / 100;
        uiHealthAmount = Mathf.Lerp(uiHealthAmount, healthAmount, Time.deltaTime * 6f);


    }
    public void ChangeFoodAmount(float changeValue)
    {
        foodAmount += changeValue;
    }
    public void ChangeWaterAmount(float changeValue)
    {
        waterAmount+= changeValue;
    }
    public void ChangeHealthAmount(float changeValue)
    {
        healthAmount += changeValue;
    }
}