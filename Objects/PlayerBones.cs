// Пересмотреть и исправить
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;

public class AttachClothToAvatar : MonoBehaviour
{
    SkinnedMeshRenderer targetCloth; // одежда
    SkinnedMeshRenderer targetBody;  // тело персонажа

    void Start()
    {
        targetCloth = gameObject.GetComponent<SkinnedMeshRenderer>();
        targetBody = PlayerController.instance.targetBody;
        if (targetCloth == null || targetBody == null) return;

        // Копируем кости и рут
        targetCloth.rootBone = targetBody.rootBone;
        targetCloth.bones = targetBody.bones;
    }
}
