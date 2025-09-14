using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Story
{
    

    public class Event : MonoBehaviour
    {
        public EventDataSet[] IDs;
        private Dictionary<int, bool> IDCheckList;// 用于检查ID是否被触发过


        // Start is called before the first frame update
        void Start()
        {
            IDCheckList = new Dictionary<int, bool>();
            foreach (var item in IDs)
            {
                IDCheckList[item.ID] = false;
            }
        }

        public EventDataSet[] OnFront()
        {
            return IDs;//ids
        }

        public void OnBeenPoped()
        {
            //删除obj
            Destroy(gameObject, 0.2f);//0.2s延迟删除
        }

        private bool AllChecked()
        {
            foreach (var item in IDCheckList)
            {
                if (!item.Value)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckID(int id)
        {
            foreach (var item in IDs)
            {
                if (item.ID == id)
                {
                    IDCheckList[id] = true;
                    return AllChecked();
                }
            }
            return false;
        }
    }
}
