using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ID3TagRemover
{
    class Program
    {
        private static int i;
        private static string s;
        static void Main(string[] args)
        {
            i=0;
            DisplayText();
            s = Console.ReadLine();
            Console.WriteLine("");
            DeleteTags(Environment.CurrentDirectory);
            Console.WriteLine("");
            Console.WriteLine(i + " ID3 Tags removed");
            Console.WriteLine("");
            Console.WriteLine("Press [Any Key] to exit");
            Console.ReadLine();
        }

        private static void DisplayText()
        {
            Console.WriteLine("################# ID3 Tag Remover #################");
            Console.WriteLine("#--This Application will remove all ID3Tags from--#");
            Console.WriteLine("#--all mp3 files in the current directory---------#");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("#--Press [Any Key] to start ----------------------#");
            Console.WriteLine("#--Press [X] to start and include subdirectories--#");
            Console.WriteLine("#-------------------------------------------------#");
            Console.WriteLine("###################################################");
            Console.WriteLine("");
        }

        private static void DeleteTags(string _path)
        {
            if (s.ToLower() == "x")
            {
                foreach (string Folder in Directory.GetDirectories(_path))
                {
                    DeleteTags(Folder);
                }
            }

            foreach (string musicFile in Directory.GetFiles(_path, "*.mp3"))
            {
                TagLib.File f = TagLib.File.Create(musicFile);
                if (f.Tag.Title != null || f.Tag.FirstAlbumArtist != null)
                {
                    Console.WriteLine(f.Name);
                    f.RemoveTags(TagLib.TagTypes.AllTags);
                    f.Save();
                    i++;
                }
            }
        }
    }
}
