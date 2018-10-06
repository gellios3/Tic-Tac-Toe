namespace Services
{
    public class MapService
    {
        /// <summary>
        /// Game map
        /// </summary>
        public int[][] Map { get; } =
        {
            new[] {0, 0, 0},
            new[] {0, 0, 0},
            new[] {0, 0, 0}
        };
        
        /// <summary>
        /// Update cell
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="position"></param>
        public void UpdateCell(int[] cell, int position)
        {
            Map[position] = cell;

        }
        
        /// <summary>
        /// Is all fields the same
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        public bool IsAllFieldsTheSame(int posX, int posY, int dx, int dy)
        {
            var firstField = Map[posY][posX];
            if (firstField == 0)
            {
                return false;
            }

            for (var i = 0; i < 3; i++)
            {
                var y = posY + dy * i;
                var x = posX + dx * i;
                if (Map[y][x] != firstField)
                {
                    return false;
                }
            }

            return true;
        }
        
      
    }
}