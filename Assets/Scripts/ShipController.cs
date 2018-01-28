using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipController : MonoBehaviour
{

    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] float boost = 60f;
    public GameObject regularTrail;
    public GameObject boostTrail;

    Transform shipTransform;
    AudioSource boostSound;
    //public AudioSource boostContinuousSound;
    private Rigidbody rb;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float roll = 0.0f;


    private void Awake()
    {
        shipTransform = transform;
        Cursor.visible = false;
        AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();
        boostSound = audioSources[1];
    }

    void Update()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        yaw += turnSpeed * Input.GetAxis("Mouse X");

        pitch += turnSpeed * Input.GetAxis("Mouse Y");
        roll -= (turnSpeed / 50) * Input.GetAxis("Roll");
        shipTransform.eulerAngles = new Vector3(-pitch, yaw, roll);
    }

    void Thrust()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        { 
            boostSound.Play();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            boostSound.Stop();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.forward * boost * Time.deltaTime * Input.GetAxis("Vertical");
            regularTrail.SetActive(false);
            boostTrail.SetActive(true);
        }
        else
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            regularTrail.SetActive(true);
            boostTrail.SetActive(false);
        }



    }
}
