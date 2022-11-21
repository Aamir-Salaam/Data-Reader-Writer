using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;

namespace Data_Reader_Writer.Helpers
{
    /// <summary>
    /// Helper to Get file path
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// Get complete path of the file based on fileName
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <returns>complete path of the file</returns>
        public static string GetPath(string fileName)
        {
            var filePath = Path.Combine(GetSolutionBasePath(), "Solution Items", "feed-products", fileName);

            return filePath;
        }

        /// <summary>
        /// Get base path for application
        /// </summary>
        /// <returns></returns>
        private static string GetSolutionBasePath()
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var binPosition = basePath.IndexOf("\\bin", StringComparison.Ordinal);

            if (binPosition > 0)
                basePath = basePath.Remove(binPosition);

            var backslashPosition = basePath.LastIndexOf("\\", StringComparison.Ordinal);
            if (backslashPosition > 0)
                basePath = basePath.Remove(backslashPosition);

            return basePath;
        }
    }
}
