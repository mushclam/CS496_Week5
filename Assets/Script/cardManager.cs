using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardManager : MonoBehaviour {

    public static cardManager instance;
    private Sprite card1, card2, card3, card4;

    public Sprite cardSprite1;
    public Sprite cardSprite2;
    public Sprite cardSprite3;
    public Sprite cardSprite4;
    public Sprite cardSprite5;
    public Sprite cardSprite6;
    public Sprite cardSprite7;
    public Sprite cardSprite8;
    public Sprite cardSprite9;
    public Sprite cardSprite10;
    public Sprite cardSprite11;
    public Sprite cardSprite12;
    public Sprite cardSprite13;
    public Sprite cardSprite14;
    public Sprite cardSprite15;
    public Sprite cardSprite16;
    public Sprite cardSprite17;
    public Sprite cardSprite18;
    public Sprite cardSprite19;
    public Sprite cardSprite20;

    public Sprite emptySprite;

    public Image slot1, slot2, slot3, slot4;
    public Text geneaology;
    bool[] selectedList = new bool[4];


    void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void Start()
    {
        card1 = emptySprite;
        card2 = emptySprite;
        card3 = emptySprite;
        card4 = emptySprite;
        InvokeRepeating("GetCard", 1, 0.5f);
    }

    void ShowCardList()
    {
        slot1.sprite = card1;
        slot2.sprite = card2;
        slot3.sprite = card3;
        slot4.sprite = card4;
    }
    
    public void SelectCard(int index)
    {
        if (!getTargetCardInSlot(index).Equals(emptySprite))
        {
            selectedList[index] = !selectedList[index];
            if (trueCount(selectedList) == 2)
            {
                int idx1 = GetSelectedCardIndexInArray(selectedList)[0];
                int idx2 = GetSelectedCardIndexInArray(selectedList)[1];
                string gen = GetGenealogy(GetCardCodeInSlot(idx1), GetCardCodeInSlot(idx2));

                ShowGenealogy(gen);
                UnitManager.instance.AddUnit(gen);

                selectedList[idx1] = false;
                selectedList[idx2] = false;
                // destroy
                // sort
                SortCardList(idx1, idx2);
                ShowCardList();
            }
        }

    }
    
    public void ShowGenealogy(string gen)
    {
        geneaology.text = gen;
    }
    
    public void GetCard()
    {
        if (card4.Equals(emptySprite))
        {
            Sprite c;
            int ccode;
            do
            {
                ccode = Random.Range(1, 21);
                switch (ccode)
                {
                    case 1:
                        c = cardSprite1;
                        break;
                    case 2:
                        c = cardSprite2;
                        break;
                    case 3:
                        c = cardSprite3;
                        break;
                    case 4:
                        c = cardSprite4;
                        break;
                    case 5:
                        c = cardSprite5;
                        break;
                    case 6:
                        c = cardSprite6;
                        break;
                    case 7:
                        c = cardSprite7;
                        break;
                    case 8:
                        c = cardSprite8;
                        break;
                    case 9:
                        c = cardSprite9;
                        break;
                    case 10:
                        c = cardSprite10;
                        break;
                    case 11:
                        c = cardSprite11;
                        break;
                    case 12:
                        c = cardSprite12;
                        break;
                    case 13:
                        c = cardSprite13;
                        break;
                    case 14:
                        c = cardSprite14;
                        break;
                    case 15:
                        c = cardSprite15;
                        break;
                    case 16:
                        c = cardSprite16;
                        break;
                    case 17:
                        c = cardSprite17;
                        break;
                    case 18:
                        c = cardSprite18;
                        break;
                    case 19:
                        c = cardSprite19;
                        break;
                    case 20:
                        c = cardSprite20;
                        break;
                    default:
                        c = emptySprite;
                        break;
                }

                if (card1.Equals(emptySprite))
                {
                    card1 = c;
                    break;
                }
                else if (card2.Equals(emptySprite))
                {
                    if (!c.Equals(card1))
                    {
                        card2 = c;
                        break;
                    }
                }
                else if (card3.Equals(emptySprite))
                {
                    if (!c.Equals(card1) && !c.Equals(card2))
                    {
                        card3 = c;
                        break;
                    }
                }
                else
                {
                    if (!c.Equals(card1) && !c.Equals(card2) && !c.Equals(card3))
                    {
                        card4 = c;
                        break;
                    }
                }
            } while (true);

            ShowCardList();
        }
    }

    void SortCardList(int idx1, int idx2)
    {
        if (idx2 == 1)
        {
            if (!card4.Equals(emptySprite))
            {
                card1 = card3;
                card2 = card4;
                card3 = emptySprite;
                card4 = emptySprite;
            }
            else if (!card3.Equals(emptySprite))
            {
                card1 = card3;
                card2 = emptySprite;
                card3 = emptySprite;
            }
            else
            {
                card1 = emptySprite;
                card2 = emptySprite;
            }
        }
        else if (idx2 == 2)
        {
            if (idx1 == 0)
            {
                if (!card4.Equals(emptySprite))
                {
                    card1 = card2;
                    card2 = card4;
                    card3 = emptySprite;
                    card4 = emptySprite;
                }
                else
                {
                    card1 = card2;
                    card2 = emptySprite;
                    card3 = emptySprite;
                }
            }
            else if (idx1 == 1)
            {
                if (!card4.Equals(emptySprite))
                {
                    card2 = card4;
                    card3 = emptySprite;
                    card4 = emptySprite;
                }
                else
                {
                    card2 = emptySprite;
                    card3 = emptySprite;
                }
            }
        }
        else if (idx2 == 3)
        {
            if (idx1 == 0)
            {
                card1 = card2;
                card2 = card3;
            }
            else if (idx1 == 1)
            {
                card2 = card3;
            }
            card3 = emptySprite;
            card4 = emptySprite;
        }
    }


    string GetGenealogy(int card1, int card2)
    {
        int c1remain = card1 % 10;
        int c2remain = card2 % 10;
        int sum = card1 + card2;
        int remainSum = c1remain + c2remain;

        if (sum == 11 && (card1 == 3 || card2 == 3))
            return "삼팔광땡";
        else if (sum == 4 && (card1 == 3 || card2 == 3))
            return "일삼광땡";
        else if (sum == 9 && (card1 == 1 || card2 == 1))
            return "일팔광땡";
        else if (sum == 30 && (card1 == 10 || card2 == 10))
            return "장땡";
        else if (sum == 28 && (card1 == 9 || card2 == 9))
            return "구땡";
        else if (sum == 26 && (card1 == 8 || card2 == 8))
            return "팔땡";
        else if (sum == 24 && (card1 == 7 || card2 == 7))
            return "칠땡";
        else if (sum == 22 && (card1 == 6 || card2 == 6))
            return "육땡";
        else if (sum == 20 && (card1 == 5 || card2 == 5))
            return "오땡";
        else if (sum == 18 && (card1 == 4 || card2 == 4))
            return "사땡";
        else if (sum == 16 && (card1 == 3 || card2 == 3))
            return "삼땡";
        else if (sum == 14 && (card1 == 2 || card2 == 2))
            return "이땡";
        else if (sum == 12 && (card1 == 1 || card2 == 1))
            return "일땡";
        else if (remainSum == 3 && (c1remain == 1 || c2remain == 1))
            return "알리";
        else if (remainSum == 5 && (c1remain == 1 || c2remain == 1))
            return "독사";
        else if (remainSum == 10 && (c1remain == 1 || c2remain == 1))
            return "구삥";
        else if (remainSum == 1 && (c1remain == 1 || c2remain == 1))
            return "장삥";
        else if (remainSum == 4 && (c1remain == 4 || c2remain == 4))
            return "장사";
        else if (remainSum == 10 && (c1remain == 4 || c2remain == 4))
            return "세륙";
        else if (sum == 13 && (card1 == 4 || card2 == 4))
            return "멍텅구리 구사";
        else if (remainSum == 13 && (c1remain == 4 || c2remain == 4))
            return "구사";
        else if (remainSum == 10 && (c1remain == 3 || c2remain == 3))
            return "땡잡이";
        else if (sum == 11 && (card1 == 4 || card2 == 4))
            return "암행어사";
        else if (remainSum % 10 == 9)
            return "갑오";
        else if (remainSum % 10 == 8)
            return "여덟끗";
        else if (remainSum % 10 == 7)
            return "일곱끗";
        else if (remainSum % 10 == 6)
            return "여섯끗";
        else if (remainSum % 10 == 5)
            return "다섯끗";
        else if (remainSum % 10 == 4)
            return "네끗";
        else if (remainSum % 10 == 3)
            return "세끗";
        else if (remainSum % 10 == 2)
            return "두끗";
        else if (remainSum % 10 == 1)
            return "한끗";
        else if (remainSum == 10)
            return "망통";
        else
            return "";
    }

    Sprite getTargetCardInSlot(int index)
    {
        switch (index)
        {
            case 0:
                return card1;
            case 1:
                return card2;
            case 2:
                return card3;
            case 3:
                return card4;
            default:
                return null;
        }
    }

    int trueCount(bool[] arr)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == true)
                count++;
        }
        return count;
    }

    public int GetCardCodeInSlot(int slotIndex)
    {
        Sprite targetSlot = getTargetCardInSlot(slotIndex);
        if (targetSlot.Equals(cardSprite1))
            return 1;
        else if (targetSlot.Equals(cardSprite2))
            return 2;
        else if (targetSlot.Equals(cardSprite3))
            return 3;
        else if (targetSlot.Equals(cardSprite4))
            return 4;
        else if (targetSlot.Equals(cardSprite5))
            return 5;
        else if (targetSlot.Equals(cardSprite6))
            return 6;
        else if (targetSlot.Equals(cardSprite7))
            return 7;
        else if (targetSlot.Equals(cardSprite8))
            return 8;
        else if (targetSlot.Equals(cardSprite9))
            return 9;
        else if (targetSlot.Equals(cardSprite10))
            return 10;
        else if (targetSlot.Equals(cardSprite11))
            return 11;
        else if (targetSlot.Equals(cardSprite12))
            return 12;
        else if (targetSlot.Equals(cardSprite13))
            return 13;
        else if (targetSlot.Equals(cardSprite14))
            return 14;
        else if (targetSlot.Equals(cardSprite15))
            return 15;
        else if (targetSlot.Equals(cardSprite16))
            return 16;
        else if (targetSlot.Equals(cardSprite17))
            return 17;
        else if (targetSlot.Equals(cardSprite18))
            return 18;
        else if (targetSlot.Equals(cardSprite19))
            return 19;
        else if (targetSlot.Equals(cardSprite20))
            return 20;
        else
            return -1;
    }

    int[] GetSelectedCardIndexInArray(bool[] selectedList)
    {
        int idx1 = -1;
        int idx2 = -1;
        for (int i = 0; i < selectedList.Length; i++)
        {
            if (selectedList[i] == true)
            {
                if (idx1 == -1)
                    idx1 = i;
                else
                    idx2 = i;
            }
        }
        int[] arr = new int[2];
        arr[0] = idx1;
        arr[1] = idx2;
        return arr;
    }
}
