using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Target;
    [SerializeField] Vector3 OffSet;
    [SerializeField] float CamSpeed;
    [SerializeField] float RotateCamSpeed;



    private void LateUpdate()
    {
        moveTheCamera();
        rotateTheCamera();
    }



    private void rotateTheCamera()
    {
        var direction=Target.position-transform.position;
        var rotation=Quaternion.LookRotation(direction,Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, CamSpeed*Time.deltaTime);
    }
    private void moveTheCamera()
    {
        var targetPosition=Target.TransformPoint(OffSet);
        transform.position=Vector3.Lerp(transform.position,targetPosition, CamSpeed*Time.deltaTime);
    }
}
