using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob03ActionSound : MonoBehaviour
{
    public AK.Wwise.Event Mob03ActionAttack;
  
    public void Mob03Action_Attack()
    {
        Mob03ActionAttack.Post(gameObject);
    }
}
