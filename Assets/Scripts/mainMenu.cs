using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

   private SFXManager sfxMan;

    // Use this for initialization
    void Start()
    {
        //Função para carregar os efeitos de som do script sfxmanager
        sfxMan = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void jogar()
    {
        Debug.Log("play");
        SceneManager.LoadScene("Level1");
       sfxMan.play.Play();

    }

    public void settings()
    {
        Debug.Log("settings");
        SceneManager.LoadScene("settings");

        sfxMan.click.Play();

    }

    public void jogarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
       sfxMan.click.Play();

    }

    public void backmenu()
    {
        Debug.Log("menu");
        SceneManager.LoadScene("menu");
        sfxMan.click.Play();
    }

    public void backlevel()
    {
        Debug.Log("backlevel");
        SceneManager.LoadScene("levels");
        sfxMan.click.Play();
    }

    public void level1()
    {
        Debug.Log("level1");
        SceneManager.LoadScene("level1");
        sfxMan.play.Play();
    }

    public void level2()
    {
        Debug.Log("level2");
        SceneManager.LoadScene("level2");
        sfxMan.play.Play();
    }

    public void level3()
    {
        Debug.Log("level3");
        SceneManager.LoadScene("level3");
        sfxMan.play.Play();
    }

    public void proxlevel()
    {
        Debug.Log("proxlevel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        sfxMan.play.Play();
    }

    public void creditos()
    {
        Debug.Log("creditos");
        SceneManager.LoadScene("creditos");
       sfxMan.click.Play();

    }

    public void sair()
    {
        Debug.Log("sair");
        Application.Quit();
        sfxMan.click.Play();

    }



}
