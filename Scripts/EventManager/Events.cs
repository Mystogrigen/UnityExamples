using UnityEngine;

namespace UnityExamples
{
public static class Events
{
  public static GameOverEvent GameOverEvent = new();
  public static PlayerDeathEvent PlayerDeathEvent = new();
}
public class GameOverEvent : GameEvent  {  public bool Win;  }
public class PlayerDeathEvent : GameEvent {  }
}
