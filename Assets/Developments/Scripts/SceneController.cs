using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    AudioSource audio;
    [SerializeField] SoundController sound;

	void Start () {
        InteractionManager.InteractionSourcePressed += tapHomebase;
	}

    void tapHomebase(InteractionSourcePressedEventArgs e)
    {
        sound.soundsOK();
        InteractionManager.InteractionSourcePressed -= tapHomebase;
        SceneManager.LoadScene("Main");
    }
}