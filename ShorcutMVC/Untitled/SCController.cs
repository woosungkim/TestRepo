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
        public int mode;

		public SCController()
		{
            scController = new SCController();
            sci = new SCItem[201];
            
		}

		~SCController()
		{}

		public void addItem(int ItemId, String ItemName, String path)
		{
			if(itemIndex < SCItem.maxItemNum)
            {
                sci[itemIndex] = new SCItem(itemId, ItemName, path);
                SCItem.itemNum++;
            }else{
                Console.WriteLine("Can't add the Item!");
            }
		}

        public void setViewItem()
        {
            scv = new SCView(sci, mode);
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
