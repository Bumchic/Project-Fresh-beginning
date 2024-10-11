using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShadowContactable
{
   Boolean shadowContacted { get; set; }
    BoxCollider2D boxCollider { get; set; }
    LayerMask ShadowlayerMask { get; set; }

    void ShadowContactCheck();
}
