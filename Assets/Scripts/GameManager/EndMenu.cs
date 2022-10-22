using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    AK.Wwise.Event Play_Music;
    AK.Wwise.Event Stop_Music;
   

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetState("Tower_Alive_or_Dead", "Dead");
        Stop_Music.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
        Play_Music.Post(gameObject);
    }

    public void QuitMenu()
    {
        SceneManager.LoadScene(0);
    }
}
