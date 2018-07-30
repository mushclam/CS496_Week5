using UnityEngine;
using UnityEngine.EventSystems;

public class UnitRsc3 : MonoBehaviour, IPointerClickHandler
{
    private int tap;
    private const int slotindex = 2;

    public void OnPointerClick(PointerEventData eventData)
    {
        tap = eventData.clickCount;
        if (tap == 2)
        {
            UnitManager.instance.SelectUnit(slotindex);
        }
    }
}