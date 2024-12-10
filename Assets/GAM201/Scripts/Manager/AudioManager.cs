using UnityEngine;
using UnityEngine.Scripting;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource mAudio;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        mAudio = GetComponent<AudioSource>();
    }
}