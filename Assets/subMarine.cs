using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subMarine : MonoBehaviour
{

    [SerializeField] ParticleSystem bubbles;
    [SerializeField] float pushForce = 200;
    [SerializeField] float turnForce = 100;
    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;
    [SerializeField] GameObject explosion;
        Rigidbody rb;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bubbles.Play();

    }

    private void TurnLightOff()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        light1.SetActive(false);
        light2.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
        light1.SetActive(true);
        light2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SwinMovement();
        TurnLightOff();
    }

    private void SwinMovement()
    {

        if (Input.GetKey(KeyCode.A))
        {
           rb.angularVelocity = Vector3.zero;
            transform.Rotate(Vector3.left * turnForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.angularVelocity = Vector3.zero;
            transform.Rotate(Vector3.right * turnForce * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {

            rb.AddRelativeForce(Vector3.forward * pushForce * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {

            rb.AddRelativeForce(Vector3.down * pushForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {

            rb.AddRelativeForce(Vector3.up * pushForce * Time.deltaTime);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Explode = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Explode.transform.parent = transform;
    }
}
