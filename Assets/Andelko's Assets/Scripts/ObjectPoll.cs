using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    namespace KartRacing.Scripts
{
	public class ObjectPoll : MonoBehaviour
	{
		[SerializeField] private Transform ParentTransform;

		[SerializeField] private GameObject Prefab;

		[SerializeField] private int PollSize;

		private int Index = 0;
		private List<GameObject> Prefabs { get; set; }

		private void Start()
		{
			Prefabs = new List<GameObject>();
			for (int i = 0; i < PollSize; i++)
			{
				
				Prefabs.Add(Instantiate(Prefab,ParentTransform));
			}
		}

		
	}
}
