using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    // [SerializeField]
    // CinemachineFreeLook cm_freeLook1;
    // [SerializeField]
    // CinemachineFreeLook cm_freeLook2;

    [SerializeField]
    List<CinemachineFreeLook> cm_freeLookCameras;

    public int activeCamera = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetButtonDown("Space")) {
        //     if(cm_freeLook1.gameObject.activeSelf) {
        //         cm_freeLook1.gameObject.SetActive(false);
        //         cm_freeLook2.gameObject.SetActive(true);
        //     } else {
        //         cm_freeLook1.gameObject.SetActive(true);
        //         cm_freeLook2.gameObject.SetActive(false);
        //     }
        // }

        if (Input.GetButtonDown("Space")) {
            cm_freeLookCameras[activeCamera].gameObject.SetActive(false);
            activeCamera++;
            if(activeCamera == cm_freeLookCameras.Count) {
                activeCamera = 0;
            }

            cm_freeLookCameras[activeCamera].gameObject.SetActive(true);
        }
    }
}
