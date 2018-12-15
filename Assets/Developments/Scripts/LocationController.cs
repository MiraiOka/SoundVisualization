using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.UI;

struct Point
{
    public int first, second, third;
    public float diff;
}

public class LocationController : MonoBehaviour {

    [SerializeField] GameObject firstObject;
    [SerializeField] GameObject secondObject;
    [SerializeField] GameObject thirdObject;

    float distance12;
    float distance23;
    float distance31;

    [SerializeField] Camera holoCamera;

    [SerializeField] int length = 10; //会場のスケール(東京ドームなら200)
    int size; //10cmごと計算するから length * 10が代入される

    [SerializeField] Text text;
    [SerializeField] GameObject panel;

    [SerializeField] float range = 0.1f; //誤差の範囲

    Vector3[] firstRayPos;
    Vector3[] secondRayPos;
    Vector3[] thirdRayPos;

    [SerializeField] GameObject server;

    List<Point> points12 = new List<Point>();
    Point point12 = new Point();
    List<Point> points123 = new List<Point>();
    Point point123 = new Point();

    [SerializeField] GameObject okButton;
    [SerializeField] GameObject noButton;

    [SerializeField] GameObject[] fires;

    Vector3 firstObjectPos;
    Quaternion firstObjectRot;

    SoundController sound;


    enum Target
    {
        first,
        second,
        third,
        fin
    }
    Target target = Target.first;


    void Start()
    {
        InteractionManager.InteractionSourcePressed += InteractionSourcePressed;

        distance12 = Vector3.Distance(firstObject.transform.position, secondObject.transform.position);
        distance23 = Vector3.Distance(secondObject.transform.position, thirdObject.transform.position);
        distance31 = Vector3.Distance(thirdObject.transform.position, firstObject.transform.position);

        size = length * 10;

        firstRayPos = new Vector3[size];
        secondRayPos = new Vector3[size];
        thirdRayPos = new Vector3[size];

        firstObjectPos = firstObject.transform.position;
        firstObjectRot = firstObject.transform.rotation;

        sound = GetComponent<SoundController>();
    }

    void InteractionSourcePressed(InteractionSourcePressedEventArgs ev)
    {
        Vector3 headPos = holoCamera.transform.position;
        Vector3 direction = holoCamera.transform.forward;

        sound.soundsOK();

        switch (target)
        {
            case Target.first:

                for (int i = 0; i < size; i++)
                {
                    firstRayPos[i] = headPos + direction * (i / 10.0f);
                }

                target = Target.second;
                text.text = "ムックをクリックしてください";


                break;
            case Target.second:

                for (int i = 0; i < size; i++)
                {
                    secondRayPos[i] = headPos + direction * (i / 10.0f);

                    for (int j = 0; j < size; j++)
                    {
                        float tmpDis12 = Vector3.Distance(firstRayPos[j], secondRayPos[i]);
                        float diff12 = Mathf.Abs(tmpDis12 - distance12);
                        if (diff12 < range)
                        {
                            point12.first = j;
                            point12.second = i;
                            point12.diff += diff12;
                            points12.Add(point12);
                        }
                    }
                }

                target = Target.third;
                text.text = "ガチャピンをクリックしてください";

                break;
            case Target.third:

                float min = 9999;
                int min1 = -1;
                int min2 = -1;
                int min3 = -1;

                for (int i = 0; i < size; i++)
                {
                    thirdRayPos[i] = headPos + direction * (i / 10.0f);

                    for (int j = 0; j < points12.Count; j++)
                    {
                        float tmpDis23 = Vector3.Distance(secondRayPos[points12[j].second], thirdRayPos[i]);
                        float diff23 = Mathf.Abs(tmpDis23 - distance23);

                        if (diff23 < range)
                        {
                            float tmpDis31 = Vector3.Distance(thirdRayPos[i], firstRayPos[points12[j].first]);
                            float diff31 = Mathf.Abs(tmpDis31 - distance31);
                            if (diff31 < range)
                            {
                                float hoge = points12[j].diff + diff23 + diff31;

                                if (points12[j].diff + diff23 + diff31 < min)
                                {
                                    min1 = points12[j].first;
                                    min2 = points12[j].second;
                                    min3 = i;
                                }
                            }
                        }
                    }
                }
                if (min1 != -1)
                {
                    Vector3 vec = firstRayPos[min1] - firstObject.transform.position;
                    gameObject.transform.position += vec;
                    firstObject.transform.parent = null;

                    firstObject.transform.LookAt(thirdObject.transform);
                    gameObject.transform.parent = firstObject.transform.transform;
                    firstObject.transform.LookAt(thirdRayPos[min3]);

                    text.text = "炎の位置はこれでいいですか？";
                    for(int i = 0; i < fires.Length; i++)
                    {
                        fires[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    }
                    okButton.SetActive(true);
                    noButton.SetActive(true);
                }
                else
                {
                    target = Target.first;
                    text.text = "ヨッシーをクリックしてください";
                }

                break;
            case Target.fin:
                break;
            default:
                break;
        }
    }

    public void tapOKButton()
    {
        for (int i = 0; i < fires.Length; i++)
        {
            fires[i].transform.localScale = new Vector3(0, 0, 0);
        }
        target = Target.fin;
        InteractionManager.InteractionSourcePressed -= InteractionSourcePressed;

        Destroy(panel);

        server.SetActive(true);

        
    }

    public void tapNoButton()
    {
        for (int i = 0; i < fires.Length; i++)
        {
            fires[i].transform.localScale = new Vector3(0, 0, 0);
        }
        target = Target.first;
        text.text = "ヨッシーをクリックしてください";
        okButton.SetActive(false);
        noButton.SetActive(false);
        gameObject.transform.parent = null;
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        firstObject.transform.parent = gameObject.transform;
        firstObject.transform.position = firstObjectPos;
        firstObject.transform.rotation = firstObjectRot;
    }
}
