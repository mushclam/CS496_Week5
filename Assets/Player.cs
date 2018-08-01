﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class ToggleEvent : UnityEvent<bool> { }

public class Player : NetworkBehaviour {

    [SerializeField] ToggleEvent onToggleShared;
    [SerializeField] ToggleEvent onToggleLocal;
    [SerializeField] ToggleEvent onToggleRemote;

    [SerializeField] GameObject nexus;
    private GameObject[] startPositions;
    private GameObject[] nexusPositions;
    
    GameObject mainCamera;
    Camera playerCamera;

    private void Start()
    {
        mainCamera = Camera.main.gameObject;
        playerCamera = GetComponentInChildren<Camera>();

        EnablePlayer();
    }

    public override void OnStartLocalPlayer()
    {
        CmdSpawnNexus();
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Summoner.instance.SummonUnit(connectionToClient, hit.point, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameObject[] test = GameObject.FindGameObjectsWithTag("Unit");
                foreach (GameObject unit in test)
                {
                    unit.GetComponent<UnitHealth>().TakeDamage(100);
                }
            }
        }
    }

    void EnablePlayer()
    {
        if (isLocalPlayer)
        {
            mainCamera.SetActive(false);
        }

        onToggleShared.Invoke(true);

        if (isLocalPlayer)
        {
            onToggleLocal.Invoke(true);
        }
        else
        {
            onToggleRemote.Invoke(true);
        }
    }

    [Command]
    void CmdSpawnNexus()
    {
        Vector3 nexusPosition;

        startPositions = GameObject.FindGameObjectsWithTag("StartPosition");
        if (transform.position.Equals(startPositions[0].transform.position))
        {
            nexusPosition = startPositions[0].transform.GetChild(0).position;
        }
        else
        {
            nexusPosition = startPositions[1].transform.GetChild(0).position;
        }

        GameObject playerNexus = Instantiate(
            nexus,
            nexusPosition,
            Quaternion.identity);

        NetworkServer.SpawnWithClientAuthority(playerNexus, connectionToClient);
    }
}
