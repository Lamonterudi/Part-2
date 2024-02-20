using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthB : MonoBehaviour
{

    public Slider slider;
    public float health;
    public void Update()
    {
       
            }
    // Start is called before the first frame update
    public void Start()
    {
        health = PlayerPrefs.GetFloat("difficultySetting");
    }
    public void playerDamage(float damage)
    {
        slider.value -= damage;
    }


    public void playerHealth(float health)
    {

        slider.value = health;
    }
}
