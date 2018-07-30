using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitRsc1 : MonoBehaviour, IPointerClickHandler
{
    private int tap;
    private const int slotindex = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        tap = eventData.clickCount;
        if(tap == 2)
        {
            UnitManager.instance.SelectUnit(slotindex);
        }
    }
}
