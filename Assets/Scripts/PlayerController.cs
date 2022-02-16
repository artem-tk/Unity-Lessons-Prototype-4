using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private GameObject FocalPoint;

    public float Speed = 5.0f;

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
}
