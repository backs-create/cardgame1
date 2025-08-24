using UnityEngine;

// カードのデータを管理するクラス
public class CardModel
{
    public string name;   // カード名
    public int hp;        // HP（体力）
    public int at;        // AT（攻撃力）
    public int cost;      // コスト
    public Sprite icon;   // 画像（アイコン）

    // コンストラクタ（カードIDを引数にしてデータを読み込む）
    public CardModel(int cardID)
    {
        // Resourcesフォルダからカードデータを取得
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);

        // 取得したデータをCardModelに反映
        name = cardEntity.name;
        hp = cardEntity.hp;
        at = cardEntity.at;
        cost = cardEntity.cost;
        icon = cardEntity.icon;
    }
}