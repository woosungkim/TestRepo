using UnityEngine;
using UnityEngine.UI;
using Leap;
using System.Collections;
using ShorcutMVC.Untitled;

public class mainScript : MonoBehaviour
{
    public SCController scc;
    public HandController handcontroller;
    public GameObject trackedCamera;
    public bool IsLeftSide;
    public int mode;
    public float x;
    public float y;
    public float btnSize;

    [HideInInspector]
    public GameObject itemGroup;
    
    void Start()
    {
        itemGroup = new GameObject();
       
        scc = new SCController();
        scc.addItem(0, 0, "DemoToggleButton");   
        scc.addItem(1, 0, "DemoToggleButton");
        scc.addItem(2, 0, "DemoToggleButton");      
        scc.createView(mode, IsLeftSide);
        scc.setBtnSize(btnSize);
        scc.setTextSize(30);
        scc.setPosition(x, y);
        scc.setTextColor(Color.red);
        scc.setViewItem();
      
    }
    
    void FixedUpdate()
    {
        scc.onDraw(handcontroller,trackedCamera);
    }
}

