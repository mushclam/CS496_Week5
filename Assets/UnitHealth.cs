using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UnitHealth : NetworkBehaviour {

    public int maxHealth = 100;
    [SyncVar] private int currentHealth;

	void Start () {
        currentHealth = maxHealth;
	}
	
	void Update () {
		
	}

    [Command]
    public void CmdTakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.GetComponent<MonsterController>().RpcDie();
        }
    }
}
