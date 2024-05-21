using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAnimatoins : MonoBehaviour
{
    [SerializeField]
    RectTransform popUpPanel;

    LerpAnims lerpScaleAnim = new LerpAnims();

    float panelXScale = 0.4f;
    float panelYScale = 0.4f;


    //�|�b�v�A�b�v���J���A�j���[�V����
    public IEnumerator OpenPopUpCoroutine()
    {
        //�T�C�Y��������
        popUpPanel.gameObject.transform.localScale = new Vector3(0, 0, 0);

        popUpPanel.gameObject.SetActive(true);

        Vector3 originScale = new Vector3(popUpPanel.transform.localScale.x, popUpPanel.transform.localScale.y, popUpPanel.transform.localScale.z);
        Vector3 targetScale = new Vector3(panelXScale, panelYScale, 0);

        yield return StartCoroutine(lerpScaleAnim.LerpScaleCoroutine(originScale, targetScale, popUpPanel.gameObject));
    }
    //�|�b�v�A�b�v�����A�j���[�V����
    public IEnumerator ClosePopUpCoruotine()
    {
        //���݂̃X�P�[��
        Vector3 originScale = new Vector3(popUpPanel.transform.localScale.x, popUpPanel.transform.localScale.y, popUpPanel.transform.localScale.z);
        //�ڕW�X�P�[��
        Vector3 targetScale = new Vector3(0, 0, 0);

        yield return StartCoroutine(lerpScaleAnim.LerpScaleCoroutine(originScale, targetScale, popUpPanel.gameObject));

        popUpPanel.gameObject.SetActive(false);
    }
}
