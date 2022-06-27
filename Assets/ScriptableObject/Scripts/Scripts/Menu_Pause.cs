using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Pause : MonoBehaviour
{
    public static bool GameIsPaused=false;
    public GameObject pauseMenuUI;
    public Animator Abrir_fechar;
    public string ativanim;

    public GameObject Botan;

    //For using GameIsPaused in others scripts use:
    //if (PauseMenu.GameIsPaused){}

    void update() {

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused==false){
                Pause();
            }else{
                Resume();
            }

        }
    }
    //Função que Resume o jogo, é usada no botão
    public void Resume()
    {
       
        Time.timeScale = 1f;
        GameIsPaused = false;
        Botan.SetActive(true);
    }

    //Função que Pausa o jogo
    public void Pause()
    {
        Abrir_fechar.SetTrigger(ativanim);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Botan.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    
}
