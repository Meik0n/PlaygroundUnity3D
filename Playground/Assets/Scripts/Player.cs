using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float m_HP = 10.0f;
    public float HP
    {
        get => m_HP;

        set
        {
            m_HP = value;
        }
    }
    private float m_max_health;
    private int m_coins = 0;
    public int Coins
    {
        get => m_coins;

        set
        {
            m_coins = value;
        }
    }

    [SerializeField]
    private Transform m_spawn_point = null;

    [SerializeField]
    private Text m_hp_text = null;
    [SerializeField]
    private Text m_coins_text = null;
    void Start()
    {
        m_max_health = m_HP;
    }


    void Update()
    {
        m_hp_text.text = m_HP.ToString();
        m_coins_text.text = m_coins.ToString();
    }

    public void Activate_Poison()
    {
        StartCoroutine("Poison");
    }

    public void Desactivate_Poison()
    {
        StopCoroutine("Poison");
    }

    private IEnumerator Poison()
    {
        while (true)
        {
            --HP;

            if (HP <= 0)
            {
                CharacterController char_controller = GetComponent<CharacterController>();

                if (char_controller)
                {
                    char_controller.enabled = false;
                }

                transform.position = m_spawn_point.position;

                if (char_controller)
                {
                    char_controller.enabled = true;
                }

                m_HP = 10;

                yield break;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
    public void Activate_Regen()
    {
        StartCoroutine("Regen_HP");
    }

    public void Desactivate_Regen()
    {
        StopCoroutine("Regen_HP");
    }
    private IEnumerator Regen_HP()
    {
        while (true)
        {
            ++HP;
            yield return new WaitForSeconds(1.0f);
            if (HP == 10)
            {
                yield break;
            }
        }

    }
}
