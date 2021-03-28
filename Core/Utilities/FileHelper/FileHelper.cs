using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        //public static string Add(IFormFile file)
        //{
        //    var sourcepath = Path.GetTempFileName();
        //    if (file.Length > 0)
        //    {
        //        using (var stream = new FileStream(sourcepath, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //    }
        //    var result = newPath(file);
        //    File.Move(sourcepath, result);
        //    return result;
        //}

        public static string Add(IFormFile image)
        {
            string directory = Environment.CurrentDirectory + @"\wwwroot";
            string fileName = CreateNewFileName(image.FileName); 
            string path = Path.Combine(directory, "Images"); 

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
                    }

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            { 
                image.CopyTo(stream); 
            }

            string filePath = Path.Combine(path, fileName);
                return fileName ;
        }

        public static string CreateNewFileName(string fileName)
        {
            string[] file = fileName.Split('.');
            string extension = file[1];
            string newFileName = string.Format(@"{0}." + extension, Guid.NewGuid()); return newFileName;
        }



        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + @"\Images";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
