using System.Collections;
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

    GameObject mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.gameObject;

        EnablePlayer();
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
}
