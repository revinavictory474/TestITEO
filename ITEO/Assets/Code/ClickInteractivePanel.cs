using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static ITEO.MouseOrbitImproved;

namespace ITEO
{
    public class ClickInteractivePanel : MonoBehaviour
    {
        public GameObject thisGameObj;
        public Transform cameraTransform;
        public GameObject uiPanel;
        public GameObject bgFill;
        private float speed = 0.1f;


        private void Start()
        {
            Time.timeScale = 1;
        }


        public void OnMouseUp()
        {
            Debug.Log("Tap");
            TransformCamera();
            ActivePanel();
        }

        private void TransformCamera()
        {
            cameraTransform.transform.position = Vector3.Lerp(cameraTransform.transform.position, thisGameObj.transform.position, speed);
        }

        public void ActivePanel()
        {
            uiPanel.SetActive(true);
            bgFill.SetActive(true);
            mouseOrbit.isPause = false;
            mouseOrbit.DemoPause();

        }
        public void DeactivePanel()
        {
            uiPanel.SetActive(false);
            bgFill.SetActive(false);
            mouseOrbit.isPause = true;
            mouseOrbit.DemoPause();
        }

    }
}