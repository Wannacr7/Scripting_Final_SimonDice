using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EColors
{
    Red=0,
    Yellow=1,
    Blue=2,
    Green=3,
    Purple=4
}
public class GameManager : MonoBehaviour
{
    private EColors _typecolor;
    //Colores
    [SerializeField] private Renderer red, yellow, blue, green, purple;
    [SerializeField] AnimationCurve colorCurve;

    public Action<bool> On_Enable_Machine;
    private bool startMachine = false;
    private bool startGame = false;
    private int[] machineArray;

    private float timeChangeColor = 1f;
    private float timer = 0;
    private float lerpRatio;

    [SerializeField]private int level = 1;
    [SerializeField]private int levelCounter=0;
    [SerializeField]public int difficulty = 0;

    void Start()
    {
        On_Enable_Machine += StartEvent;

        red.material.color = new Color(0.5f, 0.1f, 0.1f);
        yellow.material.color= new Color(0.5f, 0.5f, 0.1f);
        blue.material.color = new Color(0.1f,0.1f,0.5f);
        green.material.color = new Color(0.1f, 0.5f, 0.1f);
        purple.material.color = new Color(0.5f, 0.1f, 0.5f);
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
        switch (_typecolor)
        {
            case EColors.Red:
                red.material.color = Color.LerpUnclamped(new Color(0.5f, 0.1f, 0.1f), new Color(1f, 0f, 0f), colorCurve.Evaluate(lerpRatio));
                break;
            case EColors.Yellow:
                yellow.material.color = Color.LerpUnclamped(new Color(0.5f, 0.5f, 0.1f), new Color(1f, 1f, 0f), colorCurve.Evaluate(lerpRatio));
                break;
            case EColors.Blue:
                blue.material.color = Color.LerpUnclamped(new Color(0.1f, 0.1f, 0.5f), new Color(0f, .2f, 1f), colorCurve.Evaluate(lerpRatio));
                break;
            case EColors.Green:
                green.material.color = Color.LerpUnclamped(new Color(0.1f, 0.5f, 0.1f), new Color(0f, 1f, 0f), colorCurve.Evaluate(lerpRatio));
                break;
            case EColors.Purple:
                purple.material.color = Color.LerpUnclamped(new Color(0.5f, 0.1f, 0.5f), new Color(1f, 0f, 1f), colorCurve.Evaluate(lerpRatio));
                break;
            default:
                break;
        }
    }

    private void  StartEvent(bool _event)
    {
        machineArray= SimonSayMachine.instance.GenerateArray(level + 1, difficulty);
        startMachine = _event;
        
    }
    

}