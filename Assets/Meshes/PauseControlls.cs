using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControlls : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject PauseMenu;
    [SerializeField] Camera cam;
    [SerializeField] CannonControls controls;
    [SerializeField] Slider FOVSlider;
    [SerializeField] Slider SensSlider;
    [SerializeField] Button MMButton;
    
    public bool paused;
    void Start()
    {
        paused = false;
        PauseMenu.SetActive(false);
        MMButton.gameObject.SetActive(false);
        FOVSlider.gameObject.SetActive(false);
        SensSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            MMButton.gameObject.SetActive(true);
            paused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            FOVSlider.gameObject.SetActive(true);
            SensSlider.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) )
        {
            PauseMenu.SetActive(false);
            MMButton.gameObject.SetActive(false);
            Time.timeScale = 1;
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            FOVSlider.gameObject.SetActive(false);
            SensSlider.gameObject.SetActive(false);
        }
    }

    public void UpdateSens()
    {
        controls.MouseSensitivity = SensSlider.value;
    }

    public void UpdateFOV()
    {
        cam.fieldOfView = FOVSlider.value;
    }
}
