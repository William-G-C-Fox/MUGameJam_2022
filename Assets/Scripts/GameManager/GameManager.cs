using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas endMenu;
    [SerializeField] private Canvas HUD;
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject player;
    private bool towerHealthZero;
    private bool oneHit;
    private float towerHealth;


    void Start()
    {
        endMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        TowerHealthCheck();
        HUD.GetComponentInChildren<HealthBar>().SetHealth(towerHealth);
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
}
