using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            collision.gameObject.GetComponent<Mob>().Damaged(damage);
        }
    }
}
