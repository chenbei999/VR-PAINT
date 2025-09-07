using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

namespace UIBase
{
    public class UIItem : MonoBehaviour
    {
        public UIList list;

        public virtual void OnUpdateItem<T>(int index, T itemData)
        {
            
        }
    }
}