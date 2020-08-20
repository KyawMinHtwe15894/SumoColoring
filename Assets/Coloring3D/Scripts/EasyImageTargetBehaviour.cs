/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

namespace EasyAR
{

    public class EasyImageTargetBehaviour : ImageTargetBehaviour
    {
        public GameObject founded;
        public Material newMat;
        public Material oldMat;

        protected override void Awake()
        {
            base.Awake();
            TargetFound += OnTargetFound;
            TargetLost += OnTargetLost;
        }

        protected override void Start()
        {
            base.Start();
            HideObjects(transform);
            gameObject.SetActive(false);
        }

        void HideObjects(Transform trans)
        {
            for (int i = 0; i < trans.childCount; ++i)
                HideObjects(trans.GetChild(i));
            if (transform != trans)
                gameObject.SetActive(true);
        }

        void ShowObjects(Transform trans)
        {
            for (int i = 0; i < trans.childCount; ++i)
                ShowObjects(trans.GetChild(i));
            if (transform != trans)
                gameObject.SetActive(true);
        }

        void OnTargetFound(ImageTargetBaseBehaviour behaviour)
        {
            GameObject.Find("002").GetComponent<MeshRenderer>().material = oldMat;

            ShowObjects(transform);

            Debug.Log("Target found!!");
            //to save texture
            founded.SetActive(true);
        }

        void OnTargetLost(ImageTargetBaseBehaviour behaviour)
        {
            //to save texture
            founded.SetActive(false);

            GameObject.Find("002").GetComponent<MeshRenderer>().material = newMat;

            ShowObjects(transform);
            Debug.Log("Target lost and showing object");
        }
    }
}
