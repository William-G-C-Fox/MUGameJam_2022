using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSound : MonoBehaviour
{
    public AK.Wwise.Event PlayerActionFootsteps;
    public AK.Wwise.Event PlayerActionStunPlay;
    public AK.Wwise.Event PlayerActionStunStop;
  
    public void Player_Action_Footsteps()
    {
        PlayerActionFootsteps.Post(gameObject);
    }
     
    public void Player_Action_StunPlay()
    {
        PlayerActionStunPlay.Post(gameObject);
    }

    public void Player_Action_StunStop()
    {
        PlayerActionStunStop.Post(gameObject);
    }
}
