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

    void Start()
    {
        endMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
}
