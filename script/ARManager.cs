using UnityEngine;
using Vuforia;

public class ARManager : MonoBehaviour
{
    // Public variables for AR Camera and Object
    public Camera arCamera;
    public GameObject objectToPlace;
    
    // Reference to Vuforia components
    private PlaneFinderBehaviour planeFinderBehaviour;
    private ContentPositioningBehaviour contentPositioningBehaviour;
    
    // Object placement variables
    private GameObject placementAnchor;

    void Start()
    {
        // Initialize Vuforia
        InitializeVuforia();
        
        // Ensure AR Camera is properly set up
        SetupARCamera();
    }

    void InitializeVuforia()
    {
        // Get Vuforia's PlaneFinderBehaviour if applicable
        planeFinderBehaviour = arCamera.GetComponent<PlaneFinderBehaviour>();
        if (planeFinderBehaviour != null)
        {
            planeFinderBehaviour.enabled = true; // Enable PlaneFinder
        }
        else
        {
            Debug.LogWarning("PlaneFinderBehaviour component not found on AR Camera.");
        }

        // Check for ContentPositioningBehaviour
        contentPositioningBehaviour = arCamera.GetComponent<ContentPositioningBehaviour>();
        if (contentPositioningBehaviour == null)
        {
            Debug.LogWarning("ContentPositioningBehaviour component not found on AR Camera.");
        }
    }

    void SetupARCamera()
    {
        if (arCamera == null)
        {
            Debug.LogError("AR Camera is not assigned.");
        }
        // Ensure AR Camera has VuforiaBehaviour
        if (arCamera.GetComponent<VuforiaBehaviour>() == null)
        {
            Debug.LogError("AR Camera is not properly set up with Vuforia.");
        }
    }

    public void PlaceObject(Vector3 position)
    {
        if (objectToPlace == null)
        {
            Debug.LogError("Object to place is not assigned.");
            return;
        }

        // Place the object at the given position
        objectToPlace.transform.position = position;
        objectToPlace.SetActive(true);
    }

    public void HideObject()
    {
        if (objectToPlace != null)
        {
            objectToPlace.SetActive(false);
        }
    }
}
