using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using TMPro;
using Core;

namespace UI
{
    public class IUController : MonoBehaviour
    {
        //[SerializeField] private GameObject Colores;
        //[SerializeField] private GameObject CoverLayer1;
        //[SerializeField] private GameObject CoverLayer2;

        [SerializeField] private GameManager gameManager;

        [SerializeField] private GameObject StartButtom;
        [SerializeField] private GameObject pauseButtom;
        [SerializeField] public TMP_Text[] stateOfGame;
        [SerializeField] public TMP_Text score;

        [SerializeField] private GameObject TitleScreen;
        [SerializeField] private GameObject DifficultyScreen;
        //[SerializeField] private GameObject PauseScreen;

        //[SerializeField] AudioSource menuMusic;

        //[SerializeField] GameObject backgroundNormal;
        //[SerializeField] GameObject backgroundMedium;
        //[SerializeField] GameObject backgroundHard;

        [SerializeField] GameManager state;

        private bool IsPaused = false;


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
                score.text = "0" + (state.MachineArray.Count - 1).ToString();
            }
            else
            {
                stateOfGame[0].text = "Jugador";
                stateOfGame[1].text = "Jugador";

            }
        }

        public void testevent()
        {
            gameManager.On_Enable_Machine?.Invoke();
            StartButtom.SetActive(false);
            stateOfGame[0].gameObject.SetActive(true);
            score.gameObject.SetActive(true);
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
            StartButtom.SetActive(true);
        }
        public void HardMode()
        {
            gameManager.difficulty = 5;
        }
        public void MediumMode()
        {
            gameManager.difficulty = 4;
        }
        public void EasyMode()
        {
            gameManager.difficulty = 2;
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

}
