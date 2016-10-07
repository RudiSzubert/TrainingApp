using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAplication
{
    [Serializable]
    public class Track
    {
        public string title;
        public string artist;
        public string album;
        public int year;
        public string comment;
        public string genre;
        public string path;
        public Track(string filepath)
        {
            this.path = filepath;
            using (TagLib.File file = TagLib.File.Create(path))
            {
                this.title = file.Tag.Title;
                this.artist = file.Tag.FirstPerformer;
                this.album = file.Tag.Album;
                this.year = (int)file.Tag.Year;
                this.comment = file.Tag.Comment;
                this.genre = file.Tag.FirstGenre;
            }
        }
    }
    [Serializable]
    public class PlayList
    {
        public List<Track> Playlist = new List<Track>();
        public PlayList()
        {
        }
        public PlayList(Track track)
        {
            this.Playlist.Add(track);
        }
        public void Add(Track track)
        {
            this.Playlist.Add(track);
        }
        public void Add(Track[] tracks)
        {
            foreach (Track track in tracks)
                this.Playlist.Add(track);
        }
        public void Remove(Track track)
        {
            this.Playlist.Remove(track);
        }

        public void ListToFile()
        {
            var dir = @"C:/test/Na repy/TrainingAp";
            var SFile = Path.Combine(dir, "Tracks.bin");
            using (Stream stream = File.Open(SFile, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, this.Playlist);
            }
        }

        public void LoadList()
        {
            var dir = @"C:/test/Na repy/TrainingAp";
            var SFile = Path.Combine(dir, "Tracks.bin");
            using (Stream stream = File.Open(SFile, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                this.Playlist = (List<Track>)bformatter.Deserialize(stream);
            }
        }

    }
}
