// Decompiled with JetBrains decompiler
// Type: GameStrings
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System;
using UnityEngine;

public static class GameStrings
{
  public static KeyValueString[] gui;
  public static KeyValueString[] items;
  public static KeyValueString[] map;
  public static KeyValueString[] objects;
  public static KeyValueString[] journal;
  public static KeyValueString[] actions;
  public static KeyValueString[] warnings;
  public static KeyValueString[] world_labels;
  public static KeyValueString[] results;
  public static KeyValueString[] dialogues;
  public static KeyValueString[] languages;

  public static void readStrings(string lang)
  {
    GameStrings.gui = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/gui") as TextAsset);
    GameStrings.languages = GameStrings.parse(Resources.Load("Txt/languages") as TextAsset);
    GameStrings.items = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/items") as TextAsset);
    GameStrings.objects = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/objects") as TextAsset);
    GameStrings.journal = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/journal") as TextAsset);
    GameStrings.warnings = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/warnings") as TextAsset);
    GameStrings.actions = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/actions") as TextAsset);
    GameStrings.world_labels = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/world_labels") as TextAsset);
    GameStrings.map = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/map") as TextAsset);
    GameStrings.results = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/results") as TextAsset);
    GameStrings.dialogues = GameStrings.parse(Resources.Load("Txt/" + lang.ToString().ToLower() + "/dialogues") as TextAsset);
  }

  private static KeyValueString[] parse(TextAsset toParse)
  {
    string[] strArray = toParse.text.Split('@');
    KeyValueString[] keyValueStringArray = new KeyValueString[strArray.Length];
    for (int index = 0; index < strArray.Length; ++index)
    {
      if (strArray[index].IndexOf('=') != -1)
      {
        keyValueStringArray[index].key = strArray[index].Substring(0, strArray[index].IndexOf('='));
        keyValueStringArray[index].value = strArray[index].Substring(strArray[index].IndexOf('=') + 1);
        keyValueStringArray[index].value = keyValueStringArray[index].value.Replace("\r", string.Empty).Replace("\n", string.Empty);
      }
    }
    return keyValueStringArray;
  }

  public static string getPrefixedShort(KeyValueString[] lib, string what, bool capital = false)
  {
    string empty = GameStrings.getString(lib, what + "_prefix");
    string str1 = GameStrings.getString(lib, what + "_short");
    if (capital)
    {
      char[] charArray = empty.ToCharArray();
      if (charArray.Length > 0)
        charArray[0] = charArray[0].ToString().ToUpper().ToCharArray()[0];
      empty = string.Empty;
      for (int index = 0; index < charArray.Length; ++index)
        empty += (string) (object) charArray[index];
    }
    if (empty.Length == 0)
    {
      char[] charArray = str1.ToCharArray();
      if (capital)
        charArray[0] = charArray[0].ToString().ToUpper().ToCharArray()[0];
      string str2 = str1;
      str1 = charArray[0].ToString() + str2.Substring(1);
    }
    return empty.Length > 0 ? empty + " " + str1 : str1;
  }

  public static string getWrongInteractionText()
  {
    UnityEngine.Random.seed = (int) DateTime.Now.Ticks;
    int num = UnityEngine.Random.Range(1, 7);
    return GameStrings.getString(GameStrings.actions, "default" + (object) num);
  }

  public static string capitalise(string src)
  {
    char[] charArray = src.ToCharArray();
    charArray[0] = charArray[0].ToString().ToUpper().ToCharArray()[0];
    string str = src;
    src = charArray[0].ToString() + str.Substring(1);
    return src;
  }

  public static string getString(KeyValueString[] lib, string key)
  {
    if (lib != null)
    {
      for (int index = 0; index < lib.Length; ++index)
      {
        if (lib[index].key == key)
          return lib[index].value;
      }
    }
    return key + "_STRING_MISSING";
  }

  public enum Language
  {
    EN,
    PL,
    DE,
  }
}
