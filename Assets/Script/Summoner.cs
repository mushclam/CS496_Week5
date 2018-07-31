using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Summoner : NetworkBehaviour {
    public static Summoner instance;

    [SerializeField] GameObject[] MonsterList;

    public Vector3 summonPosition;
    private GameObject summonedMonster;

    void Awake()
    {
        if (!instance)
            instance = this;
    }

    private void Start()
    {
        summonPosition = Vector3.zero;
    }

    public void SummonUnit(int unitCode)
    {
        CmdSummonInit(MonsterList[unitCode]);
    }

    [Command]
    private void CmdSummonInit(GameObject monster)
    {
        summonedMonster = Instantiate(monster, summonPosition, Quaternion.identity);
        NetworkServer.Spawn(summonedMonster);
    }
}
