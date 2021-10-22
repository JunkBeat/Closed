// Decompiled with JetBrains decompiler
// Type: DialogueLine
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class DialogueLine
{
  public TextFieldController source;
  public Vector3 textColor;
  public string text;
  public TimelineFunction action;
  public string actionParam = string.Empty;
  public bool actionWithText;
  public bool displayText;
  public float time;

  public DialogueLine(
    TextFieldController src,
    Vector3 tC,
    string t,
    TimelineFunction a,
    bool awt = false,
    bool dt = true,
    float tim = 0.0f)
  {
    this.time = tim;
    this.source = src;
    this.textColor = tC;
    this.text = t;
    this.action = a;
    this.actionWithText = awt;
    this.displayText = dt;
  }
}
