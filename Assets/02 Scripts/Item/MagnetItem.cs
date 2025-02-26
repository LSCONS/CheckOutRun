using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour, IItem
{
    //public float magnetDuration = 5f; 
    //private PlayerController playerController;
    public void OnCollisionEffect()
    {
     
        //PlayerController player = FindObjectOfType<PlayerController>();
        //if (player != null)
        //{
        //    playerController.MagnetEffect(magnetDuration);
        //}

        Destroy(gameObject);
    }
}
