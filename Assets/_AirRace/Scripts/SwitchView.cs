using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class SwitchView : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject cockpitCamera;
	[SerializeField] private GameObject tailCamera;
	[SerializeField] private GameObject noseCamera;


	// Start is called before the first frame update
	void Start()
    {
        Switch2Cockpit(); // cockpit view by default

	}

    public void Switch2Cockpit()
    {
		tailCamera.SetActive(false);
		noseCamera.SetActive(false);
		cockpitCamera.SetActive(true);
		player.GetComponent<XROrigin>().Camera = cockpitCamera.GetComponent<Camera>();

	}

	public void Switch2Tail()
    {
		cockpitCamera.SetActive(false); 
		noseCamera.SetActive(false);
		tailCamera.SetActive(true);
		player.GetComponent<XROrigin>().Camera = tailCamera.GetComponent<Camera>();

	}

	public void Switch2Nose()
    {
		tailCamera.SetActive(false);
		cockpitCamera.SetActive(false);
		noseCamera.SetActive(true);
		player.GetComponent<XROrigin>().Camera = noseCamera.GetComponent<Camera>();

	}
}
