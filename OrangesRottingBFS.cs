public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        if (grid == null || grid.Length == 0)
        {
            return -1;
        }
        int m = grid.Length;
        int n = grid[0].Length;
        int count = 0;
        Queue<int[]> queue = new Queue<int[]>();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    count++;    //6
                }
                if (grid[i][j] == 2)
                {
                    queue.Enqueue(new int[2] { i, j }); //{0,0}
                }
            }
        }
        if (count == 0)
        {
            return 0;
        }
        // Console.WriteLine($"Before BFS {count}");
        int[][] dirs = [[0, -1], [0, 1], [-1, 0], [1, 0]];//new int[4][]{{0,-1},{0,1},{-1,0},{0,1}};
        int time = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count; //1
            for (int i = 0; i < size; i++)
            {
                var cell = queue.Dequeue(); // 0
                foreach (var dir in dirs)
                {
                    var newRow = cell[0] + dir[0];
                    var newCol = cell[1] + dir[1];
                    if (newRow < 0 || newRow == m || newCol < 0 || newCol == n || grid[newRow][newCol] != 1)
                    {
                        continue;
                    }
                    queue.Enqueue(new int[2] { newRow, newCol });
                    grid[newRow][newCol] = 2;
                    count--;
                }
            }
            time++;
        }
        // Console.WriteLine($"After BFS {count}");
        if (count != 0)
        {
            return -1;
        }
        return time - 1;
    }
}