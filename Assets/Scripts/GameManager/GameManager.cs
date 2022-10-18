using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas endMenu;
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

        if (tower.GetComponent<Tower>().GetHealth() <= 0.0f)
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
        EndofGameCleanup();
        Destroy(tower.gameObject);
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
