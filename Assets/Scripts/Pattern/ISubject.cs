using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//base class for the subject
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();

}


