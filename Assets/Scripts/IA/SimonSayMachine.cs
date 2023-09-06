using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA
{
    public class SimonSayMachine : MonoBehaviour
    {

        public static SimonSayMachine instance;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(instance);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            //int[] test = GenerateArray(2,2);
            //for (int i = 0; i < test.Length; i++)
            //{
            //    Debug.Log(test[i]);
            //}

        }

        // Update is called once per frame
        void Update()
        {

        }


        private int GenerateColor(int maxExclusive)
        {
            int rnd = Random.Range(0, maxExclusive);
            return rnd;
        }

        /// <summary>
        /// Genera el array que contruira la secuencia del juego
        /// </summary>
        /// <param name="index"> Representa el numero de veces que se repite la secuencia</param>
        /// <param name="difficulty"> Toma en cuenta los modos de dificultad del juego</param>
        /// <returns></returns>
        public int[] GenerateArray(int index, int difficulty)
        {
            int[] fill = new int[index];
            for (int i = 0; i < fill.Length; i++)
            {
                fill[i] = GenerateColor(difficulty);
            }
            return fill;
        }
    }


}
