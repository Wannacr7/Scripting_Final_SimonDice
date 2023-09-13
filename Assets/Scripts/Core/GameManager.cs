using IA;
using UI;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Core
{
    public enum EColors
    {
        Red = 0,
        Yellow = 1,
        Blue = 2,
        Green = 3,
        Purple = 4,
        Null
    }
    public class GameManager : MonoBehaviour
    {
        private EColors _typecolor;


        public Action On_Enable_Machine;
        public static Action On_Enable_Player;
        private bool startMachine = false;
        [SerializeField] private bool startPlayer;
        [SerializeField] private List<int> machineArray;



        [SerializeField] private int level = 0;

        [SerializeField] public int difficulty = 0;

        public List<int> MachineArray { get => machineArray; }
        public int Level { get => level; set => level = value; }
        public bool StartPlayer { get => startPlayer; set => startPlayer = value; }
        public bool StartMachine { get => startMachine; set => startMachine = value; }

        private void Start()
        {
            StartMachine = true;
            StartPlayer = false;
        }

        private void OnEnable()
        {
            //On_Enable_Machine += MachineStarted;
            On_Enable_Player += PlayerStarted;
            ColorsGestor.onFinishAnim += StatesManager;
        }
        private void OnDisable()
        {
            //On_Enable_Machine -= MachineStarted;
            On_Enable_Player -= PlayerStarted;
            ColorsGestor.onFinishAnim -= StatesManager;
        }


        private IEnumerator SetMachineColor()
        {
            if (startMachine)
            {
                for (int i = 0; i < machineArray.Count-1; i++)
                {
                    yield return new WaitForSeconds(2);
                    _typecolor = (EColors)machineArray[i];
                    Debug.Log("MACHINE: " + _typecolor);
                    ColorsGestor.instance.ChangeColor(_typecolor);
                    //startPlayer = true;
                    
                }
                startMachine = false;

            }

            yield return null;
        }
        private void StatesManager()
        {
            //if (!StartMachine) MachineStarted();
            //else PlayerStarted();
        }
        private void PlayerStarted()
        {
            Debug.Log("Player started");
            StartPlayer = true;

        }

        /*private void MachineStarted()
        {
            machineArray = SimonSayMachine.instance.GenerateArray(level + 1, difficulty);

            StartCoroutine(SetMachineColor());
            StartMachine = false;
            StartPlayer = true;
        }*/


    }


}
