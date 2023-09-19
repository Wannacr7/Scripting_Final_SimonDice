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

        public float timeToChange;

        public Action On_Enable_Machine;
        public Action On_Enable_Player;



        [SerializeField]private bool startMachine;
        [SerializeField] private bool startPlayer;



        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private int level = 0;
        /// <summary>
        /// Cuantos colores van a participar
        /// </summary>
        [SerializeField] public int difficulty = 0;


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

        }
        private void OnDisable()
        {

        }

     
  

    }


}
