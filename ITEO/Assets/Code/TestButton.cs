using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestButton : MonoBehaviour
{
    public GameObject thisGameObj;
    public Transform camera;
    public GameObject uiPanel;
    private float speed = 0.03f;
    public Vector3 offset;


    public void OnMouseUp()
    {
        Debug.Log("Tap");
        TransformCamera();
        ActivePanel();
    }

    private void TransformCamera()
    {
        //camera.position = Vector3.Lerp(transform.position, thisGameObj.transform.position + offset, speed);
        camera.position = Vector3.Lerp(camera.transform.position, thisGameObj.transform.position, speed);
        
    }

    private void ActivePanel()
    {
        uiPanel.SetActive(true);
    }
     private void DeactivePanel()
    {
        uiPanel.SetActive(false);
    }
}
