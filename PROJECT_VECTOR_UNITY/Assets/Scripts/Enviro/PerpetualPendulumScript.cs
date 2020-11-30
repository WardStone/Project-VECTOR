using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerpetualPendulumScript : MonoBehaviour
{
    private bool goLeft = true;
    public float force;

    private void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (rigidbody.velocity.x == 0 || rigidbody.velocity.y == 0)
        {
            if (goLeft)
            {
                rigidbody.AddForce(new Vector2(-0.5f, 0.0f) * force, ForceMode2D.Impulse);
                goLeft = false;
            }
            else
            {
                rigidbody.AddForce(new Vector2(0.5f, 0.0f) * force, ForceMode2D.Impulse);
                goLeft = true;
            }
        }
    }
}
