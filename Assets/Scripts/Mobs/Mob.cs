using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float damage = 5.0f;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 5;
    [SerializeField] private SpriteRenderer mobSp;
    [SerializeField] private Animator mobAnime;

    private GameObject towerObj;
    private Vector2 towerPos;
    private Rigidbody2D mobRigidBody;
    private float posCheck;
    private Vector3 lookAtPlayer;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        towerObj = GameObject.FindGameObjectWithTag("Tower");
        mobRigidBody = GetComponent<Rigidbody2D>();
        posCheck = mobRigidBody.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        AI();
    }

    void AI()
    {
        if (towerObj == null) return;
        towerPos = towerObj.GetComponent<Tower>().BaseGetPosition();
        mobRigidBody.velocity = Vector2.zero;
        mobRigidBody.position = Vector2.MoveTowards(mobRigidBody.position, towerPos, speed * Time.deltaTime);



        if (posCheck > mobRigidBody.position.x)
        {
            mobSp.flipX = true;
        }
        else
        {
            mobSp.flipX = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            StartCoroutine(DeathAnim());
            collision.gameObject.GetComponent<Tower>().Damaged(damage);

        }
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlayerScript>().SetShield(true);
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
            StartCoroutine(DeathAnim());
        }
    }

    private IEnumerator DeathAnim()
    {
        mobAnime.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.75f);
        Death();
    }
}
