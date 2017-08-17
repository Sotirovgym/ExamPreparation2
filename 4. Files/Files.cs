using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Files
{
    class Files
    {
        static void Main()
        {
            Dictionary<string, SortedDictionary<string, long>> data = new Dictionary<string, SortedDictionary<string, long>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] filesTokens = input.Split(';');
                long fileSize = long.Parse(filesTokens[1]);

                string[] filePathElements = filesTokens[0].Split('\\');
                string root = filePathElements[0];
                string file = filePathElements[filePathElements.Length - 1];

                if (!data.ContainsKey(root))
                {
                    data.Add(root, new SortedDictionary<string, long>());
                }

                data[root][file] = fileSize;
            }

            string[] inputTokens = Console.ReadLine().Split(new string[] { " in " }, StringSplitOptions.RemoveEmptyEntries);
            string extensionToSearch = "." + inputTokens[0];
            string rootToSearch = inputTokens[1];

            bool rootExists = false;
            bool extensionExists = false;

            foreach (var rootData in data.Where(k => k.Key == rootToSearch))
            {
                rootExists = true;
                string root = rootData.Key;
                SortedDictionary<string, long> fileData = rootData.Value;

                foreach (KeyValuePair<string, long> file in fileData
                    .OrderByDescending(v => v.Value))
                {
                    string fileName = file.Key;
                    long fileSize = file.Value;

                    if (fileName.Contains(extensionToSearch))
                    {
                        Console.WriteLine($"{fileName} - {fileSize} KB");
                        extensionExists = true;
                    }
                }
            }
            if (!rootExists || !extensionExists)
            {
                Console.WriteLine("No");
            }
        }
    }
}