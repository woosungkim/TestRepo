using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ShortCutAdapter;
using ShortCutItem;
using Leap;

namespace ShortCutView
{
    public class SCView : MonoBehaviour
    {
        
        private SCAdapter scAdapter;
        private GameObject gobject;
        private GameObject subobject;
        private float btnSize;
        private int num;
        private Color textColor;
        private int textSize;
        private Color backgrooundColor;
        private int transparency;
        private int status;
        private string name;
        private double startAngle;
        private string[] itemName;
        private int itemNum;

     

        public SCView(SCAdapter sa)
        {
            this.scAdapter = sa;
            this.itemName = sa.getItemName();
            itemNum = itemName.Length;
        }

        private void init() //초기화 및 이름 설정
        {
            name = "shortcut(" + scAdapter.getSize() + ")";
            gobject = GameObject.Find("ShortCut");
            gobject.GetComponent<main>().name = name;
            subobject = GameObject.Find(name);
            
            //객체들을 찾아내고 비활성 상태로 만든다.
            //이건 여러 종류의 숏컷을 만들어 놓고 일단 비활성 시킨듯.
            for (int i = 1; i <= 3; i++)
            {
                string tmp = "shortcut(" + i + ")";
                GameObject tmpob = GameObject.Find(tmp);
                tmpob.active = false;        
            }
            subobject.active = true;

            for (int i = 0; i < scAdapter.getSize(); i++ )
            {
                GameObject ob = GameObject.Find(scAdapter.getGameObjectName[i]);
                ob.GetComponent<Text>().text = scAdapter.getItem(i).getItemName();
            }
                subobject.active = false;      
        }

        public void setBtnSize(float btnSize) //버튼크기
        {
            subobject.active = true;
            this.btnSize = btnSize;
            subobject.transform.localScale = new Vector3(btnSize, btnSize, btnSize);
            subobject.active = false;
        }

        public void setObject(int num) //따라다닐 객체 0은 카메라 1은 손
        {
            subobject.active = true;
            this.num = num;
            gobject.GetComponent<main>().num = num;
            subobject.active = false;
        }

        public void setTextSize(int textSize)//텍스트 크기
        {
            subobject.active = true;
            this.textSize = textSize;
            for (int i = 0; i < scAdapter.getSize(); i++)
            {
                GameObject ob = GameObject.Find(scAdapter.getGameObjectName[i]);
                ob.GetComponent<Text>().fontSize = textSize;
            }
            subobject.active = false;
        }

        public void setTextColor(Color textColor)//텍스트 색
        {
            subobject.active = true;
            this.textColor = textColor;
            for (int i = 0; i < scAdapter.getSize(); i++)
            {
                GameObject ob = GameObject.Find(scAdapter.getGameObjectName[i]);
                ob.GetComponent<Text>().color = textColor;
            }
            subobject.active = false;
        }

        
        public void setBackGrooundColor(Color backgrooundColor)//배경 색
        {
            subobject.active = true;
            this.backgrooundColor = backgrooundColor;
            for (int i = 1; i <= scAdapter.getSize(); i++)
            {
                GameObject ob = GameObject.Find("Button_Plane_Mid(" + scAdapter.getSize() + "-" + i + ")");
                ob.GetComponent<MeshRenderer>();
            }
            subobject.active = false;
        }
        

        public void setTransparency(int transparency)//투명도
        {
            this.transparency = transparency;           
        }

        public void setStatus(int status)//상태
        {
            this.status = status;
        }

        public void setStartAngle(double startAngle)//시작각
        {
            this.startAngle = startAngle;
        }

        public void offDraw()
        {
            subobject.active = false;
        }
        public void onDraw()
        {
            subobject.active = true;
        }
    }
}
