using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanishing_Platform : MonoBehaviour
{
    [SerializeField]
    private float m_time_active = 2.0f;
    [SerializeField]
    private float m_initial_time_active = 2.0f;
    [SerializeField]
    private float m_time_inactive = 0.0f;

    private float m_time_remaining = 0.0f;
    private bool m_inactive = false;
    Renderer m_renderer = null;
    Collider m_collider = null;

    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        m_collider = GetComponent<Collider>();

        m_time_remaining = m_initial_time_active;
    }


    void Update()
    {
        m_time_remaining -= Time.deltaTime;

        if (m_time_remaining <= 0.0f)
        {
            if (m_inactive)
            {
                m_renderer.enabled = true;
                m_collider.enabled = true;

                m_inactive = false;
                m_time_remaining = m_time_active;
            }
            else
            {
                m_renderer.enabled = false;
                m_collider.enabled = false;

                m_inactive = true;
                m_time_remaining = m_time_inactive;
            }
        }
    }
}
