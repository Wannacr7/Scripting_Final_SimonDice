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
            SetAsDefault(EColors.Null);
        }
        public void ChangeColor(EColors _typecolor, float _learpRatio)
        {
            switch (_typecolor)
            {
                case EColors.Red:
                    red.material.color = Color.LerpUnclamped(new Color(0.5f, 0.1f, 0.1f), new Color(1f, 0f, 0f), colorCurve.Evaluate(_learpRatio));
                    SetAsDefault(EColors.Red);
                    break;
                case EColors.Yellow:
                    yellow.material.color = Color.LerpUnclamped(new Color(0.5f, 0.5f, 0.1f), new Color(1f, 1f, 0f), colorCurve.Evaluate(_learpRatio));
                    SetAsDefault(EColors.Yellow);
                    break;
                case EColors.Blue:
                    blue.material.color = Color.LerpUnclamped(new Color(0.1f, 0.1f, 0.5f), new Color(0f, .2f, 1f), colorCurve.Evaluate(_learpRatio));
                    SetAsDefault(EColors.Blue);
                    break;
                case EColors.Green:
                    green.material.color = Color.LerpUnclamped(new Color(0.1f, 0.5f, 0.1f), new Color(0f, 1f, 0f), colorCurve.Evaluate(_learpRatio));
                    SetAsDefault(EColors.Green);
                    break;
                case EColors.Purple:
                    purple.material.color = Color.LerpUnclamped(new Color(0.5f, 0.1f, 0.5f), new Color(1f, 0f, 1f), colorCurve.Evaluate(_learpRatio));
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
                    yellow.material.color = new Color(0.5f, 0.5f, 0.1f);
                    blue.material.color = new Color(0.1f, 0.1f, 0.5f);
                    green.material.color = new Color(0.1f, 0.5f, 0.1f);
                    purple.material.color = new Color(0.5f, 0.1f, 0.5f);
                    break;
                case EColors.Yellow:
                    red.material.color = new Color(0.5f, 0.1f, 0.1f);
                    blue.material.color = new Color(0.1f, 0.1f, 0.5f);
                    green.material.color = new Color(0.1f, 0.5f, 0.1f);
                    purple.material.color = new Color(0.5f, 0.1f, 0.5f);
                    break;
                case EColors.Blue:
                    red.material.color = new Color(0.5f, 0.1f, 0.1f);
                    yellow.material.color = new Color(0.5f, 0.5f, 0.1f);
                    green.material.color = new Color(0.1f, 0.5f, 0.1f);
                    purple.material.color = new Color(0.5f, 0.1f, 0.5f);
                    break;
                case EColors.Green:
                    red.material.color = new Color(0.5f, 0.1f, 0.1f);
                    yellow.material.color = new Color(0.5f, 0.5f, 0.1f);
                    blue.material.color = new Color(0.1f, 0.1f, 0.5f);
                    purple.material.color = new Color(0.5f, 0.1f, 0.5f);
                    break;
                case EColors.Purple:
                    red.material.color = new Color(0.5f, 0.1f, 0.1f);
                    yellow.material.color = new Color(0.5f, 0.5f, 0.1f);
                    blue.material.color = new Color(0.1f, 0.1f, 0.5f);
                    green.material.color = new Color(0.1f, 0.5f, 0.1f);
                    break;
                case EColors.Null:
                    red.material.color = new Color(0.5f, 0.1f, 0.1f);
                    yellow.material.color = new Color(0.5f, 0.5f, 0.1f);
                    blue.material.color = new Color(0.1f, 0.1f, 0.5f);
                    green.material.color = new Color(0.1f, 0.5f, 0.1f);
                    purple.material.color = new Color(0.5f, 0.1f, 0.5f);
                    break;
                default:
                    break;
            }
        }


    }

}

