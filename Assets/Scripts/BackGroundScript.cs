using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    public GameObject player;
    GameObject WhiteBackground;
    GameObject BlackBackground;
    public bool black = true;
    public float speed = 5;
    public GameObject UI;
    public GameObject EnemySpawner;

    int size = 1000;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindWithTag("UI");
        WhiteBackground = this.gameObject.transform.GetChild(0).gameObject;
        BlackBackground = this.gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IncramentSize();
    }

    public void SwapBackgrounds()
	{
        SpriteRenderer sr;
        if (black)
		{
            sr = WhiteBackground.GetComponent<SpriteRenderer>();
            sr.sortingOrder = -1;
            sr = BlackBackground.GetComponent<SpriteRenderer>();
            sr.sortingOrder = -2;
            WhiteBackground.transform.position = player.transform.position;
            size = 1;
            WhiteBackground.transform.localScale = new Vector3(size / speed, size / speed, 1);
            BlackBackground.transform.localScale = new Vector3(1000, 1000, 1);
            black = false;
            UI.GetComponent<UIScript>().ChangeColour(2);
            EnemySpawner.GetComponent<EnemySpawnerScript>().menuCurrent = EnemySpawner.GetComponent<EnemySpawnerScript>().menuBlack;

        }
        else
		{
            sr = BlackBackground.GetComponent<SpriteRenderer>();
            sr.sortingOrder = -1;
            sr = WhiteBackground.GetComponent<SpriteRenderer>();
            sr.sortingOrder = -2;
            BlackBackground.transform.position = player.transform.position;
            size = 1;
            BlackBackground.transform.localScale = new Vector3(size / speed, size / speed, 1);
            WhiteBackground.transform.localScale = new Vector3(1000, 1000, 1);
            black = true;
            UI.GetComponent<UIScript>().ChangeColour(1);
            EnemySpawner.GetComponent<EnemySpawnerScript>().menuCurrent = EnemySpawner.GetComponent<EnemySpawnerScript>().menuWhite;
        }
	}

    public void IncramentSize()
	{
        if(size < 1000)
		{
            size++;
		}
        if(black)
		{
            BlackBackground.transform.localScale = new Vector3(size / speed, size / speed, 1);
        }
        else
		{
            WhiteBackground.transform.localScale = new Vector3(size / speed, size / speed, 1);
        }
        
	}
}
