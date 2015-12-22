using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Leap;

namespace ShorcutMVC.Untitled
{
	public class SCView
	{
        
		private SCController scController = null;
        public GameObject trakedCamera;
        public HandController handcontoller;
		public bool IsLeftSide;
		private SCItem scItem;
		private float btnSize;
		private Color textColor;
		private int textSize;
		private Frame frame;
		private Finger finger;
		private FingerList fingerlist;
		private Vector3 _initPos;
		private Vector3 _nowPos;
		public Controller controller;
		private Arm arm;
		private GameObject[] itemView;
        private int mode;

		public SCView(){}

		public SCView(SCItem[] scItem, int mode)
		{
            this.scItem = scItem;
            this.mode = mode;
            controller = new Controller();
            _initPos = transform.position;
		}

		~SCView()
		{}

		public float btnSize
		{
			get{ return btnSize; }
			set{ btnSize = value; }
		}

		public Color textColor
		{
			get{ return textColor; }
			set{ textColor = value; }
		}

		public int textSize
		{
			get{ return textSize; }
			set{ textSize = value; }
		}

		private void AllocateItem()
		{
            for(int i = 0; i<SCItem.itemNum; i++)
            {
                GameObject prefab = Resource.Load(scItem[i].gameObjectName) as GameObject;
                GameObject itemtemp = MonoBehaviour.Instantiate(prefab) as GameObject;
                itemtemp.name = "item" + (i + 1);
                itemtemp.transform.parent = itemView[i].parant;
                itemView[i].active = true;
                itemView[i].transform.localScale = new Vector3(this.btnSize, this.btnSize, this.btnSize);
                itemView[i].GetComponent<Text>().fontSize = textSize;
                itemView[i].GetComponent<Text>().color = textColor;
                itemView[i].active = false;
            }
		}

        public void onDraw()
        {
            if(mode == 0)//카메라 모드
            {
                for(int i = 0; i<SCItem.itemNum; i++)
                {
                    if(i==0)
                    {
                        itemView[i].active = true;
                        itemView[i].transform.position = _inipos + traked.transform.position + new Vector(-3f, 0, 5f);
                    }
                    else
                    {
                        itemView[i].active = true;
                        itemView[i].transform.position = itemView[i - 1].transform.position + Vector3.right;
                    }
                }
            }else if(mode == 1)// 손모드
            {
                frame = controller.Frame(0);
                hand = frame.Hands.Frontmost;

                if(hand.IsValid)
                {
                    if (IsLeftSide)//왼손일 때
                    {
                        if(hand.IsLeft)
                        {
                            arm = hand.Arm;
                            Vector wrist = arm.WristPosition;

                            Vector3 unityPosition = UnityVecotrExtension.ToUnityScaled(wrist, false);

                            Vector3 worldPosition = handController.transform.TransformPoint(unityPosition);

                            for(int i = 0; i<SCItem.itemNum; i++)
                            {
                                if (i == 0)
                                    itemView[i].transform.position = worldPosition + new Vector3(2f, 0, 0);
                                else
                                    itemView[i].transform.position = itemView[i - 1].transform.position + Vector3.right;
                            }
                        }
                    }
                    else//오른손일 때
                    {
                        if (hand.IsRight)
                        {
                            arm = hand.Arm;
                            Vector wrist = arm.WristPosition;

                            Vector3 unityPosition = UnityVecotrExtension.ToUnityScaled(wrist, false);

                            Vector3 worldPosition = handController.transform.TransformPoint(unityPosition);

                            for (int i = 0; i < SCItem.itemNum; i++)
                            {
                                if (i == 0)
                                    itemView[i].transform.position = worldPosition + new Vector3(-6f, 0, 0);
                                else
                                    itemView[i].transform.position = itemView[i - 1].transform.position + Vector3.left;
                            }
                        }
                    }

                }
                
            }
        }

	}
}
