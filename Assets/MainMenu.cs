using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu;
    [SerializeField] private Canvas credits;
    private bool switcher;
    // Start is called before the first frame update
    void Start()
    {
        switcher = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        credits.enabled = true;
        mainMenu.enabled = false;

    }

    public void MainMenuSwitch()
    {
        mainMenu.enabled = true;
        credits.enabled = false;

    }

}
