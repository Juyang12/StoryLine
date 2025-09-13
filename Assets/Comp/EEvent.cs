using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Story
{
    public class Event : MonoBehaviour
    {
        [SerializeField] public int[] IDs;
        private Dictionary<int, bool> IDCheckList;// 用于检查ID是否被触发过


        // Start is called before the first frame update
        void Start()
        {
            IDCheckList = new Dictionary<int, bool>();
            foreach (var item in IDs)
            {
                IDCheckList[item] = false;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnBeenPoped()
        {

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
                if (item == id)
                {
                    IDCheckList[id] = true;
                    return AllChecked();
                }
            }
            return false;
        }
    }
}
