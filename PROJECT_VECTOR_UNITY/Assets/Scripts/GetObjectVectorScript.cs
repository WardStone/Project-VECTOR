using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GetObjectVectorScript : MonoBehaviour
    {
        [SerializeField] private bool mouseDown = false;
        public LayerMask interactLayer;
 
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
            RaycastHit2D hit;

            //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            bool asHit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);


            if (asHit)
            {
                Debug.Log("raycast as hit");
                if (hit.collider.gameObject.tag == "GetVector")
                {
                    Rigidbody2D hitRb = hit.collider.gameObject.GetComponent<Rigidbody2D>();

                    Debug.Log(hitRb.velocity.x + " : " + hitRb.velocity.y);
                }
            }
        }

    }

}

