using System.Collections.Generic;

using System.IO;

using System.Windows;

using Newtonsoft.Json;



namespace DocumentMarker_B_.Models

{

    public class DocumentRecord

    {

        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string FilePath { get; set; }

        public int PageNumber { get; set; }

        public string FolderId { get; set; }



        public string PageCountText

        {

            get

            {

                if (string.IsNullOrEmpty(FilePath)) return $"Sayfa: {PageNumber}";

                string ext = Path.GetExtension(FilePath).ToLower();

                return ext == ".pptx" ? $"Slayt: {PageNumber}" : $"Sayfa: {PageNumber}";

            }

        }



        // Dosya mevcut mu kontrolü - XAML binding için

        [JsonIgnore]

        public Visibility MissingWarningVisibility

        {

            get

            {

                if (string.IsNullOrEmpty(FilePath)) return Visibility.Collapsed;

                return File.Exists(FilePath) ? Visibility.Collapsed : Visibility.Visible;

            }

        }

    }



    public class FolderModel

    {

        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string ParentFolderId { get; set; } = null;



        [JsonIgnore]

        public List<FolderModel> SubFolders { get; set; } = new List<FolderModel>();

    }



    public class ProjectData

    {

        public List<DocumentRecord> AllRecords { get; set; } = new List<DocumentRecord>();

        public List<FolderModel> Folders { get; set; } = new List<FolderModel>();

    }

}
