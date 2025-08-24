using UnityEngine;

public class CardController : MonoBehaviour
{
    // カードデータを表示する
    CardView view;
    // カードデータを管理する
    CardModel model;
    // カードの移動を管理するための変数を追加
    public CardMovement movement;

    private void Awake()
    {
        // CardViewを取得
        view = GetComponent<CardView>();
        movement = GetComponent<CardMovement>();
    }

    public void Init(int cardID)
    {
        // CardModelを作成し、データを適用
        model = new CardModel(cardID);
        view.Show(model);
    }

}