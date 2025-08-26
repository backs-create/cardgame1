using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform defaultParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultParent = transform.parent;

        if (transform.parent.tag == "PlayerHand")
        {
            transform.SetParent(defaultParent.parent, false);
            GetComponent<CanvasGroup>().blocksRaycasts = false;

            // ドラッグ開始時にカードを前面に
            transform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (defaultParent.tag == "PlayerHand")
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    // 手札からフィールドにカードの位置を変更する
    public void SetCardTransform(Transform parentTransform)
    {
        defaultParent = parentTransform;  // 新しい親（フィールド）を設定
        transform.SetParent(defaultParent, false);  // 親オブジェクトを変更
    }
}