using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObjects : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float constantForce;
    public Rigidbody2D RB => rb;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(constantForce * transform.right);
    }
}
