using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float damage = 5.0f;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 5;

    private GameObject towerObj;
    private Vector3 towerPos;
    private Rigidbody2D mobRigidBody;

    private Vector3 lookAtPlayer;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        towerObj = GameObject.FindGameObjectWithTag("Tower");
        mobRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //AI();
    }

    void AI()
    {
        towerPos = towerObj.GetComponent<Tower>().BaseGetPosition();
        mobRigidBody.velocity = Vector2.zero;
        mobRigidBody.position = Vector2.MoveTowards(mobRigidBody.position, towerPos, speed * Time.deltaTime);

        lookAtPlayer = towerPos - transform.position;
        lookAtPlayer.Normalize();
        angle = Mathf.Atan2(towerPos.y, towerPos.x) * Mathf.Rad2Deg;

        if (angle > 130 && angle < 179)
        {
            //monSprite.flipX = false;
        }
        else if (angle > -179 && angle < -130)
        {
            //monSprite.flipX = false;
        }
        else
        {
            //monSprite.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            collision.gameObject.GetComponent<Tower>().Damaged(damage);
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void Damaged(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }
}
