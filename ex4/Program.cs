using System;
using System.Collections;
using System.Collections.Generic;

namespace MusicCatalogApp
{
    class Program
    {
        static void Main()
        {
            Catalog catalog = new Catalog();

            // Створення дисків
            var disk1 = new MusicDisk("Greatest Hits");
            disk1.AddSong(new Song("Bohemian Rhapsody", "Queen", TimeSpan.FromMinutes(5.55)));
            disk1.AddSong(new Song("Don't Stop Me Now", "Queen", TimeSpan.FromMinutes(3.29)));

            var disk2 = new MusicDisk("Pop Collection");
            disk2.AddSong(new Song("Blinding Lights", "The Weeknd", TimeSpan.FromMinutes(3.20)));
            disk2.AddSong(new Song("Save Your Tears", "The Weeknd", TimeSpan.FromMinutes(3.35)));

            // Додавання дисків у каталог
            catalog.AddDisk(disk1);
            catalog.AddDisk(disk2);

            // Перегляд усього каталогу
            Console.WriteLine("=== Вміст каталогу ===");
            catalog.ShowAll();

            // Пошук пісень виконавця
            Console.WriteLine("\n=== Пошук пісень 'Queen' ===");
            catalog.FindSongsByArtist("Queen");

            // Видалення пісні
            Console.WriteLine("\n=== Видалення пісні 'Blinding Lights' з Pop Collection ===");
            disk2.RemoveSong("Blinding Lights");

            // Перегляд каталогу знову
            Console.WriteLine("\n=== Каталог після видалення пісні ===");
            catalog.ShowAll();

            // Видалення диска
            catalog.RemoveDisk("Greatest Hits");

            Console.WriteLine("\n=== Каталог після видалення диска ===");
            catalog.ShowAll();
        }
    }

    class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }

        public Song(string title, string artist, TimeSpan duration)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist} ({Duration:mm\\:ss})";
        }
    }

    class MusicDisk
    {
        public string Name { get; set; }
        private List<Song> songs;

        public MusicDisk(string name)
        {
            Name = name;
            songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        public void RemoveSong(string title)
        {
            songs.RemoveAll(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public List<Song> GetSongs()
        {
            return new List<Song>(songs);
        }

        public List<Song> FindByArtist(string artist)
        {
            return songs.FindAll(s => s.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase));
        }

        public override string ToString()
        {
            return $"Disk: {Name}, Кількість пісень: {songs.Count}";
        }
    }

    class Catalog
    {
        private Hashtable disks = new Hashtable();

        public void AddDisk(MusicDisk disk)
        {
            if (!disks.ContainsKey(disk.Name))
                disks.Add(disk.Name, disk);
        }

        public void RemoveDisk(string name)
        {
            disks.Remove(name);
        }

        public void ShowAll()
        {
            foreach (DictionaryEntry entry in disks)
            {
                MusicDisk disk = entry.Value as MusicDisk;
                Console.WriteLine(disk);
                foreach (var song in disk.GetSongs())
                {
                    Console.WriteLine("  - " + song);
                }
            }
        }

        public void FindSongsByArtist(string artist)
        {
            foreach (DictionaryEntry entry in disks)
            {
                MusicDisk disk = entry.Value as MusicDisk;
                List<Song> songs = disk.FindByArtist(artist);
                foreach (var song in songs)
                {
                    Console.WriteLine($"[Диск: {disk.Name}] {song}");
                }
            }
        }
    }
}
