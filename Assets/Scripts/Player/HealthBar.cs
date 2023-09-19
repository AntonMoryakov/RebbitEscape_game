using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerInteraction playerHealth;
    //public Gradient gradient;
    public Image fill;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        SetMaxHealth(playerHealth.health);
    }

    private void Update()
    {
        SetHealth(playerHealth.health);
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        //fill.color = gradient.Evaluate(health);
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    
}
