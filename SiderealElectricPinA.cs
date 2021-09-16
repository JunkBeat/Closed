// Decompiled with JetBrains decompiler
// Type: SiderealElectricPinA
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SiderealElectricPinA : MonoBehaviour
{
  private TextFieldController t;

  private void Start()
  {
    this.t = this.GetComponent<TextFieldController>();
    this.display("-");
    this.t.keepAlive = true;
  }

  public void display(string val) => this.t.viewText(val, quick: true, instant: true, mwidth: 200, r: 0.2980392f, g: 0.3058824f, b: 0.2666667f, ba: 0.0f);

  private void Update()
  {
  }
}
