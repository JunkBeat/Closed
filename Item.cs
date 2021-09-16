// Decompiled with JetBrains decompiler
// Type: Item
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Item
{
  public string id;
  public float weight;
  public AudioClip sound;
  public AudioClip soundLoop;
  public Sprite inventorySprite;
  public Sprite groundSprite;
  public Sprite groundSprite_1;
  public Sprite groundSprite_2;
  public Sprite groundSprite_3;
  public Sprite groundSprite_4;
  public Sprite groundSprite_5;
  public int animationDelay;
  public Sprite examineSprite;
  public Sprite examineSprite_1;
  public Sprite examineSprite_2;
  public Sprite examineSprite_3;
  public Sprite examineSprite_4;
  public bool examineCycleSprites;
  public List<string> examineTexts;
  public int textWidth;
  public int textShiftX;
  public int textShiftY;
  public Color textColor1;
  public Color textColor2;
  public ItemData dataRef;
  public List<ItemInteraction> usableItemsInventory;
  public List<ItemInteraction> usableItemsGround;
  public ExamineSprite.Delegate lookAction;
  public bool actionOnLook;
}
