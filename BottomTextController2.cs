﻿// Decompiled with JetBrains decompiler
// Type: BottomTextController2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class BottomTextController2 : MonoBehaviour
{
  public static int bottomTextWidth = 224;

  private void Start()
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(17f, 15f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    this.gameObject.transform.position = worldPoint;
    this.gameObject.GetComponent<TextFieldController>().maxWidth = BottomTextController.bottomTextWidth;
    this.gameObject.GetComponent<TextFieldController>().shift.x = 3f;
  }

  private void Update()
  {
  }
}
