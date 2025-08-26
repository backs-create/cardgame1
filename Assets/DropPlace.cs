using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // カードがドロップされた時に親を変更する（手札からのみ）
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
        if (card != null)
        {
            // ドラッグ開始前の親（defaultParent）が "Hand" タグの場合のみフィールドへ移動可能
            if (card.defaultParent != null && card.defaultParent.CompareTag("PlayerHand"))
            {
                card.defaultParent = this.transform;
            }
        }
    }
}