using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limiter : MonoBehaviour
{

    [SerializeField]
    private float max_speed = 50.0f;
    private Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if( m_rigidbody.velocity.magnitude > max_speed )
        {
            m_rigidbody.velocity = m_rigidbody.velocity.normalized * max_speed;
        }
    }
}
