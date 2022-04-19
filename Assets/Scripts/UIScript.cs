using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIScript : MonoBehaviour
{

    public int score = 0;

    public int roundCount = 1;

    public TextMeshProUGUI text;
    public TextMeshProUGUI textRound;

    public GameObject backgrounds;

    public int level = 1;

    public GameObject EnemySpawner;

    public bool paused = false;

    public GameObject PauseMenuWhite;
    public GameObject PauseMenuBlack;

    public GameObject currentPause;

    public GameObject DeathMenuWhite;
    public GameObject DeathMenuBlack;

    public GameObject currentDeath;

    public GameObject player;

    public AudioSource music;
    public AudioSource effects;

    public Slider effectsSlider;
    public Slider musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score: " + score.ToString();
        textRound.text = "Round: " + roundCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
            Pause();
		}
    }

    public void IncreaseScore()
	{
        score += 10;
        if((score > level * 100) && (level < 6))
		{
            EnemySpawner.GetComponent<EnemySpawnerScript>().delay -= 10;
            level++;
		}
        text.text = "Score: " + score.ToString();

    }

    public void IncreaseRound()
	{
        roundCount++;
        textRound.text = "Round: " + roundCount.ToString();
    }

    public void Pause()
	{
        if (paused)
        {
            currentPause.active = false;
            paused = false;
            Time.timeScale = 1f;
        }
        else
		{
            Time.timeScale = 0f;
            currentPause.active = true;
            paused = true;
        }
	}
    public void ChangeColour(int i)
	{
        if(i == 1)
		{
            text.color = Color.white;
            textRound.color = Color.white;
            currentPause = PauseMenuBlack;
            currentDeath = DeathMenuBlack;
            effectsSlider = currentPause.transform.GetChild(4).gameObject.GetComponent<Slider>();
            musicSlider = currentPause.transform.GetChild(7).gameObject.GetComponent<Slider>();
            musicSlider.value = music.volume;
            effectsSlider.value = effects.volume;
		}
        else
		{
            text.color = Color.black;
            textRound.color = Color.black;
            currentPause = PauseMenuWhite;
            currentDeath = DeathMenuWhite;
            effectsSlider = currentPause.transform.GetChild(4).gameObject.GetComponent<Slider>();
            musicSlider = currentPause.transform.GetChild(7).gameObject.GetComponent<Slider>();
            musicSlider.value = music.volume;
            effectsSlider.value = effects.volume;
        }
	}

    public void Retry()
	{
        Application.LoadLevel(Application.loadedLevel);
    }
    public void EndScore()
	{

        currentDeath.active = true;
        currentDeath.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = "You Scored " + score.ToString();
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void updateVolumeEffects()
    {
        effects.volume = effectsSlider.value;
    }
    public void updateVolumeMusic()
    {
        music.volume = musicSlider.value;
    }

    public void ReduceSwapCoolDown()
	{
        player.GetComponent<PlayerController>().delayMax -= 0.1f;
        EnemySpawner.GetComponent<EnemySpawnerScript>().ResetRound();
    }

    public void IncreaseSwapSpeed()
	{
        backgrounds.GetComponent<BackGroundScript>().speed -= 0.1f;
        EnemySpawner.GetComponent<EnemySpawnerScript>().ResetRound();
	}

    public void Restart()
	{
        Application.LoadLevel(Application.loadedLevel);
    }
}
