using UnityEngine;

public class GameManager : MonoBehaviour
{
    // カードのプレファブを入れる
    [SerializeField] CardController cardPrefab;

    // 両プレイヤーの手札のTransformを入れる
    [SerializeField] Transform PlayerHandTransform, EnemyHandTransform, EnemyFieldTransform;


    // プレイヤーのターンかどうかを判定する変数
    bool isPlayerTurn;

    void Start()
    {
        StartGame();
        isPlayerTurn = true; // ゲーム開始時はプレイヤーのターン
        TurnCalc();
    }

    private void StartGame()
    {
        SettingHand();
    }

    void CreateCard(Transform hand)
    {
        // 手札が5枚未満ならカードを追加
        if (hand.childCount < 5)
        {
            int randomCardID = Random.Range(1, 4);
            CardController card = Instantiate(cardPrefab, hand, false);
            card.Init(randomCardID);
        }
        else
        {
            Debug.Log("手札が上限に達しています！");
        }
    }

    void SettingHand()
    {
        // それぞれの手札に3枚カードを配る
        for (int i = 0; i < 3; i++)
        {
            CreateCard(PlayerHandTransform);  // プレイヤー用のカード
            CreateCard(EnemyHandTransform);   // 敵用のカード
        }
    }

    void TurnCalc()
    {
        // ターン進行の処理
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
        // プレイヤーのターン開始時の処理
        Debug.Log("プレイヤーのターンです");
    }

    void EnemyTurn()
    {
        // 敵のターン開始時の処理
        Debug.Log("敵のターンです");

        // 敵の手札にあるカードリストを取得
        CardController[] cardList = EnemyHandTransform.GetComponentsInChildren<CardController>();

        if (cardList.Length > 0)
        {
            // 1枚目のカードをフィールドに出す
            CardController card = cardList[0];

            // カードをフィールドに移動
            card.movement.SetCardTransform(EnemyFieldTransform);

            Debug.Log("敵がカードをフィールドに出しました");
        }
        else
        {
            Debug.Log("敵の手札がありません");
        }

        // ターンを終了する
        ChangeTurn();
    }

    public void ChangeTurn()
    {
        // ターンの切り替え処理
        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn)
        {
            // プレイヤーのターン開始時にカードをドロー
            CreateCard(PlayerHandTransform);
        }
        else
        {
            // 敵のターン開始時にカードをドロー
            CreateCard(EnemyHandTransform);
        }

        // 次のターンの処理を開始
        TurnCalc();
    }
}