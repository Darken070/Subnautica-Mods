using System;
using UnityEngine;
using Utilites.Logger;

namespace MoreHullPlates.Data
{
    public class Prefab
    {
        public static GameObject Get(TechType techtype, string Classid, Texture2D texture)
        {
            try
            {
                var prefab = Resources.Load<GameObject>("Submarine/Build/IGPHullPlate");
                var obj = UnityEngine.Object.Instantiate(prefab);
                var child = obj.transform.Find("Icon").gameObject;

                var constructable = obj.GetComponent<Constructable>();
                var techTag = obj.GetComponent<TechTag>();
                var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();
                var mesh = child.GetComponent<MeshRenderer>();

                constructable.techType = techtype;

                techTag.type = techtype;

                prefabIdentifier.ClassId = Classid;

                mesh.material.mainTexture = texture;

                return obj;
            }
            catch (Exception e)
            {
                e.Log();
                return null;
            }
        }

        /*public static GameObject Special(TechType techtype, string Classid, Texture2D texture)
        {
            try
            {
                var prefab = Resources.Load<GameObject>("Submarine/Build/IGPHullPlate");
                var specialprefab = Resources.Load<GameObject>("Submarine/Build/SpecialHullPlate");
                var obj = UnityEngine.Object.Instantiate(prefab);
                var specialobj = UnityEngine.Object.Instantiate(specialprefab);
                var child = obj.transform.Find("Icon").gameObject;

                var constructable = obj.GetComponent<Constructable>();
                var specialconstructable = obj.GetComponent<Constructable>();
                var techTag = obj.GetComponent<TechTag>();
                var specialtechTag = obj.GetComponent<TechTag>();
                var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();
                var specialprefabIdentifier = obj.GetComponent<PrefabIdentifier>();
                var mesh = child.GetComponent<MeshRenderer>();

                constructable.techType = techtype;
                specialconstructable.techType = techtype;

                techTag.type = techtype;
                specialtechTag.type = techtype;

                prefabIdentifier.ClassId = Classid;
                specialprefabIdentifier.ClassId = Classid + "Special";

                mesh.material.mainTexture = texture;

                obj.transform.position = new Vector3(-1, 0f, 0f);
                child.transform.position = new Vector3(-1, 0f, 0f);

                return obj;
            }
            catch (Exception e)
            {
                e.Log();
                return null;
            }
        }*/
    }
}
