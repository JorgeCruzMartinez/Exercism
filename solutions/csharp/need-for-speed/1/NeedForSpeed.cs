using System;

class RemoteControlCar
{
    private int speed = 0;
    private int distanceDriven = 0;
    private int batteryDrain = 100;        
    private int batteryPercentage = 100;

    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed; // 100
        this.batteryDrain = batteryDrain; // 60
    }

     
    public bool BatteryDrained() => this.batteryPercentage < this.batteryDrain;

    public int DistanceDriven() => distanceDriven;

    public void Drive()
    {         
         if (!this.BatteryDrained())
         {
             distanceDriven += speed;
             batteryPercentage -= batteryDrain;
         }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar (50, 4);    
}

class RaceTrack
{
    private int distance = 0;
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    /* To finish a race track, a car has to be able to drive the track's distance. This means not       draining its battery before having crossed the finish line. Implement this method that takes a      RemoteControlCar instance as its parameter and returns true if the car can finish the race
    track, otherwise return false: */
public bool TryFinishTrack(RemoteControlCar car)
{
    while (!car.BatteryDrained())
    {
        car.Drive();
        if (car.DistanceDriven() >= this.distance)
            return true;                
    }
    return false;
}
}