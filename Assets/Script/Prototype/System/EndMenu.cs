using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EndMenu: MonoBehaviour
{
    public GameObject finalDoor;
    public GameObject endMenu;
    public GameObject firstButton;

    public void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            endMenu.SetActive(true);
            Time.timeScale = 0;

            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }       
}
