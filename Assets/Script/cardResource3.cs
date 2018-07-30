using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cardResource3 : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {

    }
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cardManager.instance.SelectCard(3);
    }
}
