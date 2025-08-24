using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform defaultParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �J�[�h���h���b�O���n�߂����̏���
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �h���b�O���̃J�[�h�̈ʒu���}�E�X�̈ʒu�ɒǏ]������
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �J�[�h�𗣂������̏���
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