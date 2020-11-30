using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ApplyTargetVectorScript : MonoBehaviour
    {
        private Vector2 impulseVector;
        [SerializeField] private float impulseForce;
        public LayerMask applyForceLayer;
        private bool isInspectorMode;

        public float forceScale = 0.2f;

        [Header("Impulse Force Limits")]
        public float minImpulseForce = 1f;
        public float maxImpulseForce = 10f;

        private RaycastHit2D hit;

        private void Start()
        {
            impulseForce = minImpulseForce;
        }

        private void Update()
        {
            //Check if the player is in inspector mode.
            isInspectorMode = GetComponent<InspectorModeScript>().isInpectorMode;

            GetInput();
        }

        private void GetInput()
        {
            bool mouseDown = Input.GetMouseButtonDown(1);

            if (mouseDown && !isInspectorMode)
            {
                TargetObject();
            }

            bool mouseHold = Input.GetMouseButton(1);

            if (mouseHold && !isInspectorMode)
            {
                ChargeForce();
            }


            bool mouseUp = Input.GetMouseButtonUp(1);

            if (mouseUp && !isInspectorMode)
            {
                ApplyVector();
            }
        }

        private void TargetObject()
        {
            //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f, applyForceLayer);
        }

        private void ChargeForce()
        {
            if (hit)
            {
                impulseForce += forceScale * Time.deltaTime;

                if (impulseForce > maxImpulseForce)
                    impulseForce = maxImpulseForce;
            }
        }


        private void ApplyVector()
        {
            if (hit)
            {
                Rigidbody2D hitRb = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                impulseVector = GetComponent<GetObjectVectorScript>().targetWorldVector;

                hitRb.AddForce(impulseVector * impulseForce, ForceMode2D.Impulse);

                //reset les vecteurs en stock après utilisation
                GetComponent<GetObjectVectorScript>().targetWorldVector = Vector2.zero;
                impulseVector = Vector2.zero;

                //Reset la force de l'impulse
                impulseForce = minImpulseForce;
            }
        }



    }
}

