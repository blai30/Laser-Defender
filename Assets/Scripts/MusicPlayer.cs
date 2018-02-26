using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;
    private AudioSource music;
	
	void Start() {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
		}
	}

    void OnLevelWasLoaded(int level) {
        Debug.Log("MusicPlayer: loaded level " + level);
    }

}
