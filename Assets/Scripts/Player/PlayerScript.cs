using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private float speed = 10;

    private Rigidbody2D plRigid;
    private Pivot pivot;
    private float angle;
    private float hAxis, vAxis;

    //dash
    [Header("Dash")]
    [SerializeField] private float dashingPower = 9.0f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1.0f;
    [SerializeField] private float dashingDamage = 5.0f;
    private bool canDash = true;
    private bool isDashing;


    // Start is called before the first frame update
    void Start()
    {
        plRigid = GetComponent<Rigidbody2D>();
        pivot = gameObject.GetComponentInChildren(typeof(Pivot)) as Pivot;
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Rotation();
    }

    void Movement()
    {
        if (isDashing) { return; }


        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(hAxis, vAxis);
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void Rotation()
    {
        Vector3 pointPos = (Input.mousePosition);
        pointPos = Camera.main.ScreenToWorldPoint(pointPos);

        Vector3 target = pointPos - transform.position;
        target.Normalize();
        angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        if (angle > 130 && angle < 179)
        {
            //playerSprite.flipX = true;
        }
        else if (angle > -179 && angle < -130)
        {
            // playerSprite.flipX = true;
        }
        else
        {
            // playerSprite.flipX = false;
        }

        pivot.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float orgGravity = plRigid.gravityScale;
        plRigid.gravityScale = 0f;

        plRigid.velocity = new Vector2(pivot.transform.right.x * dashingPower, pivot.transform.right.y * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        plRigid.gravityScale = orgGravity;
        isDashing = false;
        plRigid.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            if (isDashing)
            {
                collision.gameObject.GetComponent<Mob>().Damaged(dashingDamage);
            }
        }
    }
}
