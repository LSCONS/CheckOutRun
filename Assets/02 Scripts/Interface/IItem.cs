using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    void OnCollisionEffect();           //상속받은 아이템은 충돌처리 필요
}
