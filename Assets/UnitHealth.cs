using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour {

    public int maxHealth = 100;

    private int currentHealth;

	void Start () {
        currentHealth = maxHealth;
	}
	
	void Update () {
		
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {

    }
}
