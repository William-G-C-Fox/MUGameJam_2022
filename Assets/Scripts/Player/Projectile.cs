using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 5.0f;
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

    private IEnumerator ProjLife()
    {

        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
