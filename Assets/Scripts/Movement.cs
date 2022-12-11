using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviourPun
{
    [SerializeField]
    float speed = 10f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(x, 0f, y) * speed * Time.deltaTime);
        } 
    }
}
