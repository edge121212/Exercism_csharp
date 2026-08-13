static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string finalDepartment;
        
        if (department == null)
        {
            finalDepartment = "OWNER";
        }
        else
        {
            finalDepartment = department.ToUpper();
        }

        if (id == null)
        {
            return $"{name} - {finalDepartment}";
        }
        else
        {
            return $"[{id}] - {name} - {finalDepartment}";
        }
    }
}
