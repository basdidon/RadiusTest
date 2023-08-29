using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    // Enemy
    private Transform m_Target;

    protected override void Start()
    {
        base.Start();

        speed = 2.7f;
    }
}