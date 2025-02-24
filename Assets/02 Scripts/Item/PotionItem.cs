using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : MonoBehaviour, IItem
{
    [SerializeField] private int heal = 60;

    public int Heal { get { return heal; } }

    public void OnCollisionEffect()
    {

    }
}
