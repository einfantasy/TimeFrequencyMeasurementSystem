using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSWord = Microsoft.Office.Interop.Word;

namespace TimeFrequencyMeasurementSystem.Functions
{
    public class WordHelper
    {
        // Word应用程序变量
        MSWord.Application wordApp;
        // Word文档变量
        MSWord.Document wordDoc;

        /// <summary>
        /// 通过模板创建新文档
        /// </summary>
        /// <param name="filePath">文档地址</param>
        public void CreateNewDocument(string filePath)
        {
            killWinWordProcess();
            wordApp = new MSWord.ApplicationClass();
            wordApp.DisplayAlerts = MSWord.WdAlertLevel.wdAlertsNone;
            wordApp.Visible = false;
            object missing = System.Reflection.Missing.Value;
            object templateName = filePath;
            wordDoc = wordApp.Documents.Open(ref templateName, ref missing,
              ref missing, ref missing, ref missing, ref missing, ref missing,
              ref missing, ref missing, ref missing, ref missing, ref missing,
              ref missing, ref missing, ref missing, ref missing);
        }

        /// <summary>
        /// 保存新文件
        /// </summary>
        /// <param name="filePath">保存地址</param>
        public void SaveDocument(string filePath)
        {
            object fileName = filePath;
            object format = MSWord.WdSaveFormat.wdFormatDocument;//保存格式
            object miss = System.Reflection.Missing.Value;
            wordDoc.SaveAs(ref fileName, ref format, ref miss,
              ref miss, ref miss, ref miss, ref miss,
              ref miss, ref miss, ref miss, ref miss,
              ref miss, ref miss, ref miss, ref miss,
              ref miss);
            //关闭wordDoc，wordApp对象
            object SaveChanges = MSWord.WdSaveOptions.wdSaveChanges;
            object OriginalFormat = MSWord.WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;
            wordDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            wordApp.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
        }

        //杀掉winword.exe进程
        private void killWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }

        /// <summary>
        /// 在书签处插入值
        /// </summary>
        /// <param name="bookmark">书签名称</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public bool InsertValue(string bookmark, string value)
        {
            object bkObj = bookmark;
            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
            {
                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();
                wordApp.Selection.TypeText(value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="bookmark">书签名称</param>
        /// <param name="picturePath">图片路径</param>
        /// <param name="width">宽度</param>
        /// <param name="hight">高度</param>
        public void InsertPicture(string bookmark, string picturePath, float width = 0, float hight = 0)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            Object linkToFile = false;    //图片是否为外部链接
            Object saveWithDocument = true; //图片是否随文档一起保存
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//图片插入位置
            wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocument, ref range);
            int index = wordDoc.Application.ActiveDocument.InlineShapes.Count;
            if (width != 0)
                wordDoc.Application.ActiveDocument.InlineShapes[index].Width = width; //设置图片宽度
            if (hight != 0)
                wordDoc.Application.ActiveDocument.InlineShapes[index].Height = hight; //设置图片高度
        }

        /// <summary>
        /// 插入表格
        /// </summary>
        /// <param name="bookmark">书签名称</param>
        /// <param name="rows">行数</param>
        /// <param name="columns">列数</param>
        /// <param name="width">宽度</param>
        /// <returns>表格引用</returns>
        public MSWord.Table InsertTable(string bookmark, int rows, int columns, float width)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            MSWord.Range range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//表格插入位置
            MSWord.Table newTable = wordDoc.Tables.Add(range, rows, columns, ref miss, ref miss);
            //设置表的格式
            newTable.Borders.Enable = 1; //允许有边框，默认没有边框(为0时报错，1为实线边框，2、3为虚线边框，以后的数字没试过)
            newTable.Borders.OutsideLineWidth = MSWord.WdLineWidth.wdLineWidth050pt;//边框宽度
            if (width != 0)
            {
                newTable.PreferredWidth = width;//表格宽度
            }
            newTable.AllowPageBreaks = false;
            return newTable;
        }

        /// <summary>
        /// 给表格中单元格插入元素
        /// </summary>
        /// <param name="table">所在表格</param>
        /// <param name="row">行号 从1开始</param>
        /// <param name="column">列号 从1开始</param>
        /// <param name="value">插入的元素</param>
        public void InsertCell(MSWord.Table table, int row, int column, string value)
        {
            table.Cell(row, column).Range.Text = value;
        }
    }
}
