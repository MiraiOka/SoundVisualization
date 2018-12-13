using UnityEngine;
using uOSC;

///////////////////////////////
using UnityEngine.UI;
using System;
///////////////////////////////

public class ServerManager : MonoBehaviour {

    [SerializeField] GameObject[] fires1;
    [SerializeField] GameObject[] fires2;
    [SerializeField] GameObject[] fires3;
    [SerializeField] GameObject[] fires4;


    ///////////////////////////////
    [SerializeField] Text res1_1;
    [SerializeField] Text res1_2;
    [SerializeField] Text res1_3;
    [SerializeField] Text res2_1;
    [SerializeField] Text res2_2;
    [SerializeField] Text res2_3;
    [SerializeField] Text res3_1;
    [SerializeField] Text res3_2;
    [SerializeField] Text res3_3;
    [SerializeField] Text res4_1;
    [SerializeField] Text res4_2;
    [SerializeField] Text res4_3;

    int preN1 = 0;
    int preN2 = 0;
    int preN3 = 0;
    float correctRate1;
    float correctRate2;
    float correctRate3;
    float correctCount1 = 0;
    float correctCount2 = 0;
    float correctCount3 = 0;

    float time1 = 0;
    float time2 = 0;
    float time3 = 0;

    float avg1 = 0;
    float avg2 = 0;
    float avg3 = 0;

    int n1 = 0;
    int n2 = 0;
    int n3 = 0;
    ///////////////////////////////


    void Start () {
        uOscServer server = GetComponent<uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);
	}

    private void Update()
    {
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
        time3 += Time.deltaTime;
    }

    void OnDataReceived(Message message)
    {
        int num;
        num = (int)message.values[0];
        float vol;
        vol = (float)message.values[1];

        int n = (int)message.values[2];

        float receptAvg = (float)message.values[3];

        int sendNow = (int)message.values[4];
        int receptNow = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        int communicationTime = receptNow - sendNow;


        switch (num)
        {
            case 1:
                ///////////////////////////////
                if(n > 500)
                {
                    res1_1.text = communicationTime.ToString();

                    res2_1.text = receptAvg.ToString();

                    avg1 *= n1;
                    n1++;
                    avg1 = (avg1 + time1) / n1;
                    res3_1.text = avg1.ToString();
                    time1 = 0;

                    if (n - preN1 == 1) correctCount1++;
                    res4_1.text = (n1 / correctCount1).ToString();
                    preN1 = n;
                }

               
                ///////////////////////////////
                if (vol > 5)
                {
                    if(fires1[0].transform.localScale.x < 2.5f)
                    {
                        for (int i = 0; i < fires1.Length; i++)
                        {
                            fires1[i].transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                        }
                    }
                }
                else
                {
                    if (fires1[0].transform.localScale.x > 0)
                    {
                        for (int i = 0; i < fires1.Length; i++)
                        {
                            fires1[i].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                        }
                    }
                }
                break;
            case 2:
                ///////////////////////////////
                if (n > 500)
                {
                    res1_2.text = communicationTime.ToString();

                    res2_2.text = receptAvg.ToString();

                    avg2 *= n2;
                    n2++;
                    avg2 = (avg2 + time2) / n2;
                    res3_2.text = avg2.ToString();
                    time2 = 0;

                    if (n - preN2 == 1) correctCount2++;
                    res4_2.text = (n2 / correctCount2).ToString();
                    preN2 = n;
                }

                
                ///////////////////////////////
                if (vol > 5)
                {
                    if (fires2[0].transform.localScale.x < 2.5f)
                    {
                        for (int i = 0; i < fires2.Length; i++)
                        {
                            fires2[i].transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                        }
                    }
                }
                else
                {
                    if (fires2[0].transform.localScale.x > 0)
                    {
                        for (int i = 0; i < fires2.Length; i++)
                        {
                            fires2[i].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                        }
                    }
                }
                break;
            case 3:
                ///////////////////////////////
                
                if (n > 500)
                {

                    res1_3.text = communicationTime.ToString();
                    res2_3.text = receptAvg.ToString();

                    avg3 *= n3;
                    n3++;
                    avg3 = (avg3 + time3) / n3;
                    res3_3.text = avg3.ToString();
                    time3 = 0;

                    if (n - preN3 == 1) correctCount3++;
                    res4_3.text = (n3 / correctCount3).ToString();
                    preN3 = n;
                }

                
                ///////////////////////////////
                if (vol > 5)
                {
                    if (fires3[0].transform.localScale.x < 2.5f)
                    {
                        for (int i = 0; i < fires3.Length; i++)
                        {
                            fires3[i].transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                        }
                    }
                }
                else
                {
                    if (fires3[0].transform.localScale.x > 0)
                    {
                        for (int i = 0; i < fires3.Length; i++)
                        {
                            fires3[i].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                        }
                    }
                }
                break;
            case 4:
                if (vol > 5)
                {
                    if (fires4[0].transform.localScale.x < 2.5f)
                    {
                        for (int i = 0; i < fires4.Length; i++)
                        {
                            fires4[i].transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                        }
                    }
                }
                else
                {
                    if (fires4[0].transform.localScale.x > 0)
                    {
                        for (int i = 0; i < fires4.Length; i++)
                        {
                            fires4[i].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                        }
                    }
                }
                break;
            default:
                break;
        }
    }
}
