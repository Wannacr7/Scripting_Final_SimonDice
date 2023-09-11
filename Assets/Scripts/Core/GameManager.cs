using IA;
using UI;
using UnityEngine;
using System;
using System.Collections.Generic;

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


        public Action<bool> On_Enable_Machine;
        public static Action On_Enable_Player;
        private bool startMachine = false;
        [SerializeField] private bool startPlayer;
        [SerializeField] private List<int> machineArray;

        private float timeChangeColor = 1f;
        private float timer = 0;
        private float lerpRatio;

        [SerializeField] private int level = 0;
        [SerializeField] private int levelCounter;
        [SerializeField] public int difficulty = 0;

        public List<int> MachineArray { get => machineArray; }
        public int Level { get => level; set => level = value; }
        public bool StartPlayer { get => startPlayer; set => startPlayer = value; }
        public bool StartMachine { get => startMachine; set => startMachine = value; }

        void Start()
        {
            levelCounter = 0;
        }
        private void OnEnable()
        {
            On_Enable_Machine += MachineStarted;
            On_Enable_Player += PlayerStarted;
            ColorsGestor.onFinishAnim += StatesManager;
        }
        private void OnDisable()
        {
            On_Enable_Machine -= MachineStarted;
            On_Enable_Player -= PlayerStarted;
            ColorsGestor.onFinishAnim -= StatesManager;
        }


        private void SetMachineColor()
        {
            if (startMachine)
            {
                if (levelCounter < level) levelCounter++;
                else
                {
                    startMachine = false;
                    levelCounter = 0;
                }

                _typecolor = (EColors)machineArray[levelCounter];
                Debug.Log("MACHINE: " + _typecolor);
                ColorsGestor.instance.ChangeColor(_typecolor);
                //startPlayer = true;

            }


        }
        private void StatesManager()
        {
            if (StartMachine) MachineStarted(StartMachine);
            else PlayerStarted();
        }
        private void PlayerStarted()
        {
            Debug.Log("Player started");
            StartPlayer = true;
            
        }

        private void MachineStarted(bool _event)
        {
            machineArray = SimonSayMachine.instance.GenerateArray(level + 1, difficulty);
            StartMachine = _event;
            StartPlayer = false;
            SetMachineColor();
        }


    }


}
