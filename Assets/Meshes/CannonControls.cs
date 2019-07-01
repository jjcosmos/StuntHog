using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CannonControls : MonoBehaviour
{
    
    public float MouseSensitivity = 1;
    [SerializeField] Transform Cannon_Barrel;
    [SerializeField] bool invertY = false;
    public Rigidbody cannonball;
    [SerializeField] Transform firePoint;
    [SerializeField] float force;

    [SerializeField] ParticleSystem PS_Smoke;
    [SerializeField] ParticleSystem PS_Flame;
    [SerializeField] CinemachineClearShot CSCam;

    AudioSource audioSource;

    PauseControlls pauseControls;
    int fireHash;

    bool canFire;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        canFire = true;
        CSCam.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X")) * Time.deltaTime * MouseSensitivity);
        if (invertY)
        {
            Cannon_Barrel.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * MouseSensitivity);
        }
        else
        {
            Cannon_Barrel.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * -MouseSensitivity);
        }

        if (Input.GetButtonDown("Fire1") && canFire) {
            Rigidbody ball = Instantiate(cannonball, firePoint.position, Quaternion.Euler(transform.forward));
            
            ball.velocity = Vector3.zero;
            
            
            ball.AddForce(-firePoint.up * force);
            
            canFire = false;
            CSCam.m_LookAt = ball.transform;
            CSCam.m_Follow = ball.transform;
            Camera.main.gameObject.SetActive(false);
            CSCam.gameObject.SetActive(true);


            //StartCoroutine(Timer());
            audioSource.Play();

        }
        
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(.5f);
        canFire = true;
    }
}
