using UnityEngine;
using static ITEO.MouseOrbitImproved;

namespace ITEO
{
    internal class ClickInteractivePanel : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GameObject _thisGameObj;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private GameObject _uiPanel;
        [SerializeField] private GameObject _backgroundFill;
        private float _speed = 0.1f;
        #endregion

        private void Start()
        {
            Time.timeScale = 1;
        }

        private void OnMouseUp()
        {
            TransformCamera();
            ActivePanel();
        }

        private void TransformCamera()
        {
            _cameraTransform.transform.position = Vector3.Lerp(_cameraTransform.transform.position, _thisGameObj.transform.position, _speed);
        }

        private void ActivePanel()
        {
            _uiPanel.SetActive(true);
            _backgroundFill.SetActive(true);
            mouseOrbit.isPause = false;
            mouseOrbit.DemoPause();
        }

        private void DeactivePanel()
        {
            _uiPanel.SetActive(false);
            _backgroundFill.SetActive(false);
            mouseOrbit.isPause = true;
            mouseOrbit.DemoPause();
        }
    }
}