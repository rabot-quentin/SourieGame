using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Illustration;
    


    public void PlayGame()
    {
        Debug.Log("Partie Lancer ");
        SceneManager.LoadScene(Illustration);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }
    
    
}


