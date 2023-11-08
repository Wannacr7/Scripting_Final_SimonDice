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

        

        [SerializeField] private GameObject StartButtom;
        [SerializeField] private GameObject pauseButtom;
        [SerializeField] public TMP_Text stateOfGame;
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




        public void StartGame()
        {
            StartButtom.SetActive(false);
            stateOfGame.gameObject.SetActive(true);
            score.gameObject.SetActive(true);
            pauseButtom.SetActive(true);
            GameManager.On_Enable_Machine?.Invoke();
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
            GameManager.On_Set_Difficult?.Invoke(5);

        }
        public void MediumMode()
        {
            GameManager.On_Set_Difficult?.Invoke(4);
        }
        public void EasyMode()
        {
            GameManager.On_Set_Difficult?.Invoke(2);
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
