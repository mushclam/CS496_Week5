using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour {
    public static Summoner instance;

    public GameObject MonsterType1;
    public GameObject MonsterType2;
    public GameObject MonsterType3;
    public GameObject MonsterType4;
    public GameObject MonsterType5;
    public GameObject MonsterType6;
    public GameObject MonsterType7;
    public GameObject MonsterType8;
    public GameObject MonsterType9;
    public GameObject MonsterType10;
    public GameObject MonsterType11;
    public GameObject MonsterType12;
    public GameObject MonsterType13;
    public GameObject MonsterType14;
    public GameObject MonsterType15;
    public GameObject MonsterType16;
    public GameObject MonsterType17;
    public GameObject MonsterType18;
    public GameObject MonsterType19;
    public GameObject MonsterType20;
    public GameObject MonsterType21;
    public GameObject MonsterType22;
    public GameObject MonsterType23;
    public GameObject MonsterType24;
    public GameObject MonsterType25;
    public GameObject MonsterType26;
    public GameObject MonsterType27;
    public GameObject MonsterType28;
    public GameObject MonsterType29;
    public GameObject MonsterType30;
    public GameObject MonsterType31;
    public GameObject MonsterType32;



    void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void SummonUnit(int unitCode)
    {
        switch(unitCode)
        {
            case 1:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 6:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 7:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 8:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 9:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 10:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 11:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 12:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 13:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 14:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 15:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 16:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 17:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 18:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 19:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 20:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 21:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 22:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 23:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 24:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 25:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 26:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 27:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 28:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 29:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 30:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 31:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            case 32:
                Instantiate(MonsterType1, this.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
