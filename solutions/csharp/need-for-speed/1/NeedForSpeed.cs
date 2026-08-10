class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    private int speed;
    private int batteryDrain;
    private int battery = 100;
    private int distance = 0;
    
    public RemoteControlCar(int speed, int batteryDrain)
    { 
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }
    
    public bool BatteryDrained()
    {
        return (battery < batteryDrain);
    }

    public int DistanceDriven()
    {
        return distance;
    }

    public void Drive()
    {
        if (BatteryDrained()) return;
        else 
        {
             battery -= batteryDrain;
            distance += speed;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    private int distance ;
    public RaceTrack(int distance)
    { 
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained()) 
        {
            car.Drive();
            if (car.DistanceDriven() >= distance) return true;
        }
        return false;
    }
}
