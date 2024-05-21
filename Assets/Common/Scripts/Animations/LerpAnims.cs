using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAnims
{
    float animSpeed = 4f;
    //Lerp���g�p���ăX�P�[����ύX����
    public IEnumerator LerpScaleCoroutine(Vector3 origin, Vector3 target, GameObject animObj)
    {
        float rate = 0f;

        //�⊮����������܂Ń��[�v
        while (rate < 1)
        {
            Vector3 newScale = Vector3.Lerp(origin, target, rate);

            animObj.transform.localScale = newScale;

            rate += Time.deltaTime * animSpeed;

            yield return null;
        }
    }
    //Lerp���g�p���ă|�W�V������ύX����
    public IEnumerator LerpPositionCoroutine(Vector3 origin, Vector3 target, GameObject animObj)
    {
        float rate = 0f;

        //�⊮����������܂Ń��[�v
        while (rate < 1)
        {
            Vector3 newPosition = Vector3.Lerp(origin, target, rate);

            animObj.transform.position = newPosition;

            rate += Time.deltaTime * animSpeed;

            yield return null;
        }
    }
}
