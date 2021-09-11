using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace ITEO
{
    public class PauseRotation : MonoBehaviour
    {
        public Transform targetTransform;
        private float timeLeft = 10f;

        void Update()
        {
            if (Input.GetAxis("Mouse X") == 0 && (Input.GetAxis("Mouse Y") == 0))
            {
                    timeLeft -= Time.deltaTime;

                if (timeLeft < 0)
                {
                    RotateCamera();
                }
            }
            else
            {
                timeLeft = 10f;
            }
        }

        private void RotateCamera()
        {
            transform.RotateAround(targetTransform.position, new Vector3(0, 5, 0), 10 * Time.deltaTime);
        }
    }
}