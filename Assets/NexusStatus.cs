using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NexusStatus : NetworkBehaviour {

    [SerializeField] ToggleEvent onToggleEffect;

    public int maxHealth = 100;

    [SyncVar] private int currentHealth;

    private GameObject player;
    private NetworkIdentity m_identity;

	// Use this for initialization
	void Start () {
        m_identity = GetComponent<NetworkIdentity>();

        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            NexusDestroy();
        }
    }

    void NexusDestroy()
    {
        onToggleEffect.Invoke(true);
        GetComponentInChildren<MeshRenderer>().material.SetColor(0, Color.black);
    }

    public NetworkConnection GetOwner()
    {
        return m_identity.clientAuthorityOwner;
    }
}
