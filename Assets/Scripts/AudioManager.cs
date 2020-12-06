using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    #region Instance
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    #endregion

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake() {
        foreach(Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void PlayYellowGem() {
        sounds[0].source.Play(); 
    }

    public void PlayBlueGem() {
        sounds[1].source.Play();
    }

    public void PlayBallRoll() {
        sounds[2].source.Play();
    }

    public void StopBallRoll() {
        sounds[2].source.Stop();
    }

    public bool isBallRoll() {
        return sounds[2].source.isPlaying;
    }

    public void PlayBallBelowFloor()
    {
        //Debug.Log("111");
        sounds[3].source.Play();
        // Debug.Log("222");
    }
}
