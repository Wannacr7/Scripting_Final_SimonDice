
using Core;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Player
{
    public class SimonSayPlayer : MonoBehaviour
    {


        [SerializeField] private int sequenceLenght;

        private bool playerCanPress = true;


        private EColors colorON;



        // Start is called before the first frame update
        void Start()
        {
            sequenceLenght = 0;
        }
   

        private void Update()
        {
            if (playerCanPress)
            {
                GetPlayerNum(playerCanPress);

            }
        }



        private void GetPlayerNum(bool _press)
        {
            playerCanPress = _press;
            if (playerCanPress)
            {
                if (Input.GetKeyDown((KeyCode.Q)))
                {
                    Debug.Log("Q");
                    ColorsGestor.instance.ChangeColor(EColors.Yellow);
                    CanContinue();
                    //playerCanPress=false;

                }
                if (Input.GetKeyDown((KeyCode.W)))
                {
                    Debug.Log("W");
                    ColorsGestor.instance.ChangeColor(EColors.Red);
                    CanContinue();
                    //playerCanPress =false;   
                }
                if (Input.GetKeyDown((KeyCode.A)))
                {
                    Debug.Log("A");
                    ColorsGestor.instance.ChangeColor(EColors.Green);
                    CanContinue();
                    //playerCanPress=false;
                }
                if (Input.GetKeyDown((KeyCode.S)))
                {
                    Debug.Log("S");
                    ColorsGestor.instance.ChangeColor(EColors.Blue);
                    CanContinue();
                    //playerCanPress=false;
                }
                if (Input.GetKeyDown((KeyCode.D)))
                {
                    Debug.Log("D");
                    ColorsGestor.instance.ChangeColor(EColors.Purple);
                    CanContinue();
                   // playerCanPress=false;
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
            main.StartMachine = true;
        }
    }
}

