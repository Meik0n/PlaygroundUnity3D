using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float m_time_to_open = 2.0f;
    [SerializeField]
    private float m_opening_speed = 10.0f;

    private float m_opening_time_remaining = 0.0f;

    public void Open()
    {
        m_opening_time_remaining = m_time_to_open;
    }

    void Update()
    {
        if (m_opening_time_remaining > 0.0f)
        {
            transform.position += Vector3.up * m_opening_speed * Time.deltaTime;
            m_opening_time_remaining -= Time.deltaTime;
        }
    }
}
