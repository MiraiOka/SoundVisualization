using UnityEngine;

public class SoundController : MonoBehaviour {

    AudioSource audio;
    [SerializeField] AudioClip ok;
    [SerializeField] AudioClip ng;
	
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	public void soundsOK()
    {
        audio.clip = ok;
        audio.Play();
    }

    public void soundsNG()
    {
        audio.clip = ng;
        audio.Play();
    }
}
