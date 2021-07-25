using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using System.Management;

namespace ShowContact
{
    public class FormPublic
    {
        


        //filepath�����ļ��ı���·��
        public static string ReadLog(String filepath)
        {
            string text = "";
            try
            {
                text = System.IO.File.ReadAllText(filepath);
            }
            catch (IOException e)
            {
            }
            return text;
        }

        //filepath�����ļ��ı���·��
        public static void WriteLog(String filepath, String contents)
        {
            string text = contents;
            try
            {
                System.IO.File.WriteAllText(filepath, text);
            }
            catch (IOException e)
            {
            }
        }

        /// <summary>
        /// ��ȡ����ģ������
        /// </summary>
        /// <param name="fileName">ģ���ļ�����</param>
        /// <returns>ģ������</returns>
        public static List<string> GetFlieContentByLine(string filePath, bool hasHead)
        {
            // ��ȡ�ļ�
            List<string> lineContent = new List<string>();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return null;
            }
            try
            {
                string lineStr;//��¼�ļ���������

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    StreamReader sr = new StreamReader(fs);
                    if (!hasHead)
                    {
                        lineStr = sr.ReadLine();

                    }

                    while (sr.Peek() != -1)
                    {
                        lineStr = sr.ReadLine();

                        lineContent.Add(lineStr);
                    }

                    sr.Close();
                    fs.Close();
                }
            }
            catch (IOException er)
            {
                MessageBox.Show(string.Format("�ļ���ȡ������Ϣ={0},��ջ={1}", er.Message, er.StackTrace));
            }
            return lineContent;
        }

    }
}
