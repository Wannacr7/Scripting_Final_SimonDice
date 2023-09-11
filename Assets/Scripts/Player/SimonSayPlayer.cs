
using Core;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Player
{
    public class SimonSayPlayer : MonoBehaviour
    {

        //Verifica secuencia
        [SerializeField] private GameManager main;
        [SerializeField] private int sequenceLenght;

        private bool playerCanPress = false;


        private EColors colorON;



        // Start is called before the first frame update
        void Start()
        {
            sequenceLenght = 0;
        }
   

        private void Update()
        {
            if (main.StartPlayer)
            {
                GetPlayerNum(main.StartPlayer);

            }
        }



        private void GetPlayerNum(bool _press)
        {
            playerCanPress = _press;
            if (playerCanPress)
            {
                if (Input.GetKeyDown((KeyCode.Q)))
                {
                    ColorsGestor.instance.ChangeColor(EColors.Yellow);
                    Debug.Log("");
                    CanContinue();
                    playerCanPress=false;

                }
                if (Input.GetKeyDown((KeyCode.W)))
                {
                    ColorsGestor.instance.ChangeColor(EColors.Red);
                    CanContinue();
                    playerCanPress =false;   
                }
                if (Input.GetKeyDown((KeyCode.A)))
                {
                    ColorsGestor.instance.ChangeColor(EColors.Green);
                    CanContinue();
                    playerCanPress=false;
                }
                if (Input.GetKeyDown((KeyCode.S)))
                {
                    colorON = EColors.Blue;
                    CanContinue();
                    playerCanPress=false;
                }
                if (Input.GetKeyDown((KeyCode.D)))
                {
                    ColorsGestor.instance.ChangeColor(EColors.Purple);
                    CanContinue();
                    playerCanPress=false;
                }
            }



        }

        private void CanContinue()
        {
            int typeColor = (int)colorON;

            Debug.Log((int)colorON + "  " + main.MachineArray[sequenceLenght]);
            if (typeColor == main.MachineArray[sequenceLenght])
            {
                sequenceLenght++;
                
                if (sequenceLenght == main.MachineArray.Count)
                {
                    main.Level++;
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
            main.On_Enable_Machine?.Invoke(true);
        }
    }
}

