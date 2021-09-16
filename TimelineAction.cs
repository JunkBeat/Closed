// Decompiled with JetBrains decompiler
// Type: TimelineAction
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TimelineAction
{
  public float time;
  public float textTime;
  public TextFieldController textfield;
  public string text;
  public int textWidth = -1;
  public bool blockG = true;
  public bool fast;
  public bool instant;
  public Vector3 textColor = new Vector3(1f, 1f, 1f);
  public Vector3 backgroundColor = new Vector3(0.0f, 0.0f, 0.0f);
  public float backgroundAlpha = 0.75f;
  public TimelineFunction function;
  public string param = string.Empty;
  public bool actionWithText;
  public bool textDisplayed;

  public TimelineAction(TextFieldController tf = null) => this.textfield = tf;
}
