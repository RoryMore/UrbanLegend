using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeBasic : MonoBehaviour
{
    public void SetPos(Vector2 target)
    {
        transform.position.Set(transform.position.x, target.y, transform.position.z);
    }
}
