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
		private SCItem sci[];
		private SCController scController;
   
         
		public SCController()
		{
            scController = new SCController();
            sci = new SCItem[201];
            
		}

		~SCController()
		{}

		public void addItem(int ItemId, int groupId, String path)
		{
			if(SCItem.itemNum < SCItem.maxItemNum)
            {
                sci[SCItem.itemNum] = new SCItem(itemId, ItemName, path);
            
            }else{
                Console.WriteLine("Can't add the Item!");
            }
		}

        public void setViewItem(int mode, bool IsLeftSide)
        {
            scv = new SCView(sci, IsLeftSide, mode );
            scv.AllocateItem();
        }

		public void setBtnSize(float btnSize)
		{
			scv.btnSize = btnsize;
		}

		public void setTextSize(int textSize)
		{
			scv.textSize = textSize;
		}

		public void setTextColor(Color color)
		{
			scv.textColor = color;
		}

        public void onDraw()
		{
			scv.onDraw();
		}

	}
}
