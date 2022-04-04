using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private GameObject FocalPoint;
    public GameObject PowerupIndicator;

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
        PowerupIndicator.transform.position = transform.position + new Vector3 (0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Poweruped = true;
            Destroy(other.gameObject);
            PowerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine ()
    {
        yield return new WaitForSeconds(7);
        Poweruped = false;
        PowerupIndicator.gameObject.SetActive(false);
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
