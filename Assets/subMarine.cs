using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subMarine : MonoBehaviour
{
    [SerializeField] ParticleSystem bubbles;
    [SerializeField] float pushForce = 20000;
    [SerializeField] float turnForce = 50;
    [SerializeField] GameObject lights1;
    [SerializeField] GameObject lights2;
    [SerializeField] GameObject explosion;
    Rigidbody rb;
    // Start is called before the first frame update
        void Start()
    {
        rb = GetComponent<Rigidbody>();
        bubbles.Stop();

    }

    private void TurnLightsOff()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        lights1.SetActive(false);
        lights2.SetActive(false);

        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
        lights1.SetActive(true);
        lights2.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
        {
            SwinActions();
            TurnLightsOff();
        }

        private void SwinActions()
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddRelativeForce(Vector3.right * pushForce * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.angularVelocity = Vector3.zero;
                transform.Rotate(Vector3.back * turnForce * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.angularVelocity = Vector3.zero;
                transform.Rotate(Vector3.forward * turnForce * Time.deltaTime);
            }

        }
        private void OnCollisionEnter(Collision other)
        {
            GameObject Explode = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Explode.transform.parent = transform;
        }
    }

}
