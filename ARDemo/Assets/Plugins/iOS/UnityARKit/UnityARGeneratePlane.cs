using System;
using System.Collections.Generic;

namespace UnityEngine.XR.iOS
{
	public class UnityARGeneratePlane : MonoBehaviour
	{
		public GameObject planePrefab;
        public UnityARAnchorManager unityARAnchorManager;

		// Use this for initialization
		void Start () {
            unityARAnchorManager = new UnityARAnchorManager();
			UnityARUtility.InitializePlanePrefab (planePrefab);
		}

        void OnDestroy() {
            unityARAnchorManager.Destroy ();
        }
	}
}

