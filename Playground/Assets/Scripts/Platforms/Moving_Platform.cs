using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    [SerializeField]
    private Transform m_waypoint_1 = null;
    [SerializeField]
    private Transform m_waypoint_2 = null;
    [SerializeField]
    private float m_speed = 2.0f;
    [SerializeField]
    private float m_distance_to_stop = 0.5f;

    private float m_distance_to_stop_sqr = 0.0f;
    private Transform m_current_waypoint = null;
    void Start()
    {
        transform.position = m_waypoint_1.position;
        m_current_waypoint = m_waypoint_1;
        m_distance_to_stop_sqr = m_distance_to_stop * m_distance_to_stop;
    }

    void Update()
    {
        Vector3 dir_from_me_to_waypoint = m_current_waypoint.position - transform.position;
        float distance = dir_from_me_to_waypoint.sqrMagnitude;

        if (distance <= m_distance_to_stop_sqr)
        {
            m_current_waypoint = m_current_waypoint == m_waypoint_1 ? m_waypoint_2 : m_waypoint_1;
        }
        else
        {
            transform.position += dir_from_me_to_waypoint.normalized * m_speed * Time.deltaTime;
        }
    }
}
