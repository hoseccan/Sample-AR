using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameLogic : MonoBehaviour
{
    [HideInInspector] public bool isModelExist;
    public ARSession session;
    public ARPlaneManager planeManager;
    public GameObject modelToPlace;
    GameObject existModels;

    void Update()
    {
        foreach (ARPlane plane in planeManager.trackables)
        {
            if (!isModelExist)
            {
                Vector3 center = plane.center;
                existModels = Instantiate(modelToPlace, center, Quaternion.identity);
                isModelExist = true;
                planeManager.enabled = false;
            }
        }
    }
    public void ResetScenes()
    {
        Destroy(existModels);
        session.Reset();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
