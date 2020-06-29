using UnityEngine;  
 using System.Collections;  
 using UnityEngine.EventSystems;  
 using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsMenu,menu;
    public GameObject  creditsBackSelected, creditsClosed;

    public void OpenCredits() 
    {
        creditsMenu.SetActive(true);
        menu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsBackSelected);

    }
    public void CloseCredits()
    {
        creditsMenu.SetActive(false);
        menu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsClosed);
    }
        public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void CheckPoint1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void CheckPoint2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    public void CheckPoint3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
