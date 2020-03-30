using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsHolding;
    public Camera MainCam;
    public LineRenderer lr;
    public Vector3 ThrowPoint;
    public int LineSegment = 10;
    public GameObject ThrowIndicator;
    public bool IndVis;
    private GameObject DupeInd;

    Vector3 CalPositionInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;

        Vector3 result = ThrowPoint + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + ThrowPoint.y;

        result.y = sY;

        return result;
    }

    void VisualizeLine(Vector3 vo)
    {
        for (int i = 0; i < LineSegment; i++)
        {
            Vector3 pos = CalPositionInTime(vo, i / (float)LineSegment);
            lr.SetPosition(i, pos);
        }
    }

    Vector3 CalculateVelocty(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0f;

        float sY = distance.y;
        float sXz = distanceXz.magnitude;

        float Vxz = sXz * time;
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

        Vector3 result = distanceXz.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }

    void Start()
    {
        IsHolding = false;
        IndVis = false;
        lr.positionCount = LineSegment;
    }



    private void FixedUpdate()
    {
        
        ThrowPoint = transform.position;
        if (IsHolding)
        {
            RaycastHit hit;
            Ray cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cursorRay, out hit))
            {

                Vector3 vo = CalculateVelocty(hit.point, transform.position, 1f);
                VisualizeLine(vo);
                if (IndVis)
                {
                    
                    DupeInd.transform.position = hit.point;
                }
                else if (!IndVis)
                {
                    IndVis = true;
                    DupeInd = Instantiate(ThrowIndicator, hit.point, transform.rotation);
                    lr.GetComponent<Renderer>().enabled = true;
                    DupeInd.GetComponent<Renderer>().enabled = true;
                }

            }
        }
        else if (!IsHolding && IndVis)
        {
            IndVis = false;
            lr.GetComponent<Renderer>().enabled = false;
            DupeInd.GetComponent<Renderer>().enabled = false;
        }
    }


}
