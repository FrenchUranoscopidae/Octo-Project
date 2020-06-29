using UnityEngine;  
 using System.Collections;  
 using UnityEngine.EventSystems;  
 using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public void Start()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
