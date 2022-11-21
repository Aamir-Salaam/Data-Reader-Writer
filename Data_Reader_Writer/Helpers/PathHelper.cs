using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;

namespace Data_Reader_Writer.Helpers
{
    public static class PathHelper
    {
        public static string GetPath(string fileName)
        {
            var filePath = Path.Combine(GetSolutionBasePath(), "Solution Items", "feed-products", fileName);

            return filePath;
        }

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
