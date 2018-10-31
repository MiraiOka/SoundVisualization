using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButtonController : MonoBehaviour {

    [SerializeField] InputField inputField;
    [SerializeField] int num = 0;

    public void tap1Button()
    {
        num = num * 10 + 1;
        inputField.text = num.ToString();
    }

    public void tap2Button()
    {
        num = num * 10 + 2;
        inputField.text = num.ToString();
    }

    public void tap3Button()
    {
        num = num * 10 + 3;
        inputField.text = num.ToString();
    }

    public void tap4Button()
    {
        num = num * 10 + 4;
        inputField.text = num.ToString();
    }

    public void tap5Button()
    {
        num = num * 10 + 5;
        inputField.text = num.ToString();
    }

    public void tap6Button()
    {
        num = num * 10 + 6;
        inputField.text = num.ToString();
    }

    public void tap7Button()
    {
        num = num * 10 + 7;
        inputField.text = num.ToString();
    }

    public void tap8Button()
    {
        num = num * 10 + 8;
        inputField.text = num.ToString();
    }

    public void tap9Button()
    {
        num = num * 10 + 9;
        inputField.text = num.ToString();
    }

    public void tap0Button()
    {
        num = num * 10;
        inputField.text = num.ToString();
    }

    public void tapDecisionButton()
    {
       
    }

    public void tapDeleteButton()
    {
        inputField.text = null;
        num = 0;
    }
}