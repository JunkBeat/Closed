// Decompiled with JetBrains decompiler
// Type: ScreenControler
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ScreenControler
{
  public static int sourceWidth = 240;
  public static int sourceHeight = 135;
  public static float ratioWidth = 1f;
  public static float ratioHeight = 1f;
  public static float shiftRatioX = 0.0f;
  public static float shiftRatioY = 0.0f;
  public static float shiftX = 0.0f;
  public static float shiftY = 0.0f;
  public static Vector2[] allowedResolutions = new Vector2[11]
  {
    new Vector2(1920f, 1080f),
    new Vector2(1680f, 945f),
    new Vector2(1600f, 900f),
    new Vector2(1440f, 810f),
    new Vector2(1366f, 768f),
    new Vector2(1280f, 720f),
    new Vector2(1200f, 675f),
    new Vector2(1152f, 648f),
    new Vector2(1024f, 576f),
    new Vector2(960f, 540f),
    new Vector2(480f, 270f)
  };
  public static Resolution[] resolutions;

  private ScreenControler()
  {
  }

  public static Vector2 getResolution()
  {
    Vector2 vector2 = new Vector2(0.0f, 0.0f);
    Resolution currentResolution = Screen.currentResolution;
    vector2.x = (float) currentResolution.width;
    vector2.y = (float) currentResolution.height;
    return vector2;
  }

  public static Resolution[] getResolutions()
  {
    ScreenControler.resolutions = Screen.resolutions;
    return ScreenControler.resolutions;
  }

  public static Vector2 getHighestResolution()
  {
    ScreenControler.getResolutions();
    return new Vector2((float) ScreenControler.resolutions[ScreenControler.resolutions.Length - 1].width, (float) ScreenControler.resolutions[ScreenControler.resolutions.Length - 1].height);
  }

  public static Vector2 getHighestWindowResolution()
  {
    ScreenControler.getResolutions();
    int width = Screen.currentResolution.width;
    for (int index = 0; index < ScreenControler.allowedResolutions.Length; ++index)
    {
      if ((double) width > (double) ScreenControler.allowedResolutions[index].x)
        return new Vector2(ScreenControler.allowedResolutions[index].x, ScreenControler.allowedResolutions[index].y);
    }
    return new Vector2(-1f, -1f);
  }

  public static void setFullScreenResolution()
  {
    Vector2 highestResolution = ScreenControler.getHighestResolution();
    PlayerPrefs.SetInt("fullscreen", 1);
    PlayerPrefs.SetInt("resolution", (int) highestResolution.x);
    PlayerPrefs.Save();
    Screen.SetResolution((int) highestResolution.x, (int) highestResolution.y, true);
  }

  public static void setWindowedResolution(int width)
  {
    ScreenControler.getResolutions();
    for (int index = 0; index < ScreenControler.allowedResolutions.Length; ++index)
    {
      if ((double) width == (double) ScreenControler.allowedResolutions[index].x)
      {
        PlayerPrefs.SetInt("fullscreen", 0);
        PlayerPrefs.SetInt("resolution", (int) ScreenControler.allowedResolutions[index].x);
        PlayerPrefs.Save();
        Screen.SetResolution((int) ScreenControler.allowedResolutions[index].x, (int) ScreenControler.allowedResolutions[index].y, false);
      }
    }
  }

  public static void setSavedResolution()
  {
    ScreenControler.getHighestResolution();
    if (PlayerPrefs.HasKey("fullscreen"))
    {
      if (PlayerPrefs.GetInt("fullscreen") == 1)
        ScreenControler.setFullScreenResolution();
      else
        ScreenControler.setWindowedResolution(PlayerPrefs.GetInt("resolution"));
    }
    else
    {
      PlayerPrefs.SetInt("resolution", 1920);
      PlayerPrefs.SetInt("fullscreen", 1);
      ScreenControler.setFullScreenResolution();
    }
  }

  public static float distance(Vector2 a, Vector2 b) => Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2f) + Mathf.Pow(a.y - b.y, 2f));

  public static Vector2 getScale()
  {
    Vector2 vector2 = new Vector2();
    vector2.x = Mathf.Floor((float) ScreenControler.sourceWidth * ((float) Screen.width * ScreenControler.ratioWidth / (float) ScreenControler.sourceWidth));
    vector2.y = Mathf.Floor((float) ScreenControler.sourceHeight * ((float) Screen.height * ScreenControler.ratioHeight / (float) ScreenControler.sourceHeight));
    return new Vector2((float) ((double) Screen.width * (double) ScreenControler.ratioWidth / (double) vector2.x * ((double) Screen.width * (double) ScreenControler.ratioWidth / (double) ScreenControler.sourceWidth)), (float) ((double) Screen.height * (double) ScreenControler.ratioHeight / (double) vector2.y * ((double) Screen.height * (double) ScreenControler.ratioHeight / (double) ScreenControler.sourceHeight)));
  }

  public static Vector2 gameToScreen(Vector2 vectorToChange) => new Vector2()
  {
    x = Mathf.Floor(vectorToChange.x) * ScreenControler.getScale().x + ScreenControler.shiftRatioX,
    y = Mathf.Floor(vectorToChange.y) * ScreenControler.getScale().y + ScreenControler.shiftRatioY
  };

  public static Vector2 gameToScreen2(Vector2 vectorToChange) => new Vector2()
  {
    x = Mathf.Round(vectorToChange.x) * ScreenControler.getScale().x + ScreenControler.shiftRatioX,
    y = Mathf.Floor(vectorToChange.y) * ScreenControler.getScale().y + ScreenControler.shiftRatioY
  };

  public static Vector2 screenToGame(Vector2 vectorToChange) => new Vector2()
  {
    x = (vectorToChange.x - ScreenControler.shiftRatioX) / ScreenControler.getScale().x,
    y = (vectorToChange.y - ScreenControler.shiftRatioY) / ScreenControler.getScale().y
  };

  public static Vector2 screenToGame2(Vector2 vectorToChange) => new Vector2()
  {
    x = vectorToChange.x / ScreenControler.getScale().x - ScreenControler.shiftX,
    y = vectorToChange.y / ScreenControler.getScale().y - ScreenControler.shiftY
  };

  public static Vector3 roundToNearestFullPixelOld(Vector3 vectorToChange)
  {
    Vector3 vector3 = new Vector3();
    vector3.x = vectorToChange.x;
    vector3.y = vectorToChange.y;
    vector3.z = vectorToChange.z;
    float x1 = ScreenControler.getScale().x;
    float x2 = ScreenControler.getScale().x;
    vector3.x = Mathf.Round(vector3.x / x1) * x1;
    vector3.y = Mathf.Round(vector3.y / x2) * x2;
    return vector3;
  }

  public static Vector3 roundToNearestFullPixel(Vector3 vectorToChange)
  {
    Vector3 game = (Vector3) ScreenControler.screenToGame((Vector2) Camera.main.WorldToScreenPoint(vectorToChange));
    game.z = vectorToChange.z;
    game.x = Mathf.Floor(game.x);
    game.y = Mathf.Floor(game.y);
    return game;
  }

  public static Vector3 roundToNearestFullPixel2(Vector3 vectorToChange)
  {
    vectorToChange = Camera.main.WorldToScreenPoint(vectorToChange);
    Vector2 screen = ScreenControler.gameToScreen(ScreenControler.screenToGame(new Vector2()
    {
      x = vectorToChange.x,
      y = vectorToChange.y
    }));
    return Camera.main.ScreenToWorldPoint(new Vector3()
    {
      x = screen.x,
      y = screen.y,
      z = vectorToChange.z
    });
  }

  public static Vector3 roundToNearestFullPixel3(Vector3 vectorToChange)
  {
    vectorToChange = Camera.main.WorldToScreenPoint(vectorToChange);
    Vector2 screen2 = ScreenControler.gameToScreen2(ScreenControler.screenToGame(new Vector2()
    {
      x = vectorToChange.x,
      y = vectorToChange.y
    }));
    return Camera.main.ScreenToWorldPoint(new Vector3()
    {
      x = screen2.x,
      y = screen2.y,
      z = vectorToChange.z
    });
  }
}
