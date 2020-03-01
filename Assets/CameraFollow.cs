using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //reference to player's transform. 
    //Transforms give information about position, rotation and scale
    public Transform target;

    //defines how quickly the camera will snap to the target
    //higher the faster it looks, smaller it is the more times it spends smoothing
    //want to be 0 .. 1
    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    //we cant use update because player movement will also be changed in update
    //we result in jittery behavior because the target's transform and will be
    //changed in the same fram we try to reference it
    //LateUpdate, same as update but run right after update
    private void LateUpdate()
    {
        transform.position = target.position + offset;

    }
}
