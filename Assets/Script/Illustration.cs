using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Illustration : MonoBehaviour
{
    public Image page1;
    public Image page2;
    public Image page3;
    public Image page4;

    public Button B1;
    public Button B2;
    public Button B3;
    public Button B4;

    public string Jeux;


   
    void Start()
    {
        page1.gameObject.SetActive(true);
        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(false);
        page4.gameObject.SetActive(false);

        B1.gameObject.SetActive(true);
        B2.gameObject.SetActive(false);
        B3.gameObject.SetActive(false);
        B4.gameObject.SetActive(false);
    }
    public void Page1A2()
    {
        page1.gameObject.SetActive(false);
        page2.gameObject.SetActive(true);
        page3.gameObject.SetActive(false);
        page4.gameObject.SetActive(false);

        B1.gameObject.SetActive(false);
        B2.gameObject.SetActive(true);
        B3.gameObject.SetActive(false);
        B4.gameObject.SetActive(false);
    }
    public void Page2A3()
    {
        page1.gameObject.SetActive(false);
        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(true);
        page4.gameObject.SetActive(false);

        B1.gameObject.SetActive(false);
        B2.gameObject.SetActive(false);
        B3.gameObject.SetActive(true);
        B4.gameObject.SetActive(false);
    }
    public void Page3A4()
    {
        page1.gameObject.SetActive(false);
        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(false);
        page4.gameObject.SetActive(true);

        B1.gameObject.SetActive(false);
        B2.gameObject.SetActive(false);
        B3.gameObject.SetActive(false);
        B4.gameObject.SetActive(true);
    }
    public void FinIllustration()
    {
        Debug.Log("Le jeux commence"); 
        SceneManager.LoadScene(Jeux);
    }

    
}
