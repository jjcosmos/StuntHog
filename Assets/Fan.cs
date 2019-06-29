using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] float fanForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CollisionManager>())
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * Time.deltaTime * fanForce);
        }
    }
}
