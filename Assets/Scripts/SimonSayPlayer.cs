using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimonSayPlayer : MonoBehaviour
{
    //timer de los colores
    private float timeChangeColor = 1f;
    private float timer = 0;
    private float lerpRatio;

    //Timer para el jugador
    private float timeToCompleteSecuence = 1f;
    private float counter = 0;

    //Verifica secuencia
    [SerializeField] private GameManager main;
    private int sequenceLenght = 0;
    private bool verifyNumber = false;


    private EColors colorON;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (main.StartPlayer)
        {
            GetPlayerNum();
            if (!(colorON is EColors.Null))
            {
                AnimatorColors();
            }
            if (verifyNumber)
            {
                CanContinue();
            }
            
        }
        

    }

    private void GetPlayerNum()
    {
        if (Input.GetKeyDown((KeyCode.Q)))
        {
            colorON = EColors.Red;
            timer = 0;
            verifyNumber = true;
            
        }
        if (Input.GetKeyDown((KeyCode.W)))
        {
            colorON = EColors.Yellow;
            timer = 0;
            verifyNumber = true;
        }
        if (Input.GetKeyDown((KeyCode.A)))
        {
            colorON = EColors.Blue;
            timer = 0;
            verifyNumber = true;
        }
        if (Input.GetKeyDown((KeyCode.S)))
        {
            colorON = EColors.Green;
            timer = 0;
            verifyNumber = true;
        }
        if (Input.GetKeyDown((KeyCode.D)))
        {
            colorON = EColors.Purple;
            timer = 0;
            verifyNumber = true;
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
    private void CanContinue()
    {
        Debug.Log((int)colorON + "  " + main.MachineArray[sequenceLenght]);
        if (((int)colorON) == main.MachineArray[sequenceLenght])
        {
            main.Level++;
            sequenceLenght++;
            verifyNumber = false;
            if (sequenceLenght == main.MachineArray.Length)
            {
                Invoke("CallMachine", 1);
            }
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void CallMachine()
    {
        sequenceLenght = 0;
        main.On_Enable_Machine?.Invoke(true);
    }
}
