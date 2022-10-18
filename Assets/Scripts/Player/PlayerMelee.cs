using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float damage = 5.0f;
    [SerializeField] private Rigidbody2D playerRigid;
    [SerializeField] private float bounceAdjuster = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Attack();

    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        if (hitEnemies.Length == 0) { return; }

        foreach (Collider2D enemy in hitEnemies)
        {
            playerRigid.AddForce(-attackPoint.position * bounceAdjuster, ForceMode2D.Force);
            enemy.GetComponent<Mob>().Damaged(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
