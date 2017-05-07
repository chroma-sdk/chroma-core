using System.Threading.Tasks;
using Chroma.NetCore.Api.Exceptions;
using Newtonsoft.Json;

namespace Chroma.NetCore.Api.Chroma
{
    public class Grid
    {
        public int Rows { get; }
        public int Cols { get; }
        private Color[,] Matrix { get; }

        private readonly Color intialColor;

        public Grid(int rows, int cols, Color initialColor = null)
        {
            Rows = rows;
            Cols = cols;
            this.intialColor = initialColor ?? Color.Black;
            this.Matrix = new Color[rows,cols];
        }


        public bool SetPosition(int row, int col, Color color)
        {
            if (!CheckBounds(row, col))
                return false;

            //Set color for position in matrix grid
            Matrix[row, col] = color;

            return true;
        }

        public bool SetRow(int col, Color color)
        {
            if (!CheckBounds(0, col))
                return false;

            for(int r = 0; r < Rows; r++)
            {
                Matrix[r, col] = color;
            }

            return true;
        }


        public bool SetCol(int row, Color color)
        {
            if (!CheckBounds(row, 0))
                return false;

            for (int c = 0; c < Cols; c++)
            {
                Matrix[row, c] = color;
            }

            return true;
        }

        public string ToJson()
        {
            int [,] convertMatrix  = new int[Rows,Cols];

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Matrix[r, c] = Matrix[r, c] ?? intialColor;
                    convertMatrix[r, c] = Matrix[r, c].ToBgr();
                }
            }

            var json = JsonConvert.SerializeObject(convertMatrix, Formatting.Indented);
            return json;
        }

        public Color GetPosition(int row, int col)
        {
            return !CheckBounds(row, col) ? null : Matrix[row, col];
        }

        private bool CheckBounds(int row, int col)
        {
            if (Rows <= row || row < 0)
                throw new ChromaNetCoreApiException($"The row index is out of range {row}");
            if (Cols <= col || col < 0)
                throw new ChromaNetCoreApiException($"The column index is out of range {col}");

            return true;
        }
    }
}
