using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider healthBar;




    public void SetHealth(float health)
    {

        healthBar.value = health;
    }

    public void SetMaxHealth(float max)
    {
        healthBar.maxValue = max;
        healthBar.value = max;
    }
}
