using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobActionSound : MonoBehaviour
{
     public AK.Wwise.Event MobActionAttack;
  
    public void MobAction_Attack()
    {
        MobActionAttack.Post(gameObject);
    }
}
