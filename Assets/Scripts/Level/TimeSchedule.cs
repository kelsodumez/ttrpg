using System.Collections;
using System.Collections.Generic;
using Priority_Queue;
using UnityEngine;

public class TimeSchedule
{
    private SimplePriorityQueue<GameObject, float> _scheduledEvents = new();
    
    public void ScheduleEvent(GameObject _event, float delay = 0f)
    {
        if (_event is not null)
        {
            _scheduledEvents.Enqueue(_event, delay);
        }
    }

    public GameObject NextEvent()
    {
        (GameObject _nextEvent, float time) = _scheduledEvents.DequeueWithPriority();
        _scheduledEvents.AdjustPriorities(-time);

        return _nextEvent;
    }

    public void CancelEvent(GameObject _event)
    {
        _scheduledEvents.Remove(_event);
    }  
}