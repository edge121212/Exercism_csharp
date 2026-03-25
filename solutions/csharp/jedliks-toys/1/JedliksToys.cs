class RemoteControlCar
{
    private int _drivenDistance = 0;
    private int _batteryRemain = 100;
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_drivenDistance} meters";
    }

    public string BatteryDisplay()
    {
        if (_batteryRemain == 0){
            return "Battery empty";
        }
        else{
            return $"Battery at {_batteryRemain}%";
        }
    }

    public void Drive()
    {
        if (_batteryRemain == 0){
            return;
        }
        _drivenDistance += 20;
        _batteryRemain -= 1;
    }
}
