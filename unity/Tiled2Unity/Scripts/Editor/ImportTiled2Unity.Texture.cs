using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

namespace Tiled2Unity
{
    // Handled a texture being imported
    partial class ImportTiled2Unity
    {
        public void TextureImported(string texturePath)
        {
			// Check to see if this is a normal map and get the texture associated with the normal map and the material.
			if (ImportTiled2Unity.ProcessingNormalMaps && texturePath.Contains (ImportTiled2Unity.TiledNormalMapFileIdentification)) {
				// This is fixup method due to materials and textures, under some conditions, being imported out of order
				Texture2D texture2d = AssetDatabase.LoadAssetAtPath (texturePath, typeof(Texture2D)) as Texture2D;
				Material material = AssetDatabase.LoadAssetAtPath (GetMaterialAssetPath (texturePath.Replace(ImportTiled2Unity.TiledNormalMapFileIdentification, String.Empty)), typeof(Material)) as Material;
				material.SetTexture ("_BumpMap", texture2d);
			} else {

				// This is fixup method due to materials and textures, under some conditions, being imported out of order
				Texture2D texture2d = AssetDatabase.LoadAssetAtPath (texturePath, typeof(Texture2D)) as Texture2D;
				Material material = AssetDatabase.LoadAssetAtPath (GetMaterialAssetPath (texturePath), typeof(Material)) as Material;
				material.SetTexture ("_MainTex", texture2d);
			}
        }
    }
}
