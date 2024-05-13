using System.Collections;
using System.Collections.Generic;
using Priority_Queue;
using UnityEngine;

public class TimeSchedule
{
    private SimplePriorityQueue<IActor, float> _scheduledEvents = new();
    
    public void ScheduleEvent(IActor _event, float delay)
    {
        if (_event is not null)
        {
            _scheduledEvents.Enqueue(_event, delay);
        }
    }

    public IActor NextEvent()
    {
        (IActor _nextEvent, float time) = _scheduledEvents.DequeueWithPriority();
        AdjustPriorities(-time);

        return _nextEvent;
    }

    public void CancelEvent(IActor _event)
    {
        _scheduledEvents.Remove(_event);
    }  

    private void AdjustPriorities(float add)
    {
        // Debug.Log(_scheduledEvents.Count);
        foreach (IActor _event in _scheduledEvents)
        {
            _scheduledEvents.UpdatePriority(_event, _scheduledEvents.GetPriority(_event) + add);
        }
    }

    public SimplePriorityQueue<IActor, float> GetScheduledEvents()
    {
        return _scheduledEvents;
    }
}