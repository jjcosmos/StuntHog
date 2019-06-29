using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<AudioClip> Splats;
    AudioSource audioSource;
    Rigidbody RBody;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        RBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Splats.Count > 0 && !other.CompareTag("Player"))
        {
            audioSource.volume = RBody.velocity.magnitude / 5;
            Debug.Log(RBody.velocity.magnitude / 5);
            audioSource.PlayOneShot(Splats[Random.Range(0, Splats.Count - 1)]);
            Debug.Log(other.tag);
        }
    }
}
