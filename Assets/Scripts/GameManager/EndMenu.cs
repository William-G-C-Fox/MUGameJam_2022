using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    AK.Wwise.Event Stop_Music;
    
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetState("Tower_Alive_or_Dead", "Dead");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitMenu()
    {
        Application.Quit();
    }
}
