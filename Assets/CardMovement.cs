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

            // �h���b�O�J�n���ɃJ�[�h��O�ʂ�
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

    // ��D����t�B�[���h�ɃJ�[�h�̈ʒu��ύX����
    public void SetCardTransform(Transform parentTransform)
    {
        defaultParent = parentTransform;  // �V�����e�i�t�B�[���h�j��ݒ�
        transform.SetParent(defaultParent, false);  // �e�I�u�W�F�N�g��ύX
    }
}