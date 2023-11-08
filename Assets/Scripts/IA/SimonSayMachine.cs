using Core;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace IA
{
    public class SimonSayMachine : MonoBehaviour
    {
        private List<int> machineCount;



        public IEnumerator ShowColor(int _index, int _difficulty)
        {
            var temp = GenerateArray(_index, _difficulty);

            for (int i = 0; i < temp.Count; i++) 
            {
                yield return new WaitForSeconds(1);
                ColorsGestor.instance.ChangeColor((EColors)temp[i]);


            }
        }

        /// <summary>
        /// Genera un color basado en el limite de la dificultad seleccionado por el jugador
        /// </summary>
        /// <param name="maxExclusive"></param>
        /// <returns></returns>
        private int GenerateColor(int maxExclusive)
        {
            int rnd = Random.Range(0, maxExclusive);
            return rnd;
        }

        /// <summary>
        /// Genera el array que contruira la secuencia del juego
        /// </summary>
        /// <param name="index"> Cuantos pasos lleva la secuencia</param>
        /// <param name="difficulty"> Toma en cuenta los modos de dificultad del juego</param>
        /// <returns></returns>
        private List<int> GenerateArray(int _level, int _difficulty)
        {
            if(_level == 1)
            {
                machineCount = new List<int>
                {
                    GenerateColor(_difficulty)
                };
            }
            while (machineCount.Count < _level)
            {
                machineCount.Add(GenerateColor(_difficulty));
            }

            Debug.Log(machineCount);
            return machineCount;
        }
    }


}
