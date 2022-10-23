using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob02ActionSound : MonoBehaviour
{
    public AK.Wwise.Event Mob02ActionAttack;
    public AK.Wwise.Event Mob02ActionDeath;
  
    public void Mob02Action_Attack()
    {
        Mob02ActionAttack.Post(gameObject);
    }

    public void Mob02Action_Death()
    {
        Mob02ActionDeath.Post(gameObject);
    }
}
