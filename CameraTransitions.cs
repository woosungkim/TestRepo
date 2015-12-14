using UnityEngine;
using System.Collections;

public class CameraTransitions : MonoBehaviour {

	// 구체적인 singleton으로 개선 요망
	static CameraTransitions _instance = null;

    // 인터넷 예제를 참고하여서 클래스가 스스로 gameobject를 만들고,
    // 해당 싱글톤 인스턴스를 첨부하도록 했다.
    public static CameraTransitions instance
    {
        get
        {
            if(!_instance)
            {
                _instance = (CameraTransitions)FindObjectOfType(typeof(CameraTransitions));
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "CameraTransitions Container";
                    _instance = container.AddComponent(typeof(CameraTransitions)) as CameraTransitions;
                }
                
            }

            return _instance;
        }

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
		//_instance = this;
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
