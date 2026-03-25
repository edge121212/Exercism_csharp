class BirdCount
{
    private int[] birdsPerDay;
    private static int[] lastWeek = {0, 2, 5, 3, 7, 8, 4};
    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return lastWeek;
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int day in birdsPerDay){
            if (day == 0) return true;
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        for (int i = 0; i < numberOfDays; i++){
            count += birdsPerDay[i];
        }
        return count;
    }

    public int BusyDays()
    {
        int busyDay = 0;
        foreach (int day in birdsPerDay){
            if (day >= 5){
                busyDay++;    
            } 
        }
        return busyDay;
    }
}
