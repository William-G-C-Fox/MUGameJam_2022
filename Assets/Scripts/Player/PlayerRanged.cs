using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRanged : MonoBehaviour
{
    public AK.Wwise.Event Play_Playerrangeattack;
    [SerializeField] public GameObject projectile;
    [SerializeField] public Transform firePoint;
    [SerializeField] private float lastShot;
    [SerializeField] private float fireRate;
    [SerializeField] private PlayerScript playerBody;
    [SerializeField] private float speed;
    private bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            
        }
    }

    public void Shoot()
    {
        if (Time.time > fireRate + lastShot)
        {
            GameObject firedProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = firedProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * speed, ForceMode2D.Impulse);
            lastShot = Time.time;
            Play_Playerrangeattack.Post(gameObject);
        }
    }
}
