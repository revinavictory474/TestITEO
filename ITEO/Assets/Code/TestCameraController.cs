using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private int delayTime = 1;
    private float time;
    private GameObject target;
    private bool zoomStatus;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ScriptedCamera());
    }

    void Update()
    {
        CameraZoomStatus(zoomStatus);
    }

    private void CameraZoomStatus(bool status)
    {
        if (!status) return;
        time += 0.001f * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, time);
    }


    private IEnumerator ScriptedCamera()
    {
        yield return new WaitForSeconds(delayTime);

        zoomStatus = true;
    }
}
