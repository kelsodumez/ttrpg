using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;

public static class TurnManager 
{
    private static TimeSchedule _timeSchedule = new();

    public static void Init()
    {
        NextActorTurn();
    }

    public static void NextActorTurn()
    {
        IActor nextActor = _timeSchedule.NextEvent();
        // TODO add stuff for 'unpausing' characters when its their turn
        nextActor.Unpause();

        _timeSchedule.ScheduleEvent(nextActor, nextActor.GetActorInititiative());
    }

    public static void RegisterActor(IActor actor, float delay)
    {
        _timeSchedule.ScheduleEvent(actor, delay);
    }

    public static TimeSchedule GetTimeSchedule()
    {
        return _timeSchedule;
    }
}