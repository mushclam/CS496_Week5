using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UnitRsc1 : NetworkBehaviour, IPointerClickHandler
{
    private int tap;
    public int slotindex;
    private Player player;
    private Sprite currentSprite;
    public Sprite emptyUnit;

    public void OnPointerClick(PointerEventData eventData)
    {
        currentSprite = GetComponent<Image>().sprite;
        int unitcode = UnitManager.instance.GetUnitCode(currentSprite);

        tap = eventData.clickCount;

        if (tap == 1)
        {
            player = GetComponentInParent<Player>();
            if (unitcode == -1) return;
            player.CmdMouseSummon(slotindex, unitcode);
        }
    }
}
