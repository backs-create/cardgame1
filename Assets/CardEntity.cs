using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]
public class CardEntity : ScriptableObject
{
    public new string name; // �J�[�h��
    public int hp;          // HP
    public int at;          // �U����
    public int cost;        // �R�X�g
    public Sprite icon;     // �摜�i�A�C�R���j
}