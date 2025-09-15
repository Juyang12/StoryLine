using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Story
{
    public class EEvent_Battle : Event
    {
        /// <summary>
        /// 下面为自动脚本，一般情况不需要调用下面的函数
        /// </summary>
        private Dictionary<int, bool> IDCheckList;// 用于检查ID是否被触发过

        void Start()
        {
            IDCheckList = new Dictionary<int, bool>();
            foreach (var item in IDs)
            {
                IDCheckList[item.ID] = false;
            }
        }

        public override EventDataSet[] OnFront() 
        {
            /*
             * 需要开启一场战斗
             */
            return IDs;//ids
        }

        public override void OnBeenPoped()
        {
            //删除obj
            Destroy(gameObject, 0.2f);//0.2s延迟删除
        }

        public override bool AllChecked()
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

        public override bool CheckID(int id, string name)
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