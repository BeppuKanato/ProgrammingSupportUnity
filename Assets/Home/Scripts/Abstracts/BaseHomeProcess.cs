using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public abstract class BaseHomeProcess : MonoBehaviour, StateProcessInterface
{
    [SerializeField]
    GameObject buttons;     //表示するボタンを子に持つオブジェクト
    [SerializeField]
    HomeUIStateEnum state;  //クラスが処理を担当する状態

    [SerializeField]
    Vector3 nonDisplayPos = new Vector3(-780, 0, 0);  //UIを表示する位置
    [SerializeField]
    Vector3 displayPos = new Vector3(-420, 0, 0);     //非表示の時のUIの位置

    LerpAnims lerpAnims;
    [SerializeField]
    protected HomeUIStateEnum nextState; //Process処理で返す状態

    void Awake()
    {
        this.lerpAnims = new LerpAnims();
    }
    public virtual void Enter()
    {
        //processで返す状態を自分の状態に設定
        nextState = state;
        buttons.SetActive(true);
        Debug.Log($"{lerpAnims}");
        StartCoroutine(this.lerpAnims.LerpLocalPositionCoroutine(nonDisplayPos, displayPos, buttons));
    }

    public virtual int Process()
    {
        return (int)this.nextState;
    }

    public virtual void Exit() 
    {
        buttons.SetActive(false);
    }

    public virtual int GetState()
    {
        return (int)this.state;
    }
}
