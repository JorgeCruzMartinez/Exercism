public static class Badge
{
    /* Employees have an ID, name and department name. Employee badge labels are formatted as follows: "[id] - name - DEPARTMENT". Implement the (static) Badge.Print() method to return an employee's badge label like this:
      
      Badge.Print(734, "Ernest Johnny Payne", "Strategic Communication");
     => "[734] - Ernest Johnny Payne - STRATEGIC COMMUNICATION" */
    
     public static string Print(int? id, string name, string? department) =>
     $"{(id.HasValue ? $"[{id.Value}] - " : "")}{(name?.Trim() ?? "")} - {(string.IsNullOrWhiteSpace(department) ? "OWNER" : department!.ToUpperInvariant().Trim())}";
}