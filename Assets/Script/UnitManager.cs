using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;
    public Sprite unit1, unit2, unit3, unit4, unit5;

    [SerializeField] public Sprite[] unitSprites;
    private Dictionary<string, int> orderDic;

    public Sprite emptySprite;

    public Image slot1, slot2, slot3, slot4, slot5;

    void Awake()
    {
        if (!instance)
            instance = this;

        orderDic = new Dictionary<string, int>()
        {
            { "삼팔광땡", 1 },
            { "일삼광땡", 2 },
            { "일팔광땡", 3 },
            { "장땡", 4 },
            { "구땡", 5 },
            { "팔땡", 6  },
            { "칠땡", 7 },
            { "육땡", 8 },
            { "오땡", 9 },
            { "사땡", 10 },
            { "삼땡", 11 },
            { "이땡", 12 },
            { "일땡", 13 },
            { "알리", 14 },
            { "독사", 15 },
            { "구삥", 16 },
            { "장삥", 17 },
            { "장사", 18 },
            { "세륙", 19 },
            { "갑오", 20 },
            { "여덟끗", 21 },
            { "일곱끗", 22 },
            { "여섯끗", 23 },
            { "다섯끗", 24 },
            { "네끗", 25 },
            { "세끗", 26 },
            { "두끗", 27 },
            { "한끗", 28 },
            { "망통", 29 },
            { "땡잡이", 30 },
            { "암행어사", 31 },
            { "구사", 32 },
            { "멍텅구리 구사", 33 }
        };
    }

    public void AddUnit(string gen)
    {
        Sprite unit_create;
        int orderValue;

        orderDic.TryGetValue(gen, out orderValue);
        unit_create = unitSprites[orderValue - 1];

        if (unit1.Equals(emptySprite))
            unit1 = unit_create;
        else if (unit2.Equals(emptySprite))
            unit2 = unit_create;
        else if (unit3.Equals(emptySprite))
            unit3 = unit_create;
        else if (unit4.Equals(emptySprite))
            unit4 = unit_create;
        else
            unit5 = unit_create;

        ShowUnitList();
    }

    public void SelectUnit(int slotindex)
    {
        Sprite targetUnit = GetTargetUnitInSlot(slotindex);
        if(!targetUnit.Equals(emptySprite))
        {
            int unitcode = GetUnitCode(targetUnit);
            Summoner.instance.SummonUnit(unitcode);
            //sort & destroy
            DestroyAndSortUnitList(slotindex);
            ShowUnitList();
        }
    }

    int GetUnitCode(Sprite targetUnit)
    {
        for (int i = 0; i < unitSprites.Length; i++)
        {
            if (targetUnit.Equals(unitSprites[i]))
            {
                return i;
            }
        }

        return -1;
    }


    void DestroyAndSortUnitList(int idx)
    {
        switch(idx)
        {
            case 0:
                if(!unit5.Equals(emptySprite))
                {
                    unit1 = unit2;
                    unit2 = unit3;
                    unit3 = unit4;
                    unit4 = unit5;
                    unit5 = emptySprite;
                }
                else if(!unit4.Equals(emptySprite))
                {
                    unit1 = unit2;
                    unit2 = unit3;
                    unit3 = unit4;
                    unit4 = emptySprite;
                }
                else if (!unit3.Equals(emptySprite))
                {
                    unit1 = unit2;
                    unit2 = unit3;
                    unit3 = emptySprite;
                }
                else if (!unit2.Equals(emptySprite))
                {
                    unit1 = unit2;
                    unit2 = emptySprite;
                }
                else
                {
                    unit1 = emptySprite;
                }
                break;

            case 1:
                if (!unit5.Equals(emptySprite))
                {
                    unit2 = unit3;
                    unit3 = unit4;
                    unit4 = unit5;
                    unit5 = emptySprite;
                }
                else if (!unit4.Equals(emptySprite))
                {
                    unit2 = unit3;
                    unit3 = unit4;
                    unit4 = emptySprite;
                }
                else if (!unit3.Equals(emptySprite))
                {
                    unit2 = unit3;
                    unit3 = emptySprite;
                }
                else
                {
                    unit2 = emptySprite;
                }
                break;

            case 2:
                if (!unit5.Equals(emptySprite))
                {
                    unit3 = unit4;
                    unit4 = unit5;
                    unit5 = emptySprite;
                }
                else if (!unit4.Equals(emptySprite))
                {
                    unit3 = unit4;
                    unit4 = emptySprite;
                }
                else
                {
                    unit3 = emptySprite;
                }
                break;

            case 3:
                if (!unit5.Equals(emptySprite))
                {
                    unit4 = unit5;
                    unit5 = emptySprite;
                }
                else
                {
                    unit4 = emptySprite;
                }
                break;

            case 4:
                unit5 = emptySprite;
                break;

            default:
                break;
        }
    }

    Sprite GetTargetUnitInSlot(int index)
    {
        switch (index)
        {
            case 0:
                return unit1;
            case 1:
                return unit2;
            case 2:
                return unit3;
            case 3:
                return unit4;
            case 4:
                return unit5;
            default:
                return null;
        }
    }




    void ShowUnitList()
    {
        slot1.sprite = unit1;
        slot2.sprite = unit2;
        slot3.sprite = unit3;
        slot4.sprite = unit4;
        slot5.sprite = unit5;
    }

    public void Start()
    {
        unit1 = emptySprite;
        unit2 = emptySprite;
        unit3 = emptySprite;
        unit4 = emptySprite;
        unit5 = emptySprite;
    }
}
