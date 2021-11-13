using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using TMPro;

public class IUController : MonoBehaviour
{
    [SerializeField] private GameObject Colores;
    [SerializeField] private GameObject CoverLayer1;
    [SerializeField] private GameObject CoverLayer2;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject StartButtom;
    [SerializeField] private GameObject pauseButtom;
    [SerializeField] public TMP_Text[] stateOfGame;

    [SerializeField] private GameObject TitleScreen;
    [SerializeField] private GameObject DifficultyScreen;
    [SerializeField] private GameObject PauseScreen;

    [SerializeField] AudioSource menuMusic;

    [SerializeField] GameObject backgroundNormal;
    [SerializeField] GameObject backgroundMedium;
    [SerializeField] GameObject backgroundHard;

    [SerializeField] GameManager state;

    private bool IsPaused = false;

    private void Start()
    {
        menuMusic.Play();
        

    }
    private void Update()
    {
        ChangeState();
    }
    private void ChangeState()
    {
        if (state.StartMachine)
        {
            stateOfGame[0].text = "Maquina";
            stateOfGame[1].text = "Maquina";
        }
        else
        {
            stateOfGame[0].text = "Jugador";
            stateOfGame[1].text = "Jugador";
        }
    }

    public void testevent()
    {
        if (gameManager.On_Enable_Machine != null)
        {
            gameManager.On_Enable_Machine(true);
        }
        StartButtom.SetActive(false);
        stateOfGame[0].gameObject.SetActive(true);

        pauseButtom.SetActive(true);
    }

    public void PressPlay()
    {
        TitleScreen.SetActive(false);
        DifficultyScreen.SetActive(true);
    }
    public void ChooseDifficulty()
    {
        DifficultyScreen.SetActive(false);
        Colores.SetActive(true);
        StartButtom.SetActive(true);
    }
    public void HardMode()
    {
        gameManager.difficulty = 5;
        backgroundNormal.SetActive(false);
        backgroundHard.SetActive(true);
        
    }
    public void MediumMode()
    {
        gameManager.difficulty = 4;
        CoverLayer2.SetActive(true);
        backgroundMedium.SetActive(true);
        backgroundNormal.SetActive(false);
    }
    public void EasyMode()
    {
        gameManager.difficulty = 2;
        CoverLayer1.SetActive(true);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PauseButton()
    {
        if (IsPaused)
        {
            Time.timeScale = 1;
            IsPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            IsPaused = true;
        }
    }

}
