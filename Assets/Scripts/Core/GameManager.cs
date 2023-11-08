using IA;
using UI;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using Player;

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
        public static Action On_Enable_Machine;
        public static Action On_Enable_Player;
        public static Action<int> On_Set_Difficult;


        [SerializeField] private SimonSayMachine machine;
        [SerializeField] private SimonSayPlayer player;




        /// <summary>
        /// Cuantos pasos lleva la secuencia
        /// </summary>
        [SerializeField] private int level;
        /// <summary>
        /// Cuantos colores van a participar
        /// </summary>
        [SerializeField] public int difficulty;


        private void Start()
        {
            level = 1;
        }
        private void OnEnable()
        {
            On_Enable_Machine += StartMachine;
            On_Set_Difficult += SetDifficult;
        }
        private void OnDisable()
        {
            On_Enable_Machine -= StartMachine;
            On_Set_Difficult -= SetDifficult;
        }

        private void StartMachine()
        {
            StartCoroutine(machine.ShowColor(level, difficulty));
            level++;
        }
        private void StartPlayer()
        {

        }
        private void SetDifficult(int _difficult)
        {
            difficulty = _difficult;
        }
     
  

    }


}
