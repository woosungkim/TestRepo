using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Leap;

namespace ShorcutMVC.Untitled
{
	public class SCItem
	{
		private int itemId;
		public static int maxItemNum = 200;
        public static int itemNum = 0;
		private int groupId;
		private String gameObjectName;
        
		public SCItem()
		{}

        public SCItem(int itemId, int groupId, String gameObjectName)
        {
            if(ItemNum<maxItemNum)
            {
                this.itemId = itemId;
                this.groupId = groupId;
                this.gameObjectName = gameObjectName;
                itemNum++;
            }
        }

		~SCItem()
		{}

		public String gameObjectName
		{
			get
			{ return gameObjectName; }
			set
			{ gameObjectName = value; }
		}

		public int itemId
		{
			get
			{ return itemId; }
			set
			{ itemId = value; }
		}

		public int groupId
		{
			get
			{ return groupId; }
			set
			{ groupId = value; }
		}
	}
}
