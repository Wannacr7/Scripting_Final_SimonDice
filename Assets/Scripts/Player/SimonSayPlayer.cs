
using Core;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Player
{
    public class SimonSayPlayer : MonoBehaviour
    {


        private int sequenceLenght;
        private bool playerCanPress;
        private bool isPlayerTurn;
        private List<int> sequenceToFollow;
        private EColors colorON;



        // Start is called before the first frame update
        void Start()
        {
            sequenceLenght = 0;
            playerCanPress = false;
            isPlayerTurn = false;
        }
        private void Update()
        {
            if (playerCanPress)
            {
                GetPlayerNum();

            }
        }
        private void OnEnable()
        {
            ColorsGestor.onFinishAnim += ActivateButtons;
        }
        private void OnDisable()
        {
            ColorsGestor.onFinishAnim -= ActivateButtons;
        }
        public void SetPlayerTurn(List<int> _sequenceToFollow, bool _isPlayerTurn = true)
        {
            sequenceToFollow = _sequenceToFollow;
            isPlayerTurn= _isPlayerTurn;
            playerCanPress = true;
        }
        private void ActivateButtons()
        {
            if(isPlayerTurn)playerCanPress = true;
        }
        private void GetPlayerNum()
        {
            
            if (playerCanPress)
            {
                if (Input.GetKeyDown((KeyCode.Q)))
                {
                    playerCanPress = false;
                    Debug.Log("Q");
                    ColorsGestor.instance.ChangeColor(EColors.Yellow);
                    colorON = EColors.Yellow;
                    CanContinue();
                    

                }
                if (Input.GetKeyDown((KeyCode.W)))
                {
                    playerCanPress = false;
                    Debug.Log("W");
                    ColorsGestor.instance.ChangeColor(EColors.Red);
                    colorON = EColors.Red;
                    CanContinue();
                      
                }
                if (Input.GetKeyDown((KeyCode.A)))
                {
                    playerCanPress = false;
                    Debug.Log("A");
                    ColorsGestor.instance.ChangeColor(EColors.Green);
                    colorON = EColors.Green;
                    CanContinue();
                    
                }
                if (Input.GetKeyDown((KeyCode.S)))
                {
                    playerCanPress = false;
                    Debug.Log("S");
                    ColorsGestor.instance.ChangeColor(EColors.Blue);
                    colorON = EColors.Blue;
                    CanContinue();
                    
                }
                if (Input.GetKeyDown((KeyCode.D)))
                {
                    playerCanPress = false;
                    Debug.Log("D");
                    ColorsGestor.instance.ChangeColor(EColors.Purple);
                    colorON = EColors.Purple;
                    CanContinue();
                    
                }
            }



        }
        private void CanContinue()
        {
            int typeColor = (int)colorON;

            Debug.Log((int)colorON + "  " + sequenceToFollow[sequenceLenght]);
            if (typeColor == sequenceToFollow[sequenceLenght])
            {
                sequenceLenght++;
                if (sequenceLenght == sequenceToFollow.Count)
                {
                    
                    CallMachine();
                    
                }
                

            }
            else
            {
                SceneManager.LoadScene("3DTest");
            }
            
        }
        private void CallMachine()
        {
            sequenceLenght = 0;
            playerCanPress = false;
            isPlayerTurn = false;
            GameManager.On_Enable_Machine?.Invoke();
        }
    }
}

