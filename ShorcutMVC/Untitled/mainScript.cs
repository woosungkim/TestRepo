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
    public int numItem;
    public float btnSize;
    public string prefabName;
    public int mode;
    public bool IsLeftSide;
    public bool IsVertical;
    public float position_x;
    public float position_y;

    [HideInInspector]
    public GameObject itemGroup;
    
    void Start()
    {
        itemGroup = new GameObject();
       
        scc = new SCController();
        /*
        scc.addItem(0, 0, prefabName);
        scc.addItem(1, 0, prefabName);
        scc.addItem(2, 0, prefabName);
        */
        for (int i = 0; i < numItem; i++)
        {
            scc.addItem(i, 0, prefabName);
        }
        scc.createView(mode, IsLeftSide, IsVertical);
        scc.setBtnSize(btnSize);
        scc.setTextSize(30);
        scc.setPosition(position_x, position_y);
        scc.setTextColor(Color.red);
        scc.setViewItem();
      
    }
    
    void FixedUpdate()
    {
        scc.onDraw(handcontroller,trackedCamera);
    }
}

