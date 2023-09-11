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
        public bool StartMachine { get => startMachine; }

        void Start()
        {
            On_Enable_Machine += StartEvent;
            StartEvent(true);
            startPlayer = false;
            levelCounter = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (startMachine == true)
            {
                SetMachineColor();
            }
        }

        private void SetMachineColor()
        {
            timer += Time.deltaTime;
            if (timer >= timeChangeColor)
            {
                timer = 0;
                if (levelCounter < level) levelCounter++;
                else
                {
                    startMachine = false;
                    levelCounter = 0;
                }
            }
            lerpRatio = timer / timeChangeColor;
            _typecolor = (EColors)machineArray[levelCounter];
            ColorsGestor.instance.ChangeColor(_typecolor, lerpRatio);
            startPlayer = true;
        }

        private void StartEvent(bool _event)
        {
            machineArray = SimonSayMachine.instance.GenerateArray(level + 1, difficulty);
            startMachine = _event;
        }


    }


}
