using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : MonoBehaviour, IItem
{
    [SerializeField] private int heal = 60;         //�浹�� ȸ���Ǵ� ü�� ��ġ

    public int Heal { get { return heal; } }

    public void OnCollisionEffect()
    {

    }
}
