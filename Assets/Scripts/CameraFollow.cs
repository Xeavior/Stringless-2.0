using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    #region PUBLIC VARIABLES

    public float xMargin = .01f;        
    public float yMargin = .01f;       
    public float xSmooth = 8f;         
    public float ySmooth = 8f;          
    public Vector2 maxXAndY;           
    public Vector2 minXAndY;            

    #endregion
    #region PRIVATE VARIABLES

    private Transform camera;         

    #endregion

    #region INHERENT METHODS [Awake, FixedUpdate]
   
    void Awake()
    {
       
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

   
    void FixedUpdate()
    {
        TrackPlayer();
    }
    #endregion
    #region UTILITY METHODS [CheckXMargin, CheckYMargin, TrackPlayer]

   
    bool CheckXMargin()
    {
        
        return Mathf.Abs(transform.position.x - camera.position.x) > xMargin;
    }

   
    bool CheckYMargin()
    {
       
        return Mathf.Abs(transform.position.y - camera.position.y) > yMargin;
    }

   
    void TrackPlayer()
    {
      
        float targetX = transform.position.x;
        float targetY = transform.position.y;

      
        if (CheckXMargin())
          
            targetX = Mathf.Lerp(transform.position.x, camera.position.x, xSmooth * Time.deltaTime);

     
        if (CheckYMargin())
           
            targetY = Mathf.Lerp(transform.position.y, camera.position.y, ySmooth * Time.deltaTime);

     
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

     
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
    #endregion
}

