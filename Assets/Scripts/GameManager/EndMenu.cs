using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{





    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
        AkSoundEngine.SetState("Tower_Alive_or_Dead", "Alive");


    }

    public void QuitMenu()
    {
        Application.Quit();
    }
}
