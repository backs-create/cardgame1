using UnityEngine;
using UnityEngine.UIElements;

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

    public void TurnBack()
    {
        // "back"という名前の子オブジェクトからImageコンポーネントを取得して表示
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