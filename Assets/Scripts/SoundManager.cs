using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Shoot, Death, Swap;
    static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        Shoot = Resources.Load<AudioClip>("Shoot");
        Death = Resources.Load<AudioClip>("Death");
        Swap = Resources.Load<AudioClip>("Chose sound");
        

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            
            case "Shoot":
                audioSrc.PlayOneShot(Shoot);
                break;
            case "Death":
                audioSrc.PlayOneShot(Death);
                break;
            case "Swap":
                audioSrc.PlayOneShot(Swap);
                break;
            
        }
    }
}
