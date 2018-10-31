using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {


	void Start () {
        InteractionManager.InteractionSourcePressed += tapHomebase;
	}

    void tapHomebase(InteractionSourcePressedEventArgs e)
    {
        SceneManager.LoadScene("Main");
        InteractionManager.InteractionSourcePressed -= tapHomebase;
    }
}