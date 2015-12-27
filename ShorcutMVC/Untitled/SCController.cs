using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Leap;

namespace ShorcutMVC.Untitled
{
	public class SCController
	{
		private SCView scv;
		private SCItem[] sci;
		private SCController scController;
   
         
		public SCController()
		{
            sci = new SCItem[201];
        }

		~SCController()
		{}

		public void addItem(int itemId, int groupId, String path)
		{
			if(SCItem.itemNum < SCItem.maxItemNum)
            {
                Console.WriteLine("3");
                sci[SCItem.itemNum] = new SCItem(itemId, groupId, path);
            
            }else{
                Console.WriteLine("Can't add the Item!");
            }
		}

        public void createView(int mode, bool IsLeftSide)
        {
            scv = new SCView(sci, IsLeftSide, mode);
        }

        public void setViewItem()
        {
            
            scv.AllocateItem();
        }

		public void setBtnSize(float btnSize)
		{
			scv.setBtnSize(btnSize);
		}

		public void setTextSize(int textSize)
		{
            scv.setTextSize(textSize);
		}

		public void setTextColor(Color color)
		{
            scv.setTextColor(color);
		}

        public void onDraw(HandController controller, GameObject camera)
		{
			scv.onDraw(controller, camera);
		}

        public void setPosition(float x, float y)
        {
            scv.setPosition(x, y);
        }
	}
}
