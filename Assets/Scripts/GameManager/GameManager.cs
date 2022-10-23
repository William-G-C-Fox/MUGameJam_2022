using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas endMenu;
    [SerializeField] private Canvas HUD;
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI timeText;

    private bool towerHealthZero;
    private bool oneHit;
    private float towerHealth;
    private string mintuesDisplay, secondsDisplay;
    private TextMeshProUGUI timerText;

    void Start()
    {
        TowerHealthCheck();
        endMenu.enabled = false;
        AkSoundEngine.SetState("Tower_Alive_or_Dead", "Alive");
        HUD.GetComponentInChildren<HealthBar>().SetMaxHealth(towerHealth);
        timerText = HUD.GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        TowerHealthCheck();
        HUD.GetComponentInChildren<HealthBar>().SetHealth(towerHealth);
        timerText.text = TimeSurvived();
        if (towerHealthZero)
        {
            if (oneHit)
            {
                return;
            }
            else
            {
                oneHit = true;
                EndGame();
                AkSoundEngine.SetState("Tower_Alive_or_Dead", "Dead");
            }
        }
        else
        {
            return;
        }

    }

    void EndGame()
    {
        StartCoroutine(EndTimer());

    }

    void TowerHealthCheck()
    {

        if (tower == null) return;
        towerHealth = tower.GetComponent<Tower>().GetHealth();


        if (towerHealth <= 0.0f)
        {
            towerHealthZero = true;
        }
        else
        {
            return;
        }

    }

    private IEnumerator EndTimer()
    {
        player.GetComponent<PlayerScript>().SetPlayerEnabled(false);
        player.GetComponent<PlayerScript>().SetStunned(true);
        EndofGameCleanup();
        yield return new WaitForSeconds(3.0f);

        timeText.text = TimeSurvived();
        endMenu.enabled = true;
    }

    private void EndofGameCleanup()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("MobSpawner");
        foreach (GameObject spawn in spawners)
        {
            Destroy(spawn);
        }
        GameObject[] mobs = GameObject.FindGameObjectsWithTag("Mob");
        foreach (GameObject mob in mobs)
        {
            mob.GetComponent<Mob>().Damaged(100);
        }

    }

    private string TimeSurvived()
    {
        float time = Time.time;
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);
        string timeDisplay;

        if (minutes < 10)
        {
            mintuesDisplay = "0" + minutes.ToString();
        }
        else
        {
            mintuesDisplay = minutes.ToString();
        }

        if (seconds < 10)
        {
            secondsDisplay = "0" + Mathf.RoundToInt(seconds).ToString();
        }
        else
        {
            secondsDisplay = seconds.ToString();
        }

        Debug.Log(secondsDisplay);

        timeDisplay = mintuesDisplay + ":" + secondsDisplay;
        return timeDisplay;
    }
}
