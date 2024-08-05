using System.Text.RegularExpressions;

namespace lovedmemory.application.Utils
{
    public static class SlugGenerator
    {
        public static string GenerateSlug(string phrase)
        {
            // Remove all non-alphanumeric characters from the input string
            string slug = Regex.Replace(phrase, @"[^a-zA-Z0-9\s]", string.Empty);

            // Convert the string to lowercase
            slug = slug.ToLower();

            // Replace whitespace characters with hyphens
            slug = Regex.Replace(slug, @"\s+", "-");

            // Remove any leading or trailing hyphens
            slug = slug.Trim('-');

            return slug;
        }
    }
}
