using UnityEngine;

namespace ITEO
{
    internal class MouseOrbitImproved : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Transform target;
        internal static MouseOrbitImproved mouseOrbit;
        private float timeLeft = 10f;
        private float distance = 10.0f;
        private float xSpeed = 120.0f;
        private float ySpeed = 120.0f;

        private float yMinLimit = -5.0f;
        private float yMaxLimit = 80.0f;

        private float x = 0.0f;
        private float y = 0.0f;
        internal bool isPause;
        #endregion

        private void Awake()
        {
            if (mouseOrbit == null)
                mouseOrbit = this;
            else
                Destroy(gameObject);
        }

        void Start()
        {
            Vector3 angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
        }

        void LateUpdate()
        {
            RotateCameraWithTheMouse();
            IdleTimerAndSpinStart();
        }

        private void RotateCameraWithTheMouse()
        {
            if (target && Input.GetMouseButton(0) && !isPause)
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);
                Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * negDistance + target.position;

                transform.rotation = rotation;
                transform.position = position;
            }
        }

        private void IdleTimerAndSpinStart()
        {
            if (Input.GetAxis("Mouse X") == 0 && (Input.GetAxis("Mouse Y") == 0))
            {
                timeLeft -= Time.deltaTime;

                if (timeLeft < 0)
                {
                    CameraRotationWhenTimeElapses();
                }
            }
            else
            {
                timeLeft = 10f;
            }
        }

        private static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360F)
                angle += 360F;
            if (angle > 360F)
                angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }

        private void CameraRotationWhenTimeElapses()
        {
            transform.RotateAround(target.position, new Vector3(0, 5, 0), 10 * Time.deltaTime);
        }

        internal void DemoPause()
        {
            if (!isPause)
            {
                isPause = true;
                Time.timeScale = 0;
            }
            else
            {
                isPause = false;
                Time.timeScale = 1;
            }
        }
    }
}