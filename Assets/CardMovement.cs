using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform defaultParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // カードをドラッグし始めた時の処理
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ中のカードの位置をマウスの位置に追従させる
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // カードを離した時の処理
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