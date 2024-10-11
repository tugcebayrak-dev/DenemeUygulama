using DenemeUygulama.Data.Netsis;
using System;
using System.IO;

namespace DenemeUygulama.Data.Araclar
{
    public class FileOperation
    {
        public void CreateFolder(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    Directory.CreateDirectory(filePath);

            }
            catch (Exception ex)
            {
                Log.Instance.Yaz(ex.Message);
            }
        }
        public string GetExePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        public string[] GetFiles(string filePath)
        {
            try
            {
                return Directory.GetFiles(filePath);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
        }
        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string CopyFile(string sourceFile, string targetFile)
        {

            string fileName = new NetsisHelper().TurkceKarakterKullanma(Path.GetFileName(sourceFile));

            targetFile = Path.Combine(targetFile, fileName);

            try
            {
                File.Copy(sourceFile, targetFile, true);
            }

            catch (Exception ex)
            {
                Log.Instance.Yaz(ex.Message);
            }
            return targetFile;
        }

        public StreamWriter CreateText(string filePath)
        {
            return File.CreateText(@filePath);
        }
    }
}
