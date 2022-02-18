using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private GameObject FocalPoint;

    public bool Poweruped = false;

    public float Speed = 5.0f;
    private float PowerupStrength = 15.0f;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float ForwardInput = Input.GetAxis("Vertical");

        PlayerRB.AddForce(FocalPoint.transform.forward * Speed * ForwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Poweruped = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && Poweruped)
        {
            Rigidbody EnemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 AwayFromPlayer = (collision.gameObject.transform.position - transform.position);

            EnemyRigidbody.AddForce(AwayFromPlayer * PowerupStrength, ForceMode.Impulse);

            Debug.Log("U collide with " + collision.gameObject.name + " while powerup was " + Poweruped);   
        }
    }
}
