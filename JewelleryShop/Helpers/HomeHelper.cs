using JewelleryShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JewelleryShop.Helpers
{
    public class HomeHelper : IHomeHelper
    {
        #region Constructor
        
        public HomeHelper()
        {
        }

        #endregion

        #region public methods      
        
        /// <summary>
        /// Writes content into text file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="folderPath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task WriteToFile(string filePath, string folderPath, string content)
        {
            if (!System.IO.File.Exists(filePath))
            { 
                Directory.CreateDirectory(folderPath);               
            }
            await System.IO.File.WriteAllTextAsync(filePath, content);
        }

        #endregion       
    }
}
