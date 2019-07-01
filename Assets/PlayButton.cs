using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    Image playImage;
    [SerializeField] float waittime = 3f;
    AudioSource ASource;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ASource = GetComponent<AudioSource>();
        playImage = GetComponent<Image>();
        playImage.enabled = false;
        StartCoroutine(EnableButton());
    }

    IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(waittime);
        playImage.enabled = true;
        ASource.Play();
    }

    public void loadScene1()
    {
        SceneManager.LoadScene(1);
    }
}
