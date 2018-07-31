using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusStatus : MonoBehaviour {

    public int maxHealth = 100;

    private int currentHealth;
    private GameObject player;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        SetPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetPlayer()
    {

    }
}
