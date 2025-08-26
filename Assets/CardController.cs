using UnityEngine;
using UnityEngine.UIElements;

public class CardController : MonoBehaviour
{
    // �J�[�h�f�[�^��\������
    CardView view;
    // �J�[�h�f�[�^���Ǘ�����
    CardModel model;
    // �J�[�h�̈ړ����Ǘ����邽�߂̕ϐ���ǉ�
    public CardMovement movement;

    private void Awake()
    {
        // CardView���擾
        view = GetComponent<CardView>();
        movement = GetComponent<CardMovement>();
    }

    public void Init(int cardID)
    {
        // CardModel���쐬���A�f�[�^��K�p
        model = new CardModel(cardID);
        view.Show(model);
    }

    public void TurnBack()
    {
        // "back"�Ƃ������O�̎q�I�u�W�F�N�g����Image�R���|�[�l���g���擾���ĕ\��
        var backObj = transform.Find("Back");
        if (backObj != null)
        {
            var image = backObj.GetComponent<UnityEngine.UI.Image>();
            if (image != null)
            {
                image.enabled = true;
            }
        }
    }

}