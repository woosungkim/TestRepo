using UnityEngine;
using System.Collections;
using Leap;
namespace ShortCutItem
{
    public class SCItem : MonoBehaviour
    {
        static int numItem = 0;
        private int groupId;
        private int itemId;
        private string itemName;

        public SCItem()
        {
            this.groupId = 0;
            this.itemId = 0;
            string itemName="";
            numItem++;
        }

        public SCItem(int groupid, int itemid, string itemName)
        {
            this.groupId = groupid;
            this.itemId = itemid;
            this.itemName = itemName;
            numItem++;
        }

        public void setGroupId(int groupid)
        {
            this.groupId = groupid;  
        }

        public void setItemId(int itemid)
        {
            this.itemId = itemid;
        }

        public void setItemName(string itemName)
        {
            this.item = itemName;
        }

        public int getGroupId()
        {
            return this.groupId;
        }

        public int getId()
        {
            return this.itemId;
        }

        public string getItemName()
        {
            return this.itemName;
        }

        ~SCItem() { }

    }
}