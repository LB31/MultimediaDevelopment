using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {
    public GameObject menu;
    public bool menuTrigger = false;
    public bool returnPressed = false;

    // Use this for initialization
    void Start () {
        menu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || returnPressed)
        {
            returnPressed = false;
            menuTrigger = !menuTrigger;
            menu.SetActive(menuTrigger);
            if (menuTrigger)
            {
                Time.timeScale = 0f;
            }
            else{
                Time.timeScale = 1f;
            }
        }
          
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void returnToGame()
    {
        returnPressed = true;
    }


}
