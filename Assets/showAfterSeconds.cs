using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showAfterSeconds : MonoBehaviour
{
    // Start is called before the first frame update
    public float seconds = 16;
    TextMeshProUGUI ugui;
    bool shooting;
    
    void Start()
    {
        ugui = GetComponent<TextMeshProUGUI>();
        ugui.enabled = false;
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !shooting)
        {
            shooting = true;
            StartCoroutine(stall());
        }
    }

    IEnumerator stall()
    {
        yield return new WaitForSeconds(seconds);
        ugui.enabled = true;

    }
}
