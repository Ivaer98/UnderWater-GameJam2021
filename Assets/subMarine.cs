using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subMarine : MonoBehaviour
{

    [SerializeField] ParticleSystem bubbles;
    [SerializeField] float pushForce = 20000;
    [SerializeField] float turnForce = 50;
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
        light1.SetActive(false);
        light2.SetActive(false);
        bubbles.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        SwinMovement();
    }

    private void SwinMovement()
    {

        if (Input.GetKey(KeyCode.D))
        {
           rb.angularVelocity = Vector3.zero;
            transform.Rotate(Vector3.left * turnForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.angularVelocity = Vector3.zero;
            transform.Rotate(Vector3.right * turnForce * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * pushForce * Time.deltaTime);
            bubbles.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Explode = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Explode.transform.parent = transform;
    }
}
