using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
       
        SceneManager.LoadScene(1);
        
    }

    public void Credits()
	{
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        Camera.main.GetComponent<Camera>().backgroundColor = Color.white;

    }

    public void QuitGame()
	{
        Application.Quit();
    }

    public void Back()
	{
        Camera.main.GetComponent<Camera>().backgroundColor = Color.black;
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
    }

}
