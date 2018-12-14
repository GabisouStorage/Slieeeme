using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool Pausado = false;

    //COLOCAR O GAMEOBJECT PAUSEMENU COM OS BUTOES DENTRO DE RESUME E QUIT NA OPÇÃO DO SCRIPT NO UNITY
    //O SCRIPT DEVE SER COLOCADO NO CANVAS DO MENU DE PAUSE
    public GameObject pauseMenu;
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausado)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
		
	}
    // Funções que pausam o game a partir do recebimento do valor 0 ou 1 para o timescale; associar o resume ao On Click para ativar o butão de resume
    void Resume ()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Pausado = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Pausado = true;
    }

    //Função para sair do jogo ao pressionar o butão quit; associar este ao On Click de Quit
    public void QuitGame()
    {
        Application.Quit();
    }

}
