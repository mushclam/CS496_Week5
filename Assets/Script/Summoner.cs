using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Summoner : NetworkBehaviour {
    public static Summoner instance;

    [SerializeField] GameObject[] MonsterList;

    private GameObject summonedMonster;

    void Awake()
    {
        if (!instance)
            instance = this;
    }

    private void Start()
    {

    }

    public void SummonUnit(NetworkConnection conn, Vector3 summonPosition, int unitCode)
    {
        summonedMonster = Instantiate(
            MonsterList[unitCode],
            summonPosition,
            Quaternion.identity);

        NetworkServer.SpawnWithClientAuthority(summonedMonster, conn);
    }
}
