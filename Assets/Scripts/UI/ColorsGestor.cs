using Core;
using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class ColorsGestor : MonoBehaviour
    {
        public static ColorsGestor instance;
        public static Action onFinishAnim;

        //[SerializeField] public Renderer red, yellow, blue, green, purple;
        [SerializeField] public Material red1, yellow1, blue1, green1, purple1;
        [SerializeField] AnimationCurve colorCurve;

        private float time = 0.5f;

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
            Cleaner();
            //StartCoroutine(SetAsDefault(EColors.Null, 0));
            //ChangeColor(EColors.Red);
        }
        public void ChangeColor(EColors _typecolor)
        {
            switch (_typecolor)
            {
                case EColors.Red:
                    red1.EnableKeyword("_EMISSION");
                    red1.SetColor("_EmissionColor", red1.color);
                    red1.SetFloat("_EmissionScaleUI", 1.0f);
                    StartCoroutine(SetAsDefault(EColors.Red, time));
                    break;
                case EColors.Yellow:
                    yellow1.EnableKeyword("_EMISSION");
                    yellow1.SetColor("_EmissionColor", yellow1.color);
                    yellow1.SetFloat("_EmissionScaleUI", 1.0f);
                    StartCoroutine (SetAsDefault(EColors.Yellow, time));
                    break;
                case EColors.Blue:
                    blue1.EnableKeyword("_EMISSION");
                    blue1.SetColor("_EmissionColor", blue1.color);
                    blue1.SetFloat("_EmissionScaleUI", 1.0f);
                    StartCoroutine(SetAsDefault(EColors.Blue,time));
                    break;
                case EColors.Green:
                    green1.EnableKeyword("_EMISSION");
                    green1.SetColor("_EmissionColor", green1.color);
                    green1.SetFloat("_EmissionScaleUI", 1.0f);
                    StartCoroutine(SetAsDefault(EColors.Green,time));
                    break;
                case EColors.Purple:
                    purple1.EnableKeyword("_EMISSION");
                    purple1.SetColor("_EmissionColor", purple1.color);
                    purple1.SetFloat("_EmissionScaleUI", 1.0f);
                    StartCoroutine(SetAsDefault(EColors.Purple,time));
                    break;
                default:
                    break;
            }
        }
        private IEnumerator SetAsDefault(EColors _NoChange, float _time)
        {
            yield return new WaitForSeconds(_time);
            switch (_NoChange)
            {
                case EColors.Red:
                    red1.SetColor("_EmissionColor", Color.black);
                    
                    break;
                case EColors.Yellow:
                    yellow1.SetColor("_EmissionColor", Color.black);
                    
                    break;
                case EColors.Blue:
                    blue1.SetColor("_EmissionColor", Color.black);
                    
                    break;
                case EColors.Green:
                    green1.SetColor("_EmissionColor", Color.black);
                    
                    break;
                case EColors.Purple:
                    purple1.SetColor("_EmissionColor", Color.black);
                    
                    break;

                default:
                    break;
            }
            onFinishAnim?.Invoke();
        }
        private void Cleaner()
        {
            red1.SetColor("_EmissionColor", Color.black);

            yellow1.SetColor("_EmissionColor", Color.black);

            blue1.SetColor("_EmissionColor", Color.black);

            green1.SetColor("_EmissionColor", Color.black);

            purple1.SetColor("_EmissionColor", Color.black);
        }


    }

}

