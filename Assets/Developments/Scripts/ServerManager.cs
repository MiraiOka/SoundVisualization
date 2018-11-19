using UnityEngine;
using uOSC;
using UnityEngine.UI;

public class ServerManager : MonoBehaviour {

    [SerializeField] GameObject[] fires1;
    [SerializeField] GameObject[] fires2;
    [SerializeField] GameObject[] fires3;
    [SerializeField] GameObject[] fires4;
    [SerializeField] Text text;

    float avg = 0;
    float time = 0;
    int i = 0;


	void Start () {
        uOscServer server = GetComponent<uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);
	}

    private void Update()
    {
        time += Time.deltaTime;
    }

    void OnDataReceived(Message message)
    {
        int num;
        num = (int)message.values[0];
        float vol;
        vol = (float)message.values[1];
        int hoge = (int)message.values[2];
        //Debug.Log(vol);

        

        switch (num)
        {
            case 1:
                avg *= i;
                avg += time;
                i++;
                avg /= i;
                text.text = avg.ToString();
                time = 0;
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
