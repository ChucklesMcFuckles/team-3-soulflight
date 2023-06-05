using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerStatus : MonoBehaviour
    {
        public int healthLevel = 10;

        public int maxHealth;
        public int currentHealth;

        public HealthSystem healthbar;

        void start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthbar.setMaxHP(maxHealth);

        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

    }
}