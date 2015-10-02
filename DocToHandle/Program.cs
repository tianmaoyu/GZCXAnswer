using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace DocToHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            ////提取doc中的182个题目以及答案 ^\d+..*[^。]
            //FileStream fileStream=new FileStream("G:\\答题助手数据\\doc.txt",FileMode.OpenOrCreate);
            //StreamReader streamReader = new StreamReader(fileStream, Encoding.GetEncoding("GB2312"));
            //string input = streamReader.ReadToEnd();
            //string pattern = @"^\d+..*。";
            //Regex rgx = new Regex(pattern,RegexOptions.Multiline);
            //MatchCollection matches = rgx.Matches(input);
            //string[] str = new string[matches.Count];
            //if (matches.Count > 0)
            //{
            //    int i = 0;
            //    foreach (Match match in matches)
            //    {
            //        str[i] = match.Value;
            //        i++;
            //    }
            //}
            //streamReader.Close();
            //fileStream.Close();
            ////上面提取的题目放入dochandle.txt
            //FileStream fileStream1 = new FileStream("G:\\答题助手数据\\dochandle.txt", FileMode.OpenOrCreate);
            //StreamWriter streamWriter = new StreamWriter(fileStream1, Encoding.GetEncoding("GB2312"));
            //foreach (string s in str)
            //{
            //    streamWriter.WriteLine(s);
            //}
            //streamWriter.Close();
            //fileStream1.Close();
            //提取答案
            //FileStream fileStream = new FileStream("G:\\答题助手数据\\2015多选.txt", FileMode.OpenOrCreate);
            //StreamReader streamReader = new StreamReader(fileStream, Encoding.GetEncoding("GB2312"));
            //string input = streamReader.ReadToEnd();
            //string pattern = @"（[\w]+）";
            //Regex rgx = new Regex(pattern, RegexOptions.Multiline);
            //MatchCollection matches = rgx.Matches(input);
            //string[] str = new string[matches.Count];
            //if (matches.Count > 0)
            //{
            //    int i = 0;
            //    foreach (Match match in matches)
            //    {
            //        str[i] = match.Value;
            //        i++;
            //    }
            //}
            //streamReader.Close();
            //fileStream.Close();
            ////上面提取的题目放入dochandle.txt
            //FileStream fileStream1 = new FileStream("G:\\答题助手数据\\多选.txt", FileMode.OpenOrCreate);
            //StreamWriter streamWriter = new StreamWriter(fileStream1, Encoding.GetEncoding("GB2312"));
            //foreach (string s in str)
            //{
            //    streamWriter.WriteLine(s);
            //}
            //streamWriter.Close();
            //fileStream1.Close();
            //重新组装
            //FileStream fileStream = new FileStream("G:\\答题助手数据\\2015多选.txt", FileMode.OpenOrCreate);
            //StreamReader streamReader = new StreamReader(fileStream, Encoding.GetEncoding("GB2312"));
            //while (streamReader.Peek() != null)
            //{
            //    string s = HandleString(streamReader.ReadLine());
            //}
            List<string> strList=new List<string>();
            List<string> strList1=new List<string>();
            var lines = File.ReadAllLines("G:\\答题助手数据\\2015对错.txt", Encoding.GetEncoding("GB2312"));
            foreach (string s in lines)
            {
                var s1 = HandleString(s);
                strList.Add(s1);
            }
            var lines1 = File.ReadAllLines("G:\\答题助手数据\\对错.txt", Encoding.GetEncoding("GB2312"));
            foreach (string s in lines1)
            {
                string s1 = s.Replace("（", "");
                 s1 = s1.Replace("(", "");
                 s1 = s1.Replace(")", "");
                 s1 = s1.Replace("）", "");
                 s1 = s1.Trim();
                strList1.Add(s1);
            }
            FileStream aFileStream = new FileStream("G:\\答题助手数据\\2015对错拼装.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFileStream, Encoding.GetEncoding("GB2312"));
            int i = 0;
            foreach (string answer in strList)
            {
                sw.Write("\"" +i+ "." + answer + ":"+strList1[i]+"\"" + ",");
                i++;
            }
            sw.Close();
            aFileStream.Close();
          
        }

        public static string HandleString(string s)
        {
            string reslut = null;
            if (s != null)
            {
                string s1 = s;
                s1 = s1.Replace("（", "");
                s1 = s1.Replace("。", "");
                s1 = s1.Replace("）", "");
                s1 = s1.Replace("，", "");
                s1 = s1.Replace("：", "");
                s1 = s1.Replace("？", "");
                s1 = s1.Replace("?", "");
                s1 = s1.Replace("“", "");
                s1 = s1.Replace("”", "");
                s1 = s1.Replace("√", "");
                s1 = s1.Replace("×", "");
                s1 = s1.Replace("A", "");
                s1 = s1.Replace("B", "");
                s1 = s1.Replace("C", "");
                s1 = s1.Replace("D", "");
                s1 = s1.Replace("1", "");
                s1 = s1.Replace("2", "");
                s1 = s1.Replace("3", "");
                s1 = s1.Replace("4", "");
                s1 = s1.Replace("5", "");
                s1 = s1.Replace("6", "");
                s1 = s1.Replace("7", "");
                s1 = s1.Replace("9", "");
                s1 = s1.Replace("0", "");
                s1 = s1.Replace("8", "");
                s1 = s1.Replace(".", "");
                s1 = s1.Replace("、", "");
                s1 = s1.Replace(" ", "");
                s1 = s1.Replace(",", "");
                s1 = s1.Replace("问题", "");
                s1 = s1.Replace("；", "");
                s1 = s1.Replace("(", "");
                s1 = s1.Replace(")", "");
                s1 = s1.Trim();
                reslut = s1;
            }
            return reslut;
        }
    }
}
