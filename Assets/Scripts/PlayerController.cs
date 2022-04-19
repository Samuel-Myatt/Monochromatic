using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //MOVEMENT VARIABLES
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    //CAMERA/MOUSEPOS VARIABLES
    public Camera cam;
    Vector2 mousePos;

    //BULLET VARIABLES
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    //BLACK AND WHITE VARIABLES
    bool black = false;
    public SpriteRenderer sr;
    public GameObject backgrounds;
    float delayCurrent = 0;
    public float delayMax;

    private Shake shake;

    public GameObject SoundEffects;

    public GameObject UI;

   

    private void FixedUpdate()
	{
        Move();
        delayCurrent -= Time.deltaTime;
	}
    void Update()
    {
        ProcessInputs();
    }
    void ProcessInputs()
	{
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && UI.GetComponent<UIScript>().paused == false)
		{
            Shoot();
		}

        if (Input.GetKeyDown(KeyCode.Space) && UI.GetComponent<UIScript>().paused == false && delayCurrent <= 0)
		{
            SwapColours();
		}
	}
	void Move()
	{
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90.0f;
        rb.rotation = angle;
	}
    void Shoot()
	{
        SoundEffects.GetComponent<SoundManager>().PlaySound("Shoot");
        shake.CamShake();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();
        rbB.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.tag == "Enemy")
		{
            UI.GetComponent<UIScript>().EndScore();
            SoundEffects.GetComponent<SoundManager>().PlaySound("Death");
            Destroy(this.gameObject);
        }
        
	}



    public void SwapColours()
	{
        delayCurrent = delayMax;
        if(black)
		{
            SoundEffects.GetComponent<SoundManager>().PlaySound("Swap");
            backgrounds.GetComponent<BackGroundScript>().SwapBackgrounds();
            sr.color = Color.white;
            black = false;
        }
		else 
        {
            SoundEffects.GetComponent<SoundManager>().PlaySound("Swap");
            backgrounds.GetComponent<BackGroundScript>().SwapBackgrounds();
            sr.color = Color.black;
            black = true;
        }
	}

	private void Start()
	{
        UI = GameObject.FindWithTag("UI");
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        SoundEffects = GameObject.FindGameObjectWithTag("Effects");
	}

   

}
