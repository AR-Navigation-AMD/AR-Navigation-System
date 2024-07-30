using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ript : MonoBehaviour
{
    public float[] Lat; // Target latitude
    public float[] Lon; // Target longitude
    internal int PointCounter = 0; // the number of points that we want to check in GPSProcess
    private double distance;
    private Vector3 TargetPosition;
    private Vector3 OriginalPosition;
    public float Radius = 5f; // Range within which the target is considered reached
    public float TimeUpdate = 3f; // Time interval for updating the GPS coordinates in seconds
    private string newlat;
    private string newlon;
    float lat;
    float lon;
    public GameObject[] TargetPopUp; // The popup UI pages when user reaches the target
    public bool TargetPopUpOneTime = false; // Corrected type from 'boolean' to 'bool'
    public UnityEvent EventStartGPS;// will work when the GPS starts to work
    public UnityEvent EventReachGPSPoint;//works when user reaches GPS point
    public UnityEvent EventOutGPSPointRange;// works when user is out og GPS range
    public GameObject NoGPSPopUp;// when GPS is off in users device
    public bool NoGPSPopUpOneTime = false;


    private void Start() // Corrected 'start' to 'Start'
    {
        // Start the GPS connection and try to connect to the satellite
        Input.location.Start();
        StartCoroutine(GPSProcess()); // Corrected 'startCoroutine' to 'StartCoroutine'
        if(EventStartGPS != null){
            EventStartGPS.Invoke();
        }
        
    }

    public IEnumerator GPSProcess()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeUpdate);
            if (Input.location.isEnabledByUser)
            {
                Input.location.Start();

                lat = Input.location.lastData.latitude;
                newlat = lat.ToString();

                lon = Input.location.lastData.longitude;
                newlon = lon.ToString();

                Calc(Lat[PointCounter], Lon[PointCounter], lat, lon);
            }
            if(Input.location.isEnabledByUser == false && NoGPSPopUpOneTime == false){
                NoGPSPopUp.SetActive(true);
                TargetPopUpOneTime = true;
            }
        }
    }

    public void Calc(float lat1, float lon1, float lat2, float lon2)
    {
        var R = 6378.137f; // Radius of earth in km, changed to float
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) + Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) * Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        distance = R * c;
        distance = distance * 1000f;
        float distanceFloat = (float)distance;
        TargetPosition = OriginalPosition - new Vector3(0, 0, distanceFloat * 12);

        if (distance < Radius)
        {
            if (!TargetPopUpOneTime) // Simplified the check
            {
                for(int i=0; i<TargetPopUp.Length; i++) {
                    TargetPopUp[i].SetActive(false);
                }

                TargetPopUp[PointCounter].SetActive(true);
                if(EventReachGPSPoint != null){
                    EventReachGPSPoint.Invoke();
                }
                
            }
        }
        else // Ensured the popup hides when outside the radius
        {
            for(int i=0; i<TargetPopUp.Length; i++) {
                    TargetPopUp[i].SetActive(false);
                }
            //TargetPopUp[PointCounter].SetActive(false);
            PointCounter++;

            if(PointCounter==Lat.Length){
                PointCounter=0;
            }
            if(EventOutGPSPointRange != null){
                EventOutGPSPointRange.Invoke();
            }
            
        }
    }

    public void HideTargetPopUp()
    {
        TargetPopUp[PointCounter].SetActive(false);
        TargetPopUpOneTime = true;
    }

     public void HideNoGPSPopUp()
    {
        NoGPSPopUp.SetActive(false);
       
    }
}
