using System.Text.RegularExpressions;

namespace lovedmemory.application.Utils
{
    public static partial class SlugGenerator
    {
        public static string GenerateSlug(string phrase)
        {
            try
            {
                // Remove all non-alphanumeric characters from the input string
                string slug = MyRegex().Replace(phrase, string.Empty);

                // Convert the string to lowercase
                slug = slug.ToLower();

                // Replace whitespace characters with hyphens
                slug = Regex.Replace(slug, @"\s+", "-");

                // Remove any leading or trailing hyphens
                slug = slug.Trim('-');

                return slug;
            }
            catch (Exception ex)
            {
                return phrase;
            }
        }

        [GeneratedRegex(@"[^a-zA-Z0-9\s]")]
        private static partial Regex MyRegex();
    }
}
