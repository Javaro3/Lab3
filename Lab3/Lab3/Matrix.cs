using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Matrix
    {
        private int[,] _matrix;

        public Matrix(int[,] matrix)
        {
            _matrix = matrix;
        }

        public Matrix()
        {
            _matrix = new int[,]{};
        }

        public void CreateMatrix(int lines, int columns)
        {
            int[,] matrix = new int[lines, columns];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Matrix[{i+1},{j+1}] = ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            _matrix = matrix;
        }

        public void ShowMatrix()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write($"{_matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public int GetNumberOfColumns()
        {
            return _matrix.GetLength(1);
        }

        public int GetNumberOfLines()
        {
            return _matrix.GetLength(0);
        }

        public int GetIndexOfMatrix(int x, int y)
        {
            if(x >= 0 && x < _matrix.GetLength(0) && y >= 0 && y < _matrix.GetLength(1))
            {
                return _matrix[x, y];
            }
            return -1;
        }

        public int GetSumSquaredForOperator()
        {
            int sum = 0;
            foreach(var elem in _matrix)
            {
                if (elem > 0)
                {
                    sum += (int)Math.Pow(elem, 2);
                }
            }
            return sum;
        }

        public int GetSumSquerad()
        {
            int sum = 0;
            foreach (var elem in _matrix)
            {
                if (elem < 0)
                {
                    sum += (int)Math.Pow(elem, 2);
                }
            }
            return sum;
        }

        public int GetSumSquerad(int n)
        {
            int sum = 0;
            int min = _matrix[0, 0];
            int minLine = 0;
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] < min)
                    {
                        min = _matrix[i, j];
                        minLine = i;
                    }
                }
            }
            if(minLine + 1 <= _matrix.GetLength(0))
            {
                for (int i = minLine + 1; i < _matrix.GetLength(0); i++)
                {
                    if ((i+1) % n == 0)
                    {
                        for (int j = 0; j < _matrix.GetLength(1); j++)
                        {
                            if (_matrix[i, j] > 0)
                            {
                                sum += (int)Math.Pow(_matrix[i, j], 2);
                            }
                        }
                    }
                }
            }
            return sum;
        }

        public void ChangeElements(Matrix matrix)
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for(int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] < 0)
                    {
                        _matrix[i, j] = matrix.GetSumSquerad(3);
                    }
                }
            }
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix();
            if (matrix1._matrix.GetLength(0) == matrix2._matrix.GetLength(0) && matrix1._matrix.GetLength(1) == matrix2._matrix.GetLength(1))
            {
                result._matrix = new int[matrix1._matrix.GetLength(0), matrix1._matrix.GetLength(1)];
                for (int i = 0; i < matrix1._matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1._matrix.GetLength(1); j++)
                    {
                        result._matrix[i, j] = matrix1._matrix[i, j] - matrix2._matrix[i, j];
                    }
                }
            }
            return result;
        }

        public static bool operator <=(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.GetSumSquaredForOperator() <= matrix2.GetSumSquaredForOperator();
        }

        public static bool operator >=(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.GetSumSquaredForOperator() >= matrix2.GetSumSquaredForOperator();
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1._matrix.GetLength(0) == matrix2._matrix.GetLength(0) && matrix1._matrix.GetLength(1) == matrix2._matrix.GetLength(1))
            {
                for (int i = 0; i < matrix1._matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1._matrix.GetLength(1); j++)
                    {
                        if (matrix1._matrix[i, j] != matrix2._matrix[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1._matrix.GetLength(0) == matrix2._matrix.GetLength(0) && matrix1._matrix.GetLength(1) == matrix2._matrix.GetLength(1))
            {
                for (int i = 0; i < matrix1._matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1._matrix.GetLength(1); j++)
                    {
                        if (matrix1._matrix[i, j] != matrix2._matrix[i, j])
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            return true;
        }
    }
}
