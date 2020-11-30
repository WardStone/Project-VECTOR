using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GetObjectVectorScript : MonoBehaviour
    {
        private bool mouseDown = false;
        public LayerMask interactLayer;
        public Vector2 targetWorldVector;
 
        void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            mouseDown = Input.GetMouseButtonDown(0);

            if (mouseDown)
            {
                GetVector();
            }
        }

        private void GetVector()
        {
            //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f, interactLayer);

            if (hit)
            {
                if (hit.collider.gameObject.tag == "GetVector")
                {
                    Rigidbody2D hitRb = hit.collider.gameObject.GetComponent<Rigidbody2D>();

                    targetWorldVector = new Vector2(hitRb.velocity.x, hitRb.velocity.y).normalized;
                }
            }
        }

    }

}

