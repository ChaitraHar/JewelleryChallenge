using JewelleryShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelleryShop.Helpers
{
    public interface IHomeHelper
    {
        #region Helper Methods
        Task WriteToFile(string filePath, string folderPath, string content);

        #endregion Helper Methods
    }
}
