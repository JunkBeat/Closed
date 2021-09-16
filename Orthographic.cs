// Decompiled with JetBrains decompiler
// Type: Orthographic
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Orthographic : MonoBehaviour
{
  private float offset;

  private void Start()
  {
    if (SystemInfo.graphicsDeviceVersion.ToLower().StartsWith("direct3d 9"))
      this.offset = 0.5f;
    this.GetComponent<Camera>().orthographic = true;
  }

  private void Update()
  {
    this.GetComponent<Camera>().orthographicSize = (float) (Screen.height / 2);
    this.GetComponent<Camera>().transform.position = new Vector3((float) (Screen.width / 2) - this.offset, (float) (Screen.height / 2) - this.offset, -1f);
  }
}
