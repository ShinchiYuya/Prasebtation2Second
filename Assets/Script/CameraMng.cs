using UnityEngine;

public class CameraMng : MonoBehaviour
{
    [SerializeField] Transform _leftLimTr, _rightLimTr;
    public Transform playerTransform;
    private Camera _mainCam;
    private float _camOffSet;

    private void Start()
    {
        this._mainCam = Camera.main;
        this._camOffSet = this._mainCam.orthographicSize * 2;

        //Camera Coordinate Limitance
        CamLimit();
    }

    void Update()
    {
        CamLimit();
    }

    private void CamLimit()
    {
        if (playerTransform != null && this._leftLimTr != null && this._rightLimTr != null)
        {
            if (this._leftLimTr.transform.position.x <= this.playerTransform.transform.position.x - this._camOffSet && this.playerTransform.transform.position.x + this._camOffSet <= this._rightLimTr.position.x)
            {
                // プレイヤーの位置を取得してカメラの位置に設定する
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1, transform.position.z);
            }
            else
            {
            }
        }
    }
}
