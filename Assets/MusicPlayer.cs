using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private static MusicPlayer _instance;
    public static MusicPlayer Instance { get { return _instance; } }
    private AudioSource audioSource;
    private float maxVolume;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        maxVolume = audioSource.volume;
        audioSource.volume = 0;
        StartCoroutine(fadeInVolume());
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    IEnumerator fadeInVolume()
    {
        while(audioSource.volume < maxVolume)
        {
            audioSource.volume += .001f;
            yield return new WaitForSeconds(.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
