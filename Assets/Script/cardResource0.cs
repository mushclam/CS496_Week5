using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class cardResource0 : NetworkBehaviour, IPointerClickHandler
{
    public int cardIndex;
    private Sprite currentSprite;
    public Sprite emptyCard;

    public void OnPointerClick(PointerEventData eventData)
    {
        currentSprite = GetComponent<Image>().sprite;
        if (!currentSprite.Equals(emptyCard))
        {
            GetComponentInParent<Player>().CmdSetCard(cardIndex);
        }
    }
}
