using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private Transform towerBase;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damaged(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0.0f)
        {
            //death;
        }

    }

    public Vector3 BaseGetPosition()
    {
        return towerBase.position;
    }
}
