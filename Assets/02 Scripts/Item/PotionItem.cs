using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : MonoBehaviour, IItem
{
    [SerializeField] private int heal = 60;         //충돌시 회복되는 체력 수치

    public int Heal { get { return heal; } }

    public void OnCollisionEffect()
    {

    }
}
