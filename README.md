EventBus
========

EventBus is a Portable Class Library adding simple functionality for publish-subscribe-style communication between components without requiring them to explicitly register with one another. This removes the necessity of passing callbacks into methods.


Sample Usage
------------

```C#
public class SomeClass
{
  //Register your instance to subscribe to events
  public SomeClass()
  {
    BusProvider.Instance.Register(this);
  }

  //Subscribe to a specific event, specified by the argument type
  [Subscribe]
  public void OnResult(ResultEvent e)
  {
    //do something with the result
  }
  
  //Unregister your instance when you're done with it, to prevent memory leaks
  public void Unregister()
  {
    BusProvider.Instance.Unregister(this);
  }
}

public class PublishingClass
{
    public PublishingClass(){
      //Publish result to all subscribed methods of registered classes
      BusProvider.Instance.Post(new ResultEvent("this is awesome!"));
    }
}
```
