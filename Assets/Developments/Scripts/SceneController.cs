using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {


	void Start () {
        InteractionManager.InteractionSourcePressed += tapHomebase;
	}

    void tapHomebase(InteractionSourcePressedEventArgs e)
    {
        InteractionManager.InteractionSourcePressed -= tapHomebase;
        SceneManager.LoadScene("Main");
    }
}