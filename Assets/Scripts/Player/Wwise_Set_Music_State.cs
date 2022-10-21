using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wwise_Set_Music_State : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        AkSoundEngine.SetState("Tower_Alive_or_Dead", "Alive");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
