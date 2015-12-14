using UnityEngine;
using System.Collections;
using ShortCutItem;

namespace ShortCutAdapter 
{

    static class Contants
    {
        public const int max = 200;
    }

    public class SCAdapter : MonoBehaviour
    {
        // 이후 그룹별 레이아웃 기능을 구현하기 위해 추가한 배열
        static int[] numItemOfGroup = new int[Contants.max+1];

        private SCItem[] scItem;
        private string[] gameObjectName = new string[Contants.max+1];
        private int numItem = 0;
        

        public SCAdapter(){
            this.scItem = new SCItem[SCItem.numItem];
            this.numItem = 0;
        }

        public void addItem(SCItem item, string GOname)
        {
            numItemOfGroup[item.getGroupId()]++;
            this.scItem[numItem] = item;
            this.gameObjectName[numItem] = GOname();
            numItem++;
        }

        public string[] getGameObjectName()
        {
            return this.gameObjectName;
        }

        public int getSize()
        {
            return this.numItem;
        }

        public bool isEmpty()
        {
            if (numItem == 0)
                return true;
            else
                return false;
        }

        public SCItem getItem(int position)
        {
            return scItem[position];
        }

        public int getItemId(int position) 
        {
            return scItem[position].getId();
        }

        ~SCAdapter() { }
    
    }
    
}                         