using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;
    public Sprite unit1, unit2, unit3, unit4, unit5;

    public Sprite unitSprite1;      // 38
    public Sprite unitSprite2;      // 13
    public Sprite unitSprite2_2;    // 18
    public Sprite unitSprite3;      // 장
    public Sprite unitSprite4;      // 9
    public Sprite unitSprite5;      // 8
    public Sprite unitSprite6;      // 7
    public Sprite unitSprite7;      // 6
    public Sprite unitSprite8;      // 5
    public Sprite unitSprite9;      // 4
    public Sprite unitSprite10;      // 3
    public Sprite unitSprite11;      // 2
    public Sprite unitSprite12;      // 1
    public Sprite unitSprite13;      // 알리
    public Sprite unitSprite14;      // 독사
    public Sprite unitSprite15;      // 구삥
    public Sprite unitSprite16;      // 장삥
    public Sprite unitSprite17;      // 장사
    public Sprite unitSprite18;      // 세륙
    public Sprite unitSprite19;      // 갑오
    public Sprite unitSprite20;      // 여덟끗
    public Sprite unitSprite21;      // 일곱끗
    public Sprite unitSprite22;      // 여섯끗
    public Sprite unitSprite23;      // 다섯끗
    public Sprite unitSprite24;      // 네끗
    public Sprite unitSprite25;      // 세끗
    public Sprite unitSprite26;      // 두끗
    public Sprite unitSprite27;      // 한끗
    public Sprite unitSprite28;      // 망통
    public Sprite unitSprite29;      // 땡잡이
    public Sprite unitSprite30;      // 암행어사
    public Sprite unitSprite31;      // 구사
    public Sprite unitSprite32;      // 멍텅구리 구사

    public Sprite emptySprite;

    public Image slot1, slot2, slot3, slot4, slot5;

    void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void AddUnit(string gen)
    {
        Sprite unit_create;
        switch(gen)
        {
            case "삼팔광땡":
                unit_create = unitSprite1;
                break;
            case "일삼광땡":
                unit_create = unitSprite2;
                break;
            case "일팔광땡":
                unit_create = unitSprite2_2;
                break;
            case "장땡":
                unit_create = unitSprite3;
                break;
            case "구땡":
                unit_create = unitSprite4;
                break;
            case "팔땡":
                unit_create = unitSprite5;
                break;
            case "칠땡":
                unit_create = unitSprite6;
                break;
            case "육땡":
                unit_create = unitSprite7;
                break;
            case "오땡":
                unit_create = unitSprite8;
                break;
            case "사땡":
                unit_create = unitSprite9;
                break;
            case "삼땡":
                unit_create = unitSprite10;
                break;
            case "이땡":
                unit_create = unitSprite11;
                break;
            case "일땡":
                unit_create = unitSprite12;
                break;
            case "알리":
                unit_create = unitSprite13;
                break;
            case "독사":
                unit_create = unitSprite14;
                break;
            case "구삥":
                unit_create = unitSprite15;
                break;
            case "장삥":
                unit_create = unitSprite16;
                break;
            case "장사":
                unit_create = unitSprite17;
                break;
            case "세륙":
                unit_create = unitSprite18;
                break;
            case "갑오":
                unit_create = unitSprite19;
                break;
            case "여덟끗":
                unit_create = unitSprite20;
                break;
            case "일곱끗":
                unit_create = unitSprite21;
                break;
            case "여섯끗":
                unit_create = unitSprite22;
                break;
            case "다섯끗":
                unit_create = unitSprite23;
                break;
            case "네끗":
                unit_create = unitSprite24;
                break;
            case "세끗":
                unit_create = unitSprite25;
                break;
            case "두끗":
                unit_create = unitSprite26;
                break;
            case "한끗":
                unit_create = unitSprite27;
                break;
            case "망통":
                unit_create = unitSprite28;
                break;
            case "땡잡이":
                unit_create = unitSprite29;
                break;
            case "암행어사":
                unit_create = unitSprite30;
                break;
            case "구사":
                unit_create = unitSprite31;
                break;
            case "멍텅구리 구사":
                unit_create = unitSprite32;
                break;
            default:
                unit_create = emptySprite;
                break;
        }

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
        if (targetUnit.Equals(unitSprite1))
            return 1;
        else if (targetUnit.Equals(unitSprite2) || targetUnit.Equals(unitSprite2_2))
            return 2;
        else if (targetUnit.Equals(unitSprite3))
            return 3;
        else if (targetUnit.Equals(unitSprite4))
            return 4;
        else if (targetUnit.Equals(unitSprite5))
            return 5;
        else if (targetUnit.Equals(unitSprite6))
            return 6;
        else if (targetUnit.Equals(unitSprite7))
            return 7;
        else if (targetUnit.Equals(unitSprite8))
            return 8;
        else if (targetUnit.Equals(unitSprite9))
            return 9;
        else if (targetUnit.Equals(unitSprite10))
            return 10;
        else if (targetUnit.Equals(unitSprite11))
            return 11;
        else if (targetUnit.Equals(unitSprite12))
            return 12;
        else if (targetUnit.Equals(unitSprite13))
            return 13;
        else if (targetUnit.Equals(unitSprite14))
            return 14;
        else if (targetUnit.Equals(unitSprite15))
            return 15;
        else if (targetUnit.Equals(unitSprite16))
            return 16;
        else if (targetUnit.Equals(unitSprite17))
            return 17;
        else if (targetUnit.Equals(unitSprite18))
            return 18;
        else if (targetUnit.Equals(unitSprite19))
            return 19;
        else if (targetUnit.Equals(unitSprite20))
            return 20;
        else if (targetUnit.Equals(unitSprite21))
            return 21;
        else if (targetUnit.Equals(unitSprite22))
            return 22;
        else if (targetUnit.Equals(unitSprite23))
            return 23;
        else if (targetUnit.Equals(unitSprite24))
            return 24;
        else if (targetUnit.Equals(unitSprite25))
            return 25;
        else if (targetUnit.Equals(unitSprite26))
            return 26;
        else if (targetUnit.Equals(unitSprite27))
            return 27;
        else if (targetUnit.Equals(unitSprite28))
            return 28;
        else if (targetUnit.Equals(unitSprite29))
            return 29;
        else if (targetUnit.Equals(unitSprite30))
            return 30;
        else if (targetUnit.Equals(unitSprite31))
            return 31;
        else if (targetUnit.Equals(unitSprite32))
            return 32;
        else
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
