using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string NomScn;
    public string NomScn1;
    public string NomScn2;


    public void PlayGame()
    {
        Debug.Log("Partie Lancer ");
        SceneManager.LoadScene(NomScn);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }
    public void RegleGame()
    {
        Debug.Log("Regle du jeux ");
        SceneManager.LoadScene(NomScn1);

    }
    public void RetourGame()
    {
        Debug.Log("Retour au menu ");
        SceneManager.LoadScene(NomScn2);
    }
}


