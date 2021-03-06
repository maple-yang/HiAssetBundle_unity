﻿using HiAssetBundle;
using UnityEngine;

public class Example2 : MonoBehaviour
{
    FileUpdateMgr mgr = new FileUpdateMgr();
    // Use this for initialization
    void Start()
    {
        mgr.Init_OnlyForTest(CheckFinish);


        //string url = "";
        //mgr.Init(url, FinishDownload);

    }

    void CheckFinish(float param)
    {
        mgr.StartUpdate(UpdateFinish);
    }
    void UpdateFinish()
    {
        Debug.Log("finish");
    }
    // Update is called once per frame
    void Update()
    {
        if (mgr.needUpdate)
            Debug.Log(mgr.progress);
    }

    void OnGUI()
    {
        //if can destroy dependence asset
        if (GUI.Button(new Rect(0, 0, 100, 40), "Clean Common"))
        {
            AssetBundleMgr.UnLoadAssetBundle("common");
        }
        //still can't destroy dependence asset
        if (GUI.Button(new Rect(0, 50, 100, 40), "Clean test"))
        {
            AssetBundleMgr.UnLoadAssetBundle("test");
        }
        //destroy "test2", also destroy destroy dependence
        if (GUI.Button(new Rect(0, 100, 100, 40), "Clean test2"))
        {
            AssetBundleMgr.UnLoadAssetBundle("test2");
        }
        if (GUI.Button(new Rect(0, 150, 100, 40), "load"))
        {
            AssetBundle t1 = AssetBundleMgr.GetAssetBundle("test");
            Object cube = t1.LoadAsset("Cube");
            GameObject go = Instantiate(cube) as GameObject;
            go.transform.position = Vector3.left;

            AssetBundle t2 = AssetBundleMgr.GetAssetBundle("test2");
            Object sphere = t2.LoadAsset("sphere");
            Instantiate(sphere);
        }
    }
}
