using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private float speed = 10;
    [SerializeField] private SpriteRenderer plSprite;
    [SerializeField] private Animator plAnim;
    private const float shieldSpeed = 3.0f;
    private Rigidbody2D plRigid;
    private Pivot pivot;
    private float angle;
    private float hAxis, vAxis;
    private bool isFacingRight;
    private bool playerEnabled;
    //dash
    [Header("Dash")]
    [SerializeField] private float dashingPower = 9.0f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1.0f;
    [SerializeField] private float dashingDamage = 5.0f;
    private bool canDash = true;
    private bool isDashing;

    [Header("Weapon")]
    [SerializeField] private GameObject Shield;
    private bool shieldSwitch = false;


    // Start is called before the first frame update
    void Start()
    {
        playerEnabled = true;
        plRigid = GetComponent<Rigidbody2D>();
        pivot = gameObject.GetComponentInChildren(typeof(Pivot)) as Pivot;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerEnabled == false)
        {
            return;
        }
        Movement();
        Rotation();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (shieldSwitch == true)
            {
                shieldSwitch = false;
                ShieldSwitch();
                speed = 3.0f;
            }
            else
            {
                shieldSwitch = true;
                ShieldSwitch();

                speed = 6.0f;
            }
        }
        CycleAnim();

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

        plAnim.SetFloat("Speed", (Mathf.Abs(hAxis) + Mathf.Abs(vAxis)));
    }

    void Rotation()
    {
        Vector3 pointPos = (Input.mousePosition);
        pointPos = Camera.main.ScreenToWorldPoint(pointPos);

        Vector3 target = pointPos - transform.position;
        target.Normalize();
        angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;


        if (angle > 109 && angle < 179)
        {
            plSprite.flipX = true;
        }
        else if (angle > -179 && angle < -109)
        {
            plSprite.flipX = true;
        }
        else
        {
            plSprite.flipX = false;
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

    void ShieldSwitch()
    {
        if (shieldSwitch == true)
        {
            Shield.SetActive(false);
        }
        else
        {
            Shield.SetActive(true);
        }

    }

    private void Flip()
    {
        if (isFacingRight && hAxis < 0f || !isFacingRight && hAxis > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void CycleAnim()
    {
        if (angle > 68 && angle < 109)
        {
            plAnim.SetInteger("Index", 1);
        }
        else if (angle > 20 && angle < 69 || angle < 175 && angle > 109)
        {
            plAnim.SetInteger("Index", 2);
        }
        else if (angle > -35 && angle < 21 || angle < -150 || angle > 175)
        {
            plAnim.SetInteger("Index", 3);
        }
        else if (angle > -69 && angle < -35 || angle > -150 && angle < -109)
        {
            plAnim.SetInteger("Index", 4);
        }
        else if (angle > -109 && angle < -69)
        {
            plAnim.SetInteger("Index", 5);
        }
    }

    public void SetPlayerEnabled(bool change)
    {
        playerEnabled = change;
    }
}
