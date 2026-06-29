using System.IO;

using DocumentMarker_B_.Models;

using Newtonsoft.Json;



namespace DocumentMarker_B_

{

    public static class RecordStorage

    {

        private static readonly string FilePath = "records.json";



        public static ProjectData Load()

        {

            if (!File.Exists(FilePath)) return new ProjectData();

            try

            {

                string json = File.ReadAllText(FilePath);

                return JsonConvert.DeserializeObject<ProjectData>(json) ?? new ProjectData();

            }

            catch

            {

                return new ProjectData();

            }

        }



        public static void Save(ProjectData data)

        {

            try

            {

                string json = JsonConvert.SerializeObject(data, Formatting.Indented);

                File.WriteAllText(FilePath, json);

            }

            catch { }

        }

    }

}
