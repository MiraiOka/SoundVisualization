using UnityEngine;

public class SoundController : MonoBehaviour {

    AudioSource audio;
	
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	public void soundsOK()
    {
        audio.Play();
    }
}
