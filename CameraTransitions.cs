using UnityEngine;
using System.Collections;

public class CameraTransitions : MonoBehaviour {

	// 구체적인 singleton으로 개선 요망
	static CameraTransitions instance = null;

    // singleton방식의 가장 기본적인 형식으로 만듦.
    public static CameraTransitions GetInstance()
    {
        if(!instance)
        {
            instance = (CameraTransitions)FindObjectOfType(typeof(CameraTransitions));
            if (!instance)
                Debug.LogError("There needs to be one active CameraTransitions script on GameObject in your scene");
        }
        return instance;
    }

	enum CameraState : int { AR, VR }; 
	CameraState cameraState;
	GameObject transitionsSpace;


	// Use this for initialization
	void Start () {
		transitionsSpace = GameObject.Find ("TransitionsSpace");
		cameraState = CameraState.VR;
	}

	void Awake() {
		instance = this;
	}
	
	void OnGUI() {
		if (cameraState == CameraState.AR)
			transitionsSpace.SetActive (true);
		else if (cameraState == CameraState.VR)
			transitionsSpace.SetActive (false);
	}

	public void changeCameraToAR() {
		cameraState = CameraState.AR;
	}
	public void changeCameraToVR() {
		cameraState = CameraState.VR;
	}
}
