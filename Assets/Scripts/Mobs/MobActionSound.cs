using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobActionSound : MonoBehaviour
{
    public AK.Wwise.Event MobActionAttack;
    public AK.Wwise.Event MobActionDeath;
  
    public void MobAction_Attack()
    {
        MobActionAttack.Post(gameObject);
    }

    public void MobAction_Death()
    {
        MobActionDeath.Post(gameObject);
    }
}
