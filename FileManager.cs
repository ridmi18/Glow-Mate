using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GlowMate
{
    internal class FileManager
    {
        /// <summary>
        /// Saves a list of strings to a text file at the given path.
        /// </summary>
        /// <param name="filePath">The full path of the file to save.</param>
        /// <param name="lines">The list of lines to write to the file.</param>
        public void SaveToFile(string filePath, List<string> lines)
        {
            File.WriteAllLines(filePath, lines);
        }
    }
}
