using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Story
{
    public class Event : MonoBehaviour
    {
        public EventDataSet[] IDs;//********需要在编辑器界面赋值

        /// <summary>
        /// 下面为自动脚本，一般情况不需要调用下面的函数
        /// </summary>
        private Dictionary<EventDataSet, bool> IDCheckList;// 用于检查ID是否被触发过

        void Start()
        {
            IDCheckList = new Dictionary<EventDataSet, bool>();
            foreach (var item in IDs)
            {
                IDCheckList[item] = false; // Use item directly as the key
            }
        }

        public virtual EventDataSet[] OnFront()
        {
            return IDs;//ids
        }

        public virtual void OnBeenPoped()
        {
            //删除obj
            Destroy(gameObject, 0.2f);//0.2s延迟删除
        }

        public virtual bool AllChecked()
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

        public virtual bool CheckID(int id,string name)
        {
            foreach (var item in IDs)
            {
                if (item.ID == id && item.Name == name)
                {
                    IDCheckList[item] = true;
                    return AllChecked();
                }
            }
            return false;
        }
    }
}
