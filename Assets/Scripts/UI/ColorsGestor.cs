using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ColorsGestor : MonoBehaviour
    {
        public static ColorsGestor instance;

        [SerializeField] public Renderer red, yellow, blue, green, purple;
        [SerializeField] public Material red1, yellow1, blue1, green1, purple1;
        [SerializeField] AnimationCurve colorCurve;

        private float timeChangeColor = 1f;
        private float timer = 0;
        private float lerpRatio;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

        }

        // Start is called before the first frame update
        void Start()
        {
            green1.EnableKeyword("_EMISSION");

            SetAsDefault(EColors.Null);
        }
        public void ChangeColor(EColors _typecolor, float _learpRatio)
        {
            switch (_typecolor)
            {
                case EColors.Red:
                    red1.SetColor("_EmissionColor", red1.color);
                    red1.SetFloat("_EmissionScaleUI", 1.0f);
                    SetAsDefault(EColors.Red);
                    break;
                case EColors.Yellow:
                    yellow1.SetColor("_EmissionColor", yellow1.color);
                    yellow1.SetFloat("_EmissionScaleUI", 1.0f);
                    SetAsDefault(EColors.Yellow);
                    break;
                case EColors.Blue:
                    blue1.SetColor("_EmissionColor", blue1.color);
                    blue1.SetFloat("_EmissionScaleUI", 1.0f);
                    SetAsDefault(EColors.Blue);
                    break;
                case EColors.Green:
                    green1.SetColor("_EmissionColor", green1.color);
                    green1.SetFloat("_EmissionScaleUI", 1.0f);
                    SetAsDefault(EColors.Green);
                    break;
                case EColors.Purple:
                    purple1.SetColor("_EmissionColor", purple1.color);
                    purple1.SetFloat("_EmissionScaleUI", 1.0f);
                    SetAsDefault(EColors.Purple);
                    break;
                default:
                    break;
            }
        }
        private void SetAsDefault(EColors _NoChange)
        {
            switch (_NoChange)
            {
                case EColors.Red:
                    red1.SetColor("_EmissionColor", Color.black);
                    red1.SetFloat("_EmissionScaleUI", 0.0f);
                    break;
                case EColors.Yellow:
                    yellow1.SetColor("_EmissionColor", Color.black);
                    yellow1.SetFloat("_EmissionScaleUI", 0.0f);
                    break;
                case EColors.Blue:
                    blue1.SetColor("_EmissionColor", Color.black);
                    blue1.SetFloat("_EmissionScaleUI", 0.0f);
                    break;
                case EColors.Green:
                    green1.SetColor("_EmissionColor", Color.black);
                    green1.SetFloat("_EmissionScaleUI", 0.0f);
                    break;
                case EColors.Purple:
                    purple1.SetColor("_EmissionColor", Color.black);
                    purple1.SetFloat("_EmissionScaleUI", 0.0f);
                    break;
                default:
                    break;
            }
        }


    }

}

