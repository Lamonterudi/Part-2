using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Slider slider;
    public float health;
    public float maxHealth = 5;
    // Start is called before the first frame update
    public void Start()
    {
    //health = PlayerPrefs.GetFloat("health");
    }
    public void TakeDamage(float damage)
    {
        slider.value -= damage;
      //  PlayerPrefs.SetFloat("health", health);
    }
 

    public void ProperHealth(float health)
    {

        slider.value = health;
    }
}
