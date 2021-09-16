// Decompiled with JetBrains decompiler
// Type: SimpleRounderToNearest
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class SimpleRounderToNearest : MonoBehaviour
{
  private void Start() => this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);

  private void Update()
  {
  }
}
