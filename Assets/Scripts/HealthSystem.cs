using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Slider slider;

    private void start()
    {
        slider = GetComponent<Slider>();
    }

    public void setMaxHP(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void setCurrentHP(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
