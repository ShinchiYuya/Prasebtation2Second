using System.Collections;
using System.Collections.Generic;
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
                // �v���C���[�̈ʒu���擾���ăJ�����̈ʒu�ɐݒ肷��
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1, transform.position.z);
                Debug.Log("We");
            }
            else
            {
                Debug.Log("����@=�@��������F�F�F");
            }
        }
    }
}
