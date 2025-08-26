using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // �J�[�h���h���b�v���ꂽ���ɐe��ύX����i��D����̂݁j
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
        if (card != null)
        {
            // �h���b�O�J�n�O�̐e�idefaultParent�j�� "Hand" �^�O�̏ꍇ�̂݃t�B�[���h�ֈړ��\
            if (card.defaultParent != null && card.defaultParent.CompareTag("PlayerHand"))
            {
                card.defaultParent = this.transform;
            }
        }
    }
}