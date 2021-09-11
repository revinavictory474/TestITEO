using UnityEngine;

namespace ITEO
{
    public class MouseOrbitImproved : MonoBehaviour
    {
        [SerializeField] private Transform target;
        internal static MouseOrbitImproved mouseOrbit;
        private float timeLeft = 10f;
        internal float distance = 10.0f;
        internal float xSpeed = 120.0f;
        internal float ySpeed = 120.0f;

        internal float yMinLimit = -5.0f;
        internal float yMaxLimit = 80.0f;

        internal float x = 0.0f;
        internal float y = 0.0f;
        public bool isPause;


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
        void Update()
        {
            
        }


        void LateUpdate()
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

        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360F)
                angle += 360F;
            if (angle > 360F)
                angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }


        private void RotateCamera()
        {
            transform.RotateAround(target.position, new Vector3(0, 5, 0), 10 * Time.deltaTime);
        }

        public void DemoPause()
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