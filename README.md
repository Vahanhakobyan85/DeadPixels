# DeadPixels
Calculating the dead pixel groups in matrix's.
Used DFS algorithm here.

The task is the following:
2. You have a map of the monitor's pixels where good pixels are marked with zeros and dead pixels are marked with ones.
Write a code that returns the number of dead pixel groups.
If two pixels are adjacent to each other vertically or horizontally (not by diagonally), they are considered a part of one group.

Example 1: input - [1,0,1], output - 4
				   [0,0,0],
				   [1,0,1]
				   
Example 2: input - [1,1,1], output - 2
				   [1,0,0],
				   [1,0,1]
				   
public class DeadPixels
{
	public int CountGroups(int[][] monitor)
	{
		//Your solution goes here
	}
}
