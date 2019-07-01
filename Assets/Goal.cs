using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int levelToLoad;
    ParticleSystem particles;
    AudioSource audioSource;
    bool isLoading;
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLoading)
        {
            particles.Play();
            audioSource.Play();
            StartCoroutine(LoadNextLevel());
            isLoading = true;
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(levelToLoad + 1);
    }
}
