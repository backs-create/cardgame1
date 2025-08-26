using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    // �J�[�h�̃v���t�@�u������
    [SerializeField] CardController cardPrefab;

    // ���v���C���[�̎�D��Transform������
    [SerializeField] Transform PlayerHandTransform, EnemyHandTransform, EnemyFieldTransform;

    [SerializeField] TextMeshProUGUI Timecounter;


    double turnTime = 10.0; // �^�[���̐������ԁi�b�j
    double currentTime;    // ���݂̌o�ߎ���


    // �v���C���[�̃^�[�����ǂ����𔻒肷��ϐ�
    bool isPlayerTurn;

    void Start()
    {
        StartGame();
        isPlayerTurn = true; // �Q�[���J�n���̓v���C���[�̃^�[��
        TurnCalc();
    }

    void Update()
    {
        TimeCount();
    }

    private void TimeCount()
    {
        Timecounter.text = ((turnTime - currentTime).ToString("F1"));
        currentTime += Time.deltaTime;
        if (currentTime >= turnTime)
        {
            // �^�[���I���̏���
            ChangeTurn();
        }
    }


    private void StartGame()
    {
        SettingHand();
    }

    void CreateCard(Transform hand)
    {
        // ��D��5�������Ȃ�J�[�h��ǉ�
        if (hand.childCount < 5)
        {
            int randomCardID = Random.Range(1, 4);
            CardController card = Instantiate(cardPrefab, hand, false);
            card.Init(randomCardID);
            
            if(hand.tag == "EnemyHand")
            {
                card.TurnBack(); // �G�̃J�[�h�͗������ɂ���
            }

        }
        else
        {
            Debug.Log("��D������ɒB���Ă��܂��I");
        }
    }

    void SettingHand()
    {
        // ���ꂼ��̎�D��3���J�[�h��z��
        for (int i = 0; i < 3; i++)
        {
            CreateCard(PlayerHandTransform);  // �v���C���[�p�̃J�[�h
            CreateCard(EnemyHandTransform);   // �G�p�̃J�[�h
        }
    }

    void TurnCalc()
    {
        // �^�[���i�s�̏���
        if (isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTurn();
        }
    }

    void PlayerTurn()
    {
        // �v���C���[�̃^�[���J�n���̏���
        Debug.Log("�v���C���[�̃^�[���ł�");
    }

    void EnemyTurn()
    {
        // �G�̃^�[���J�n���̏���
        Debug.Log("�G�̃^�[���ł�");

        // �G�̎�D�ɂ���J�[�h���X�g���擾
        CardController[] cardList = EnemyHandTransform.GetComponentsInChildren<CardController>();

        if (cardList.Length > 0)
        {
            // 1���ڂ̃J�[�h���t�B�[���h�ɏo��
            CardController card = cardList[0];

            // �J�[�h���t�B�[���h�Ɉړ�
            card.movement.SetCardTransform(EnemyFieldTransform);

            Debug.Log("�G���J�[�h���t�B�[���h�ɏo���܂���");
        }
        else
        {
            Debug.Log("�G�̎�D������܂���");
        }

        // �^�[�����I������
        ChangeTurn();
    }

    public void ChangeTurn()
    {
        currentTime = 0; // ���Ԃ����Z�b�g
        // �^�[���̐؂�ւ�����
        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn)
        {
            // �v���C���[�̃^�[���J�n���ɃJ�[�h���h���[
            CreateCard(PlayerHandTransform);
        }
        else
        {
            // �G�̃^�[���J�n���ɃJ�[�h���h���[
            CreateCard(EnemyHandTransform);
        }

        // ���̃^�[���̏������J�n
        TurnCalc();
    }
}