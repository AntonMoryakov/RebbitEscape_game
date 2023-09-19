using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Enemy enemyhealth;
    public Gradient gradient;
    public Image fill;
    public Vector3 offset;
    private void Start()
    {
        SetMaxHealth(enemyhealth.health);
    }

    private void Update()
    {
        SetHealth(enemyhealth.health);
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(100f);
    }
    public void SetHealth(float health)
    {
        slider.gameObject.SetActive(health < 100);
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
