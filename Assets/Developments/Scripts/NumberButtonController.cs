﻿using UnityEngine;
using UnityEngine.UI;

public class NumberButtonController : MonoBehaviour {

    [SerializeField] InputField inputField;
    [SerializeField] int num = 0;
    [SerializeField] GameObject objects;

    public void tap1Button()
    {
        Debug.Log("tap 1 button");
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
        switch (num)
        {
            case 1:
                break;
            case 2:
                objects.transform.position = new Vector3(3.3f, 0, 0.8f);
                objects.transform.rotation = Quaternion.Euler(0, -54.3f, 0);
                break;
            case 3:
                objects.transform.position = new Vector3(0.35f, 0, 9.1f);
                objects.transform.rotation = Quaternion.Euler(0, -175.1f, 0);
                break;
            case 4:
                objects.transform.position = new Vector3(-4.2f, 0, 1.4f);
                objects.transform.rotation = Quaternion.Euler(0, 80.6f, 0);
                break;
            default:
                inputField.text = null;
                num = 0;
                return;
        }
        objects.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void tapDeleteButton()
    {
        inputField.text = null;
        num = 0;
    }
}