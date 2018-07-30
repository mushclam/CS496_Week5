using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour {
    private int card_code;
    public GameObject card_prefab_1;
    public GameObject card_prefab_2;
    public GameObject card_prefab_3;
    public GameObject card_prefab_4;
    public GameObject card_prefab_5;
    public GameObject card_prefab_6;
    public GameObject card_prefab_7;
    public GameObject card_prefab_8;
    public GameObject card_prefab_9;
    public GameObject card_prefab_10;
    public GameObject card_prefab_11;
    public GameObject card_prefab_12;
    public GameObject card_prefab_13;
    public GameObject card_prefab_14;
    public GameObject card_prefab_15;
    public GameObject card_prefab_16;
    public GameObject card_prefab_17;
    public GameObject card_prefab_18;
    public GameObject card_prefab_19;
    public GameObject card_prefab_20;

    public GameObject genText;
        
    public GameObject card;
    // Use this for initialization
    void Start () {
        //InvokeRepeating("GetCard", 1, 5.0f);
	}

    GameObject Get_card_prefab(int card_code)
    {
        switch(card_code)
        {
            case 1:
                return card_prefab_1;
            case 2:
                return card_prefab_2;
            case 3:
                return card_prefab_3;
            case 4:
                return card_prefab_4;
            case 5:
                return card_prefab_5;
            case 6:
                return card_prefab_6;
            case 7:
                return card_prefab_7;
            case 8:
                return card_prefab_8;
            case 9:
                return card_prefab_9;
            case 10:
                return card_prefab_10;
            case 11:
                return card_prefab_11;
            case 12:
                return card_prefab_12;
            case 13:
                return card_prefab_13;
            case 14:
                return card_prefab_14;
            case 15:
                return card_prefab_15;
            case 16:
                return card_prefab_16;
            case 17:
                return card_prefab_17;
            case 18:
                return card_prefab_18;
            case 19:
                return card_prefab_19;
            case 20:
                return card_prefab_20;
            default:
                return card_prefab_20;
        }
    }

    void GetCard()
    {
        int card1, card2;
        card1 = Random.Range(1, 21);
        do
        {
            card2 = Random.Range(1, 21);
        } while (card1 == card2);
        Instantiate(Get_card_prefab(card1), this.transform.position, Quaternion.identity);
        Instantiate(Get_card_prefab(card2), this.transform.position + new Vector3(2, 0, 0), Quaternion.identity);

        string Gen = GetGenealogy(card1, card2);
        genManager.instance.setGenealogy(Gen);
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
        else if (sum == 30)
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

	// Update is called once per frame
	void Update () {
		
	}
    void OnClick()
    {
        Destroy(this.gameObject);
        Instantiate(card_prefab_20, this.transform.position + new Vector3(10, 0, 0), Quaternion.identity);
    }/*
    void OnDestroy()
    {
        Instantiate(card, this.transform.position + new Vector3 (10, 0, 0), Quaternion.identity);
    }*/
}
