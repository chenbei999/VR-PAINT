using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UIBase
{
    public class UIList : MonoBehaviour
    {
        public Transform parent;
        public GameObject itemTemp;

        private List<UIItem> itemList = new List<UIItem>();

        private void Awake()
        {
            itemTemp.SetActive(false);
        }

        // update list
        public void UpdateList<T>(List<T> list)
        {
            int ui_count = itemList.Count;
            int data_count = list.Count;
            
            UIItem item;
            for (int i = 0; i < data_count; i++)
            {
                item = i < ui_count ? itemList[i] : AddItem();
                EnableActive(item.gameObject, true);
                item.OnUpdateItem(i, list[i]);
            }

            for (int i = data_count; i < ui_count; i++)
            {
                EnableActive(itemList[i].gameObject, false);
            }
        }

        // create gameObject and add item
        private UIItem AddItem()
        {
            GameObject go = GameObject.Instantiate(itemTemp, parent);
            UIItem item = go.GetComponent<UIItem>();
            itemList.Add(item);
            return item;
        }

        // set gameObject active
        private void EnableActive(GameObject go, bool enable)
        {
            if (go != null && go.activeSelf != enable)
            {
                go.SetActive(enable);
            }
        }
    }
}