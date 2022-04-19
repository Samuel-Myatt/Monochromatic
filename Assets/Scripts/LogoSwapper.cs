using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    int timer = 0;
    bool temp = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        if(timer == 50)
		{
            if(temp)
			{
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                temp = false;
            }
            else
			{
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
                temp = true;
            }
            timer = 0;
            
		}
    }
}
