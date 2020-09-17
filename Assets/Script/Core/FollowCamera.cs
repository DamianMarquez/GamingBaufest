using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core{
    public class FollowCamera : MonoBehaviour
    {

        [SerializeField] public Transform target;

        // Update is called once per frame
        void LateUpdate()
        {
            if(target != null)
                transform.position = target.position;
        }
    }
}
