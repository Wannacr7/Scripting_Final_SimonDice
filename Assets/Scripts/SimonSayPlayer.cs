using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSayPlayer : MonoBehaviour
{

    private float timeChangeColor = 1f;
    private float timer = 0;
    private float lerpRatio;
    private EColors colorON;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerNum();
        if (!(colorON is EColors.Null))
        {
            AnimatorColors();
        }

    }

    private void GetPlayerNum()
    {
        if (Input.GetKeyDown((KeyCode.Q)))
        {
            colorON = EColors.Red;
            timer = 0;
        }
        if (Input.GetKeyDown((KeyCode.W)))
        {
            colorON = EColors.Yellow;
            timer = 0;
        }
        if (Input.GetKeyDown((KeyCode.A)))
        {
            colorON = EColors.Blue;
            timer = 0;
        }
        if (Input.GetKeyDown((KeyCode.S)))
        {
            colorON = EColors.Green;
            timer = 0;
        }
        if (Input.GetKeyDown((KeyCode.D)))
        {
            colorON = EColors.Purple;
            timer = 0;
        }
       
    }
    private void AnimatorColors()
    {
        timer += Time.deltaTime;
        if (timer >= timeChangeColor)
        {
            timer = 0;
            colorON = EColors.Null;
        }
        lerpRatio = timer / timeChangeColor;

        switch (colorON)
        {
            case EColors.Red:
                ColorsGestor.instance.ChangeColor(colorON, lerpRatio);
                break;
            case EColors.Yellow:
                ColorsGestor.instance.ChangeColor(colorON, lerpRatio);
                break;
            case EColors.Blue:
                ColorsGestor.instance.ChangeColor(colorON, lerpRatio);
                break;
            case EColors.Green:
                ColorsGestor.instance.ChangeColor(colorON, lerpRatio);
                break;
            case EColors.Purple:
                ColorsGestor.instance.ChangeColor(colorON, lerpRatio);
                break;
            default:
                break;
        }
    }
}
