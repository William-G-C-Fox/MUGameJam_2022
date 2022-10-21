using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSound : MonoBehaviour
{
    public AK.Wwise.Event PlayerActionFootsteps;
  
    public void Player_Action_Footsteps()
    {
        PlayerActionFootsteps.Post(gameObject);
    }
}
