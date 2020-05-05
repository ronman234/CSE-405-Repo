﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameStart : MonoBehaviour {


    void Start()
    {
        Animator anim = GetComponent<Animator>();
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        anim.Play(state.fullPathHash, -1, Random.Range(0f, 6f));
    }

}
