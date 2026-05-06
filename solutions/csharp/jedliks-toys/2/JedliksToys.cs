 class RemoteControlCar
{
     private int _distance;
     private int _batteryPercentage = 100;

     public int BatteryPercentage
     {
         get
         {
             return _batteryPercentage;
         }
         set
         {
             if (BatteryPercentage > 0)                
                 _batteryPercentage = BatteryPercentage;
             else
                 _batteryPercentage = 0;
         }
     }

     public static RemoteControlCar Buy() => new();
     
     public string DistanceDisplay() => $"Driven {_distance} meters";
     
     public string BatteryDisplay()
     {
         if (_batteryPercentage == 0)
         {
             return "Battery empty";
         }

         return $"Battery at {_batteryPercentage}%";
     }
     
     public void Drive()
     {
    	if(_batteryPercentage >= 1)
    	{
    		_distance += 20;
    		_batteryPercentage -= 1;
    	}
     }
}