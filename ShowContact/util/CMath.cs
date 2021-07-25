using System;
using System.Collections.Generic;

namespace ShowContact
{
    [Serializable]
    public class Matrix
    {
        public int[] element;
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
        /// 获取或设置第i行第j列的元素值
        /// </summary>
        /// <param name="i">第i行</param>
        /// <param name="j">第j列</param>
        /// <returns>返回第i行第j列的元素值</returns>
        public int this[int i, int j]
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
        /// <summary>
        /// 用二维数组初始化Matrix
        /// </summary>
        /// <param name="m">二维数组</param>
        public Matrix(int[][] m)
        {
            this.rows = m.GetLength(0);
            this.cols = m.GetLength(1);
            int count = 0;
            this.element = new int[Rows * Cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    element[count++] = m[i][j];
                }
            }
        }
      
        public Matrix(int[,] m)
        {
            this.rows = m.GetLength(0);
            this.cols = m.GetLength(1);
            this.element = new int[this.rows * this.cols];
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    element[count++] = m[i, j];
                }
            }
        }
        public Matrix(List<List<int>> m)
        {
            this.rows = m.Count;
            this.cols = m[0].Count;
            this.element = new int[Rows * Cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this[i, j] = m[i][j];
                }
            }
        }
        #region 矩阵数学运算
        public static Matrix MAbs(Matrix a)
        {
            Matrix _thisCopy = a.DeepCopy();
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    _thisCopy[i, j] = Math.Abs(a[i, j]);
                }
            }
            return _thisCopy;
        }
        /// <summary>
        /// 矩阵相加
        /// </summary>
        /// <param name="a">第一个矩阵,和b矩阵必须同等大小</param>
        /// <param name="b">第二个矩阵</param>
        /// <returns>返回矩阵相加后的结果</returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.cols == b.cols && a.rows == b.rows)
            {
                int[,] res = new int[a.rows, a.cols];
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Cols; j++)
                    {
                        res[i, j] = a[i, j] + b[i, j];
                    }
                }
                return new Matrix(res);
            }
            else
            {
                throw new Exception("两个矩阵行列不相等");
            }
        }
        /// <summary>
        /// 矩阵相减
        /// </summary>
        /// <param name="a">第一个矩阵,和b矩阵必须同等大小</param>
        /// <param name="b">第二个矩阵</param>
        /// <returns>返回矩阵相减后的结果</returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.cols == b.cols && a.rows == b.rows)
            {
                int[,] res = new int[a.rows, a.cols];
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Cols; j++)
                    {
                        res[i, j] = a[i, j] - b[i, j];
                    }
                }
                return new Matrix(res);
            }
            else
            {
                throw new Exception("两个矩阵行列不相等");
            }
        }
        /// <summary>
        /// 对矩阵每个元素取相反数
        /// </summary>
        /// <param name="a">二维矩阵</param>
        /// <returns>得到矩阵的相反数</returns>
        public static Matrix operator -(Matrix a)
        {
            Matrix res = a;
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.cols; j++)
                {
                    res.element[i * a.cols + j] = -res.element[i * a.cols + j];
                }
            }
            return res;
        }
        /// <summary>
        /// 矩阵相乘
        /// </summary>
        /// <param name="a">第一个矩阵</param>
        /// <param name="b">第二个矩阵,这个矩阵的行要与第一个矩阵的列相等</param>
        /// <returns>返回相乘后的一个新的矩阵</returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.cols == b.rows)
            {
                int[,] res = new int[a.rows, b.cols];
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.cols; j++)
                    {
                        for (int k = 0; k < a.cols; k++)
                        {
                            res[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
                return new Matrix(res);
            }
            else
            {
                throw new Exception("两个矩阵行和列不等");
            }
        }
        /// <summary>
        /// 矩阵与数相乘
        /// </summary>
        /// <param name="a">第一个矩阵</param>
        /// <param name="num">一个实数</param>
        /// <returns>返回相乘后的新的矩阵</returns>
        public static Matrix operator *(Matrix a, int num)
        {
            Matrix res = a;
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.cols; j++)
                {
                    res.element[i * a.cols + j] *= num;
                }
            }
            return res;
        }
        /// <summary>
        /// 矩阵转置
        /// </summary>
        /// <returns>返回当前矩阵转置后的新矩阵</returns>
        public Matrix Transpose()
        {
            int[,] res = new int[cols, rows];
            {
                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        res[i, j] = this[j, i];
                    }
                }
            }
            return new Matrix(res);
        }
      
        #region 重载比较运算符
        public static bool operator <(Matrix a, Matrix b)
        {
            bool issmall = true;
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    if (a[i, j] >= b[i, j]) issmall = false;
                }
            }
            return issmall;
        }
        public static bool operator >(Matrix a, Matrix b)
        {
            bool issmall = true;
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    if (a[i, j] <= b[i, j]) issmall = false;
                }
            }
            return issmall;
        }
        public static bool operator <=(Matrix a, Matrix b)
        {
            bool issmall = true;
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    if (a[i, j] > b[i, j]) issmall = false;
                }
            }
            return issmall;
        }
        public static bool operator >=(Matrix a, Matrix b)
        {
            bool issmall = true;
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    if (a[i, j] < b[i, j]) issmall = false;
                }
            }
            return issmall;
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            bool issmall = true;
            issmall = ReferenceEquals(a, b);
            if (issmall) return issmall;
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    if (a[i, j] == b[i, j]) issmall = false;
                }
            }
            return issmall;
        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            bool issmall = true;
            issmall = ReferenceEquals(a, b);
            if (issmall) return issmall;
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    if (a[i, j] != b[i, j]) issmall = false;
                }
            }
            return issmall;
        }
        public override bool Equals(object obj)
        {
            Matrix b = obj as Matrix;
            return this == b;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        public int Determinant()
        {
            if (cols == rows)
            {
                Matrix _thisCopy = this.DeepCopy();
                //行列式每次交换行，都需要乘以-1
                int res = 1;
                for (int i = 0; i < rows; i++)
                {
                    //首先找到第i列的绝对值最大的数
                    int rowMax = i;
                    int max = Math.Abs(_thisCopy[i, i]);
                    for (int j = i; j < rows; j++)
                    {
                        if (Math.Abs(_thisCopy[j, i]) > max)
                        {
                            rowMax = j;
                            max = Math.Abs(_thisCopy[j, i]);
                        }
                    }
                    //将第i行和找到最大数那一行rowMax交换,同时将单位阵做相同初等变换
                    if (rowMax != i)
                    {
                        _thisCopy.Exchange(i, rowMax);
                        res *= -1;
                    }
                    //消元
                    for (int j = i + 1; j < rows; j++)
                    {
                        int r = -_thisCopy[j, i] / _thisCopy[i, i];
                        _thisCopy.Exchange(i, j, r);
                    }
                }
                //计算对角线乘积
                for (int i = 0; i < rows; i++)
                {
                    res *= _thisCopy[i, i];
                }
                return res;
            }
            else
            {
                throw new Exception("不是行列式");
            }
        }
        #endregion
        #region 初等变换
        /// <summary>
        /// 初等变换：交换第r1和第r2行
        /// </summary>
        /// <param name="r1">第r1行</param>
        /// <param name="r2">第r2行</param>
        /// <returns>返回交换两行后的新的矩阵</returns>
        public Matrix Exchange(int r1, int r2)
        {
            if (Math.Min(r2, r1) >= 0 && Math.Max(r1, r2) < rows)
            {
                for (int j = 0; j < cols; j++)
                {
                    int temp = this[r1, j];
                    this[r1, j] = this[r2, j];
                    this[r2, j] = temp;
                }
                return this;
            }
            else
            {
                throw new Exception("超出索引");
            }
        }
        /// <summary>
        /// 初等变换：将r1行乘以某个数加到r2行
        /// </summary>
        /// <param name="r1">第r1行乘以num</param>
        /// <param name="r2">加到第r2行，若第r2行为负，则直接将r1乘以num并返回</param>
        /// <param name="num">某行放大的倍数</param>
        /// <returns></returns>
        public Matrix Exchange(int r1, int r2, int num)
        {
            if (Math.Min(r2, r1) >= 0 && Math.Max(r1, r2) < rows)
            {
                for (int j = 0; j < cols; j++)
                {
                    this[r2, j] += this[r1, j] * num;
                }
                return this;
            }
            else if (r2 < 0)
            {
                for (int j = 0; j < cols; j++)
                {
                    this[r1, j] *= num;
                }
                return this;
            }
            else
            {
                throw new Exception("超出索引");
            }
        }
        /// <summary>
        /// 得到一个同等大小的单位矩阵
        /// </summary>
        /// <returns>返回一个同等大小的单位矩阵</returns>
        public Matrix EMatrix()
        {
            if (rows == cols)
            {
                int[,] res = new int[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (i == j)
                            res[i, j] = 1;
                        else
                            res[i, j] = 0;
                    }
                }
                return new Matrix(res);
            }
            else
                throw new Exception("不是方阵，无法得到单位矩阵");
        }
        #endregion
        /// <summary>
        /// 深拷贝，仅仅将值拷贝给一个新的对象
        /// </summary>
        /// <returns>返回深拷贝后的新对象</returns>
        public Matrix DeepCopy()
        {
            int[,] ele = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ele[i, j] = this[i, j];
                }
            }
            return new Matrix(ele);
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
                        str = str+this[i, j].ToString();

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