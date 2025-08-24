using UnityEngine;

// �J�[�h�̃f�[�^���Ǘ�����N���X
public class CardModel
{
    public string name;   // �J�[�h��
    public int hp;        // HP�i�̗́j
    public int at;        // AT�i�U���́j
    public int cost;      // �R�X�g
    public Sprite icon;   // �摜�i�A�C�R���j

    // �R���X�g���N�^�i�J�[�hID�������ɂ��ăf�[�^��ǂݍ��ށj
    public CardModel(int cardID)
    {
        // Resources�t�H���_����J�[�h�f�[�^���擾
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);

        // �擾�����f�[�^��CardModel�ɔ��f
        name = cardEntity.name;
        hp = cardEntity.hp;
        at = cardEntity.at;
        cost = cardEntity.cost;
        icon = cardEntity.icon;
    }
}