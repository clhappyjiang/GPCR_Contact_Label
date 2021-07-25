using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowContact.util
{
    [Serializable]
    class StringMatrix
    {
        public string[] element;
        private int rows = 0;
        private int cols = 0;
        /// <summary>
        /// 获取矩阵行数
        /// </summary>
        public int Rows
        {
            get
            {
                return rows;
            }
        }
        /// <summary>
        /// 获取矩阵列数
        /// </summary>
        public int Cols
        {
            get
            {
                return cols;
            }
        }

        /// <summary>
        /// 用二维数组初始化Matrix
        /// </summary>
        /// <param name="m">二维数组</param>
        public StringMatrix(string[,] m)
        {
            this.rows = m.GetLength(0);
            this.cols = m.GetLength(1);
            int count = 0;
            this.element = new string[Rows * Cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    element[count++] = m[i,j];
                }
            }
        }

        /// <summary>
        /// 获取或设置第i行第j列的元素值
        /// </summary>
        /// <param name="i">第i行</param>
        /// <param name="j">第j列</param>
        /// <returns>返回第i行第j列的元素值</returns>
        public string this[int i, int j]
        {
            get
            {
                if (i < Rows && j < Cols)
                {
                    return element[i * cols + j];
                }
                else
                {
                    throw new Exception("索引越界");
                }
            }
            set
            {
                element[i * cols + j] = value;
            }
        }

        public override string ToString()
        {
            string str = "";
           
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (j == 0)
                    {
                        str = str + this[i, j].ToString();

                    }
                    else
                    {
                        str = str + "," + this[i, j].ToString();

                    }

                    if (j != Cols - 1)
                        str += " ";
                    else if (i != Rows - 1)
                        str += Environment.NewLine;
                }
            }

            return str;
        }
    }
}
