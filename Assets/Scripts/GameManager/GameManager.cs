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
        endMenu.enabled = true;

    }

    void TowerHealthCheck()
    {
        if (tower.GetComponent<Tower>().GetHealth() <= 0.0f)
        {
            towerHealthZero = true;
        }
        else
        {
            return;
        }

    }
}
