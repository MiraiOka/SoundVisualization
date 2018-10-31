using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;
using UnityEngine.UI;

public class ServerManager : MonoBehaviour {

    [SerializeField] GameObject[] fires;
    [SerializeField] Text text;


	void Start () {
        uOscServer server = GetComponent<uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);
	}
	
	void OnDataReceived(Message message)
    {
        float msg;
        msg = (float)message.values[0];
        Debug.Log(msg);
        text.text = msg.ToString();

        if(msg > 5)
        {
            for (int i = 0; i < fires.Length; i++)
            {
                fires[i].transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }
        } else
        {
            if(fires[0].transform.localScale.x > 0)
            {
                for (int i = 0; i < fires.Length; i++)
                {
                    fires[i].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                }
            }
        }
        
    }
}
