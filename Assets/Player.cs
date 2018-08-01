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
    
    GameObject mainCamera;
    Camera playerCamera;

    private NetworkConnection m_Identity;
    private UnitManager unitManager;
    private cardManager m_cardManager;
    private Summoner summoner;

    private void Start()
    {
        //mainCamera = Camera.main.gameObject;
        playerCamera = GetComponentInChildren<Camera>();
        
        if (isLocalPlayer)
        {
            EnablePlayer();
        }
    }

    public override void OnStartLocalPlayer()
    {
        CmdSpawnNexus();
        summoner = GetComponentInChildren<Summoner>();
        unitManager = GetComponent<UnitManager>();
        m_cardManager = GetComponent<cardManager>();
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log(connectionToServer);
                //CmdMouseSummon(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameObject[] test = GameObject.FindGameObjectsWithTag("Unit");
                foreach (GameObject unit in test)
                {
                    unit.GetComponent<UnitHealth>().CmdTakeDamage(100);
                }
            }
        }
    }

    void EnablePlayer()
    {
        if (isLocalPlayer)
        {
            //mainCamera.SetActive(false);
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

    [Command]
    public void CmdMouseSummon(int slotIndex, int unitcode)
    {
        Vector3 spawnPosition;
        Vector3 rot;

        startPositions = GameObject.FindGameObjectsWithTag("StartPosition");
        if (GetComponentInParent<Player>().transform.position.Equals(
            startPositions[0].transform.position))
        {
            spawnPosition = startPositions[0].transform.GetChild(1).position;
            rot = new Vector3(0, 180, 0);
        }
        else
        {
            spawnPosition = startPositions[1].transform.GetChild(1).position;
            rot = Vector3.zero;
        }

        Summoner.instance.SummonUnit(connectionToClient, spawnPosition, rot, unitcode);
        RpcDestroy(slotIndex);
    }

    [Command]
    public void CmdSetCard(int cardIndex)
    {
        RpcTest(cardIndex);
    }

    [ClientRpc]
    public void RpcStatus(string status)
    {
        Debug.Log(status);
    }

    [ClientRpc]
    public void RpcTest(int cardIndex)
    {
        m_cardManager.SelectCard(cardIndex);
    }

    [ClientRpc]
    public void RpcDestroy(int slotIndex)
    {
        unitManager.SelectUnit(slotIndex);
    }
}
