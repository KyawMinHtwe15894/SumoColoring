/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/

using UnityEngine;
using UnityEditor;
using EasyAR;
using System.Collections;
using System;

namespace EasyARSample
{
    public class Coloring3DBehaviour : MonoBehaviour
    {
        Camera cam; // drag the camera onto this field in the inspector
        RenderTexture renderTexture;    // drag the render texture onto this field in the Inspector
        ImageTargetBaseBehaviour targetBehaviour;
		public GameObject founded;
        public Material newMat;


        void Start()
        {
            targetBehaviour = GetComponentInParent<ImageTargetBaseBehaviour>();
            gameObject.layer = 31;

        }

        // public Texture2D GetRTPixels(RenderTexture rt)
        // {

        //     // Remember currently active render texture
        //     RenderTexture currentActiveRT = RenderTexture.active;

        //     // Set the supplied RenderTexture as the active one
        //     RenderTexture.active = rt;

        //     // Create a new Texture2D and read the RenderTexture image into it
        //     Texture2D tex = new Texture2D(rt.width, rt.height);
        //     tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

        //     // Restorie previously active render texture
        //     RenderTexture.active = currentActiveRT;
        //     return tex;
        // }

        void Renderprepare()
        {

            if (!cam)
            {
                GameObject go = new GameObject("__cam");
                cam = go.AddComponent<Camera>();
                go.transform.parent = transform.parent;
                cam.hideFlags = HideFlags.HideAndDontSave;
            }

            cam.CopyFrom(Camera.main);
            cam.depth = 0;
            cam.cullingMask = 31;

            if (!renderTexture)
            {
                renderTexture = new RenderTexture(Screen.width, Screen.height, -50);
            }
            cam.targetTexture = renderTexture;  // get the camera's render texture
            cam.Render();   // render the texture

            GetComponent<Renderer>().material.SetTexture("_MainTex", renderTexture); // camera texture rendering

            if( founded.activeSelf )
            {
                RenderTexture rt = RenderTexture.active;
                // Texture2D myTexture2D = GetRTPixels(renderTexture);
                // Texture2D myTexture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
                // myTexture2D.ReadPixels(new Rect(0, 0, myTexture2D.width, myTexture2D.height), 0, 0);
                // myTexture2D.Apply();

                newMat.mainTexture = rt;
                // newMat.SetTexture("_MainTex", myTexture2D);
            }

            // if(!GameObject.Find("founded"))
            // {
            //     if( GameObject.Find("founded").activeSelf )
            //     {
            //         Texture2D MyTexture = new Texture2D(1,1);
            //         MyTexture = (Texture2D)Resources.Load("MyTexture", typeof(Texture2D));
            //         MyTexture = renderTexture;
            //     }
            // }

            // if( GameObject.Find("founded").activeSelf )
            // {
            //     Material mat = new Material( Shader.Find( "Specular" ) );
            //     AssetDatabase.CreateAsset( mat, "Assets/MyMaterial.mat" );
            //     GameObject.Find("MyMaterial").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", renderTexture);
            //     Debug.Log("material clone!");
            // }
            // else
            // {
            //     GetComponent<Renderer>().material = GameObject.Find("MyMaterial").GetComponent<MeshRenderer>().material;
            // }
        }


        void OnWillRenderObject()
        {

            if (!targetBehaviour || targetBehaviour.Target == null)
                return;
            Vector2 halfSize = targetBehaviour.Target.Size * 0.5f;
            Vector3 targetAnglePoint1 = transform.parent.TransformPoint(new Vector3(-halfSize.x, 0, halfSize.y));
            Vector3 targetAnglePoint2 = transform.parent.TransformPoint(new Vector3(-halfSize.x, 0, -halfSize.y));
            Vector3 targetAnglePoint3 = transform.parent.TransformPoint(new Vector3(halfSize.x, 0, halfSize.y));
            Vector3 targetAnglePoint4 = transform.parent.TransformPoint(new Vector3(halfSize.x, 0, -halfSize.y));
            Renderprepare();

            // if( founded.activeSelf )
            // {
            //     newMat.SetVector("_Uvpoint1", new Vector4(targetAnglePoint1.x, targetAnglePoint1.y, targetAnglePoint1.z, 1f));
            //     newMat.SetVector("_Uvpoint2", new Vector4(targetAnglePoint2.x, targetAnglePoint2.y, targetAnglePoint2.z, 1f));
            //     newMat.SetVector("_Uvpoint3", new Vector4(targetAnglePoint3.x, targetAnglePoint3.y, targetAnglePoint3.z, 1f));
            //     newMat.SetVector("_Uvpoint4", new Vector4(targetAnglePoint4.x, targetAnglePoint4.y, targetAnglePoint4.z, 1f));
            // }
            // else
            // {
                GetComponent<Renderer>().material.SetVector("_Uvpoint1", new Vector4(targetAnglePoint1.x, targetAnglePoint1.y, targetAnglePoint1.z, 1f));
                GetComponent<Renderer>().material.SetVector("_Uvpoint2", new Vector4(targetAnglePoint2.x, targetAnglePoint2.y, targetAnglePoint2.z, 1f));
                GetComponent<Renderer>().material.SetVector("_Uvpoint3", new Vector4(targetAnglePoint3.x, targetAnglePoint3.y, targetAnglePoint3.z, 1f));
                GetComponent<Renderer>().material.SetVector("_Uvpoint4", new Vector4(targetAnglePoint4.x, targetAnglePoint4.y, targetAnglePoint4.z, 1f));
            // }

        }

        void OnDestroy()
        {
            if (renderTexture)
                DestroyImmediate(renderTexture);
            if (cam)
                DestroyImmediate(cam.gameObject);
        }

    }
}
