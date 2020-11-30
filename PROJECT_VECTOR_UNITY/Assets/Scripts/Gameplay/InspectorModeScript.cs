using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InspectorModeScript : MonoBehaviour
    {
        public bool isInpectorMode;
        [Range(0, 1)] public float slowValue;

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            bool spaceDown = Input.GetKeyDown(KeyCode.Space);

            if (spaceDown)
            {
                if (!isInpectorMode)
                {
                    isInpectorMode = true;

                    EnterInspectorMod();
                }
                else
                {
                    isInpectorMode = false;

                    ExitInspectorMod();
                }
            }
        }

        private void EnterInspectorMod()
        {
            //Slow time
            Time.timeScale = 1 - slowValue;
        }

        private void ExitInspectorMod()
        {
            //revert time to normal
            Time.timeScale = 1;
        }
    }
}

