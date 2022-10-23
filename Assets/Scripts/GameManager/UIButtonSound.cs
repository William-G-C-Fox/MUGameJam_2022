using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AK.Wwise.Event ButtonClickSound;

    public void onClick()
    {
        ButtonClickSound.Post(gameObject);
    }
}
