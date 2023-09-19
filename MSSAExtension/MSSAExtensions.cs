using System.Numerics;
using System.Security.Cryptography;

namespace MssaExtension
{
    public enum StringFormat
    {
        Base64,
        Hex
    }
    public static class MSSAExtensions
    {
        public static string GetSHAString(this FileInfo _file, StringFormat format = StringFormat.Hex)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] fileHash = sha1.ComputeHash(_file.OpenRead());
                return format switch
                {
                    StringFormat.Base64 => Convert.ToBase64String(fileHash),
                    StringFormat.Hex => Convert.ToHexString(fileHash).ToLower(),
                    _ => Convert.ToBase64String(fileHash),
                };

            }

        }
        public static T Median<T>(this IEnumerable<T> _intArr)
        {
            var sorted = _intArr.OrderBy(x => x).ToList(); //Arranges List numerically
            var middleItem = sorted.Count / 2; //Finds middle by pulling count
                                               //if(sorted.Count % 2 == 1) 
            { return sorted[middleItem]; } //if odd return middle Item
                                           // else 
                                           //   {return  ((float)sorted[middleItem] + (float)sorted[middleItem - 1]) / 2;
        } //if even find average of 2
    }
}