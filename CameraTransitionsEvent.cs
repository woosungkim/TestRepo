using UnityEngine;
using System.Collections;
using Leap;

public class CameraTransitionsEvent : MonoBehaviour {
	CameraTransitions c;
	Controller controller = null; // frame을 받아오기 위함
	bool mode; // true = VR, false = AR
	int ingGestureId; // 이벤트의 아이디.. 일단은 쓰이지 않음
	bool isPlaying; // 동작 중인지 판단하는 flag
	Vector startPoint; // 시작 좌표
	Vector endPoint; // 끝 좌표

	// Use this for initialization
	void Start () {
		Debug.Log ("Start Test");
		controller = new Controller ();

		// 제스처 사용 정의 ..
		if ( !controller.IsGestureEnabled( Gesture.GestureType.TYPE_SWIPE )) {
			controller.EnableGesture (Gesture.GestureType.TYPE_SWIPE);
		}

		mode = true;
		isPlaying = false;
		ingGestureId = -1;

		// 제스처 옵션 설정..
		controller.Config.SetFloat ("Gesture.Swipe.MinVelocity", 200.0f);
		controller.Config.SetFloat ("Gesture.Swipe.MinLength", 100.0f);

		controller.Config.Save (); 
	}

	void Update() {
		Frame frame= controller.Frame ();
		HandList hands = frame.Hands;
		GestureList gestures = frame.Gestures ();

		// 이런 선택지의 부분은 foreach 대신 switch를 사용해서 구현하도록 변경!
		// 이부분도... 뭔가 가능할 거 같은데..
		foreach ( Hand hand in hands ) {
			// 오른손!
			if ( hand.IsRight ) {
				Debug.Log ("Right hand is detecting");
				Debug.Log (" pos : " + hand.PalmPosition);
				FingerList fingers = hand.Fingers;

				// 이부분을.. gesture id로 확정처리 가능하지 않을까..?
				foreach (Gesture gesture in gestures) {
					int id = gesture.Id;

					// 스와입 제스처에 대한 처리..
					if ( gesture.Type == Gesture.GestureType.TYPE_SWIPE ) {
						if ( !isPlaying && gesture.State == Gesture.GestureState.STATE_START ) {
							ingGestureId = id;
							isPlaying = true;
							startPoint = hand.PalmPosition;
							//Debug.Log("start point : " + hand.PalmPosition);
						}

						if ( isPlaying && gesture.State == Gesture.GestureState.STATE_STOP ) {
							isPlaying = false;
							ingGestureId = -1;
							endPoint = hand.PalmPosition;
							//Debug.Log("end point : " + hand.PalmPosition);

							if ( Mathf.Abs( startPoint.x-endPoint.x) < 100 &&
							    Mathf.Abs( startPoint.z-endPoint.z) < 100 &&
							    startPoint.y > endPoint.y &&
							    endPoint.y < 100 ) {// swipe gesture direction constraint
								if ( mode ) {// is vr
									mode = false;
									CameraTransitions.instance.changeCameraToAR();
								}
								else {
									mode = true;
									CameraTransitions.instance.changeCameraToVR();
								}
							}

						}
					}
				}
				
			}
			if ( hand.IsLeft )
				Debug.Log ("Left hand is detecting");
		}
	}

}

