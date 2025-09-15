using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Story {

    [System.Serializable]
    public class EventDataSet
    {
        public int ID;
        public string Name;

        public bool Equals(EventDataSet other)
        {
            if (other == null) return false;
            return ID == other.ID && Name == other.Name;
        }

        // Object.Equals方法
        public override bool Equals(object obj)
        {
            return Equals(obj as EventDataSet);
        }

        // GetHashCode方法
        public override int GetHashCode()
        {
            unchecked // 允许整数溢出
            {
                int hash = 17;
                hash = hash * 23 + ID.GetHashCode();
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                return hash;
            }
        }
    }
}