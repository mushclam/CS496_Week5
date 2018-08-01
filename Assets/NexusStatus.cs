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

    public GameObject DestroySound;

	// Use this for initialization
	void Start () {
        m_identity = GetComponent<NetworkIdentity>();

        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [Command]
    public void CmdTakeDamage (int damage)
    {
        currentHealth -= damage;
        Debug.Log("Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            RpcNexusDestroy();
        }
    }

    [ClientRpc]
    void RpcNexusDestroy()
    {
        onToggleEffect.Invoke(true);
        Instantiate(DestroySound);
        GetComponentInChildren<MeshRenderer>().material.SetColor(0, Color.black);
    }

    public NetworkConnection GetOwner()
    {
        return m_identity.clientAuthorityOwner;
    }
}
