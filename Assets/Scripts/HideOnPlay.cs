﻿using UnityEngine;
using System.Collections;

namespace WizardsCode.terrain
{
    public class HideOnPlay : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}