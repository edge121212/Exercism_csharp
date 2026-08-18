class WeighingMachine
{
    // TODO: define the 'Precision' property
    public int Precision { get; }
    public WeighingMachine(int precision)
    {
        this.Precision = precision;
    }

    // TODO: define the 'Weight' property
    private double weight;
    public double Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            weight = value;
        }
    }

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment { get; set; } = 5.0;
    
    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get
        {
            double finalWeight = Weight - TareAdjustment;
            return $"{finalWeight.ToString($"F{Precision}")} kg";
        }
    }
}
