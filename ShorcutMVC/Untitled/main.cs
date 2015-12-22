using UnityEngine;
using UnityEngine.UI;
using Leap;
using System.Collections;

/// <summary>
/// Summary description for Class1
/// </summary>
public class main : MonoBehaviour
{
    public SCController scc;
    public HandController handcontroller;
    public GameObject trackedCamera;
    public bool IsLeftSide;
    public int mode;

    
    void Start()
    {
        scc = new SCController();
        scc.addItem(0, 0, "DemoToggleButton");
        scc.addItem(1, 0, "DemoToggleButton");
        scc.addItem(2, 0, "DemoToggleButton");
        scc.setBtnSize(2f);
        scc.setTextSize(30);
        scc.setTextColor(Color.red);
        scc.setViewItem(mode, IsLeftSide);
    }
    
    void FixedUpdate()
    {
        scc.onDraw();
    }
}

