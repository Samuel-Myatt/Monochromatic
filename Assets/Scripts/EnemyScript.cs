using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    float storedspeed;
    float halfspeed;
    public GameObject target;

    public SpriteRenderer sr;

    public GameObject UI;

    public GameObject player;

    float colour;

    public GameObject SoundEffects;

    public GameObject EnemySpawner;

    public bool EnemyPlus;
    public bool hitOnce;
    void Start()
    {
        
        EnemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        SoundEffects = GameObject.FindGameObjectWithTag("Effects");
        colour = Random.Range(0.0f,2.0f);
        speed = EnemySpawner.GetComponent<EnemySpawnerScript>().enemySpeed;
        storedspeed = speed;
        halfspeed = speed / 3;
        player = GameObject.FindWithTag("Player");
        UI = GameObject.FindWithTag("UI");

        
        target = GameObject.FindWithTag("Player");

        if(colour > 1.0f)
		{
            sr.color = Color.black;
		}
        else
		{
            sr.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        DistanceCheck();
    }

    void DistanceCheck()
	{
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist < 2)
		{
            sr.color = Color.grey;
            speed = halfspeed;
		}
        else
		{
            if(colour > 1.0f)
			{
                sr.color = Color.black;
            }
            else
			{
                sr.color = Color.white;
            }
            speed = storedspeed;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Bullet")
		{
			GameObject backgrounds = GameObject.Find("BackgroundManager");
			if ((colour > 1.0f) && (backgrounds.GetComponent<BackGroundScript>().black != true))
			{
				if (EnemyPlus)
				{
					if (!hitOnce)
					{
						if (colour > 1.0f)
						{
							colour = 0.9f;
							sr.color = Color.white;
						}
						else
						{
							colour = 1.1f;
							sr.color = Color.black;
						}
						SoundEffects.GetComponent<SoundManager>().PlaySound("Death");
						hitOnce = true;
					}
					else
					{
						Die(collision);
					}
				}
				else
				{
					Die(collision);
				}
			}
			if ((colour < 1.0f) && (backgrounds.GetComponent<BackGroundScript>().black == true))
			{
				if (EnemyPlus)
				{
					if (!hitOnce)
					{
						if (colour > 1.0f)
						{
							colour = 0.9f;
							sr.color = Color.white;
						}
						else
						{
							colour = 1.1f;
							sr.color = Color.black;
						}
						SoundEffects.GetComponent<SoundManager>().PlaySound("Death");
						hitOnce = true;
					}
					else
					{
						Die(collision);
					}
				}
				else
				{
					Die(collision);
				}
			}
		}
	}

	void Die(Collider2D collision)
	{
        UI.GetComponent<UIScript>().IncreaseScore();
        SoundEffects.GetComponent<SoundManager>().PlaySound("Death");
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        EnemySpawner.GetComponent<EnemySpawnerScript>().enemiesActive--;
    }
}
