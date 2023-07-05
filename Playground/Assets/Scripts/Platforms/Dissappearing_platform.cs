using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissappearing_platform : MonoBehaviour
{
    [SerializeField]
    private Collider m_button_collider;
    [SerializeField]
    private float m_time_to_reappear = 10.0f;

    private bool m_enable = false;
    private Collider m_collider = null;
    private Renderer m_renderer = null;

    void Start()
    {
        m_collider = GetComponent<Collider>();
        m_renderer = GetComponent<Renderer>();

        m_collider.enabled = false;
        m_renderer.enabled = false;
        m_enable = false;
    }

    public void StartVanish()
    {
        StartCoroutine(Vanish());
    }

    private IEnumerator Vanish()
    {
        if (!m_enable)
        {
            m_collider.enabled = true;
            m_renderer.enabled = true;
            m_enable = true;
            yield return new WaitForSeconds(m_time_to_reappear);
        }
        m_collider.enabled = false;
        m_renderer.enabled = false;
        m_enable = false;
        m_button_collider.enabled = true;
        yield return null;
    }
}
