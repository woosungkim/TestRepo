using UnityEngine;
using UnityEngine.UI;
using Leap;
using System.Collections;
using ShortCutAdapter;
using ShortCutItem;
using ShortCutView;


public class main : MonoBehaviour
{
   
    public Vector3 _iniPos;
    public Vector3 _nowPos;
    public Controller controller;
    public  Frame frame;
    public FingerList fingerlist;
    public Finger finger;
    public GameObject shortCutView;
    public GameObject trakedCamera;
    public HandController handContorller;
    public string name;
    public Hand hand;
    public Arm arm;
    public int num;
    public bool IsLeftSide;
    //통합 과정
    private SCItem scitem1;
    private SCItem scitem2;
    private SCItem scitem3;
    private SCAdapter scadapter;
    private SCView scview;
    private GameObject ob;
   

	// Use this for initialization
	void Start () {
        //통합 과정
        scadapter = new SCAdapter();
        scitem1 = new SCItem(0, 1, "개 같은");
        scitem2 = new SCItem(0, 3, "창과");
        scitem3 = new SCItem(0, 2, "극혐");

        scadapter.addItem(scitem1, "Button-Square-Text-OFF(3-1)");
        scadapter.addItem(scitem2, "Button-Square-Text-OFF(3-2)");
        scadapter.addItem(scitem3, "Button-Square-Text-OFF(3-3)");

        scview = new SCView(scadapter);
        scview.setBtnSize(2f);
        scview.setTextSize(30);
        scview.setTextColor(Color.red);
        scview.onDraw();
        //scview.transform.position = go2.transform.position;
        _iniPos = transform.position;
         controller = new Controller();


        /* 이벤트 등록 부분 */
        /*
         * 
         * 
         * 
         */
        
    
	}
	
	// Update is called once per frame
	void Update () {
      
        shortCutView = GameObject.Find(name);
        
        
        if (num == 1)
        {
           frame = controller.Frame(0);
           hand = frame.Hands.Frontmost;
           if(hand.IsValid)
           {
             
               if (IsLeftSide)
               {
                   if (hand.IsLeft)
                   {
                       arm = hand.Arm;
                       Vector wrist = arm.WristPosition;
                       // print(arm.ToString());
                       Vector3 unityPosition = UnityVectorExtension.ToUnityScaled(wrist, false);

                       Vector3 worldPosition = handContorller.transform.TransformPoint(unityPosition);

                       shortCutView.transform.position = worldPosition + new Vector3(2f, 0, 0);
                   }
               }
               else
               {
                   if (hand.IsRight)
                   {
                       arm = hand.Arm;
                       Vector wrist = arm.WristPosition;
                       // print(arm.ToString());
                       Vector3 unityPosition = UnityVectorExtension.ToUnityScaled(wrist, false);

                       Vector3 worldPosition = handContorller.transform.TransformPoint(unityPosition);

                       shortCutView.transform.position = worldPosition + new Vector3(-6f, 0, 0);
                   }
               }
           }
           else
           {
               shortCutView.transform.position = trakedCamera.transform.position;
           }
        }
        else if(num==0)
        {
            shortCutView.active = true;
            shortCutView.transform.position = _iniPos + trakedCamera.transform.position + new Vector3(-3f, 0, 5f);
        }
        
	}
   
}
