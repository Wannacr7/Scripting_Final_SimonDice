using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA
{
    public class SimonSayMachine : MonoBehaviour
    {

        public static SimonSayMachine instance;
        private List<int> machineCount;


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
            machineCount  = new List<int>();
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
        public List<int> GenerateArray(int index, int difficulty)
        {
            while(machineCount.Count < index)
            {
                machineCount.Add(GenerateColor(difficulty));
            }
            return machineCount;
        }
    }


}
