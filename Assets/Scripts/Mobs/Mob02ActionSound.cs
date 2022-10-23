using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob02ActionSound : MonoBehaviour
{
    public AK.Wwise.Event Mob02ActionAttack;
  
    public void Mob02Action_Attack()
    {
        Mob02ActionAttack.Post(gameObject);
    }
}
