/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/

class Solution
{
    public int GetImportance(IList<Employee> employees, int id)
    {
        if (employees == null || employees.Count == 0)
        {
            return 0;
        }

        int total = 0;
        Dictionary<int, Employee> lookup = new Dictionary<int, Employee>();
        foreach (var emp in employees)
        {
            lookup.TryAdd(emp.id, emp);
        }
        Queue<Employee> queue = new Queue<Employee>();
        queue.Enqueue(lookup[id]);

        while (queue.Count > 0)
        {
            var employee = queue.Dequeue();
            total += employee.importance;
            foreach (var sub in employee.subordinates)
            {
                queue.Enqueue(lookup[sub]);
            }
        }

        return total;
    }
}