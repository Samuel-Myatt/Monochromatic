using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject backgrounds;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        backgrounds = GameObject.Find("BackgroundManager");
        if (backgrounds.GetComponent<BackGroundScript>().black != true)
		{
            sr.color = Color.black;
		}
        Destroy(this.gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        if (backgrounds.GetComponent<BackGroundScript>().black != true)
        {
            sr.color = Color.black;
        }
        else
		{
            sr.color = Color.white;
        }
    }

	/*private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Enemy")
		{
            Destroy(this.gameObject);
		}
	}*/
}
