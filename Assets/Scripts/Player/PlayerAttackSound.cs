using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSound : MonoBehaviour
{
    public AK.Wwise.Event PlayerAttackSoundPlay;

    public void Player_AttackSound()
    {
        PlayerAttackSoundPlay.Post(gameObject);
    }
}
