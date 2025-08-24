using UnityEngine;

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

}