// Пересмотреть и исправить
using UnityEngine;

public class AttachClothToAvatar : MonoBehaviour
{
    public SkinnedMeshRenderer targetCloth; // одежда
    public SkinnedMeshRenderer targetBody;  // тело персонажа

    void Start()
    {
        if (targetCloth == null || targetBody == null) return;

        // Копируем кости и рут
        targetCloth.rootBone = targetBody.rootBone;
        targetCloth.bones = targetBody.bones;
    }
}
