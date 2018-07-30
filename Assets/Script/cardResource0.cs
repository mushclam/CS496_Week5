using UnityEngine;
using UnityEngine.EventSystems;

public class cardResource0 : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        cardManager.instance.SelectCard(0);
    }
}
