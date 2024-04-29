using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SegIt
{
    /// <summary>
    /// Manages JSON serialization and deserialization for segment files and labels.
    /// </summary>
    public class JsonManager
    {
        // Singleton instance
        private static readonly JsonManager instance = new JsonManager();

        // Private constructor to prevent instantiation from outside of this class.
        private JsonManager()
        {
            _segmentFile = new _SegmentFile();
        }

        /// <summary>
        /// Gets the singleton instance of the JsonManager.
        /// </summary>
        /// <returns>The single instance of the JsonManager class.</returns>
        public static JsonManager ins
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// This class using different format for naming because it will be generated as JSON file
        /// </summary>
        class _SegmentFile
        {
            public string data_address { get; set; }
            public string video_address { get; set; }
            public List<string> labels;
            public List<Color> colors;
            public Segment[] segments { get; set; }

            public _SegmentFile()
            {
                labels = LabelList.ins.Labels;
                colors = LabelList.ins.Colors;
            }
        }

        // Holds the current state of the segment file.
        private _SegmentFile _segmentFile;

        // Holds a stored state of the segment file for potential rollback or comparison purposes.
        private _SegmentFile _storedState;

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string fileName { get; private set; }

        /// <summary>
        /// Gets or sets the data address in the segment file.
        /// </summary>
        /// <value>The data address as a string.</value>
        public string DataAddress
        {
            get => _segmentFile.data_address;
            set
            {
                _segmentFile.data_address = value;
            }
        }

        /// <summary>
        /// Gets or sets the video address in the segment file.
        /// </summary>
        /// <value>The video address as a string.</value>
        public string VideoAddress
        {
            get => _segmentFile.video_address;
            set
            {
                _segmentFile.video_address = value;
            }
        }

        /// <summary>
        /// Gets or sets an array of Segments in the segment file.
        /// </summary>
        /// <value>An array of Segment objects.</value>
        public Segment[] Segments
        {
            get => _segmentFile.segments;
            set
            {
                _segmentFile.segments = value;
            }
        }

        /// <summary>
        /// Gets a list of labels from the segment file.
        /// </summary>
        ///<returns>A list of label strings.</returns>
        public List<string> Labels => _segmentFile.labels;

        /// <summary>
        /// Gets a list of colors associated with labels from the segment file.
        /// </summary>
        ///<returns>A list of Color objects.</returns>
        public List<Color> Colors => _segmentFile.colors;

        /// <summary>
        /// Saves the current segments to a JSON file.
        /// </summary>
        public bool SaveSegments()
        {
            _segmentFile.labels = LabelList.ins.Labels;
            _segmentFile.colors = LabelList.ins.Colors;

            // Serialize the segments to JSON
            string json = JsonConvert.SerializeObject(_segmentFile);

            fileName = Path.ChangeExtension(_segmentFile.data_address, ".sgit");

            // Write the JSON to the file
            System.IO.File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName), json);
            return System.IO.File.Exists(fileName);

        }
        /// <summary>
        /// Loads segment data from a JSON file.
        /// </summary>
        /// <param name="fileName">The path of the JSON file to load.</param>
        public void LoadJSON(string fileName)
        {

            if (!System.IO.File.Exists(fileName)) // If the file isn't exist, then make new states
            {
                _segmentFile = new _SegmentFile();
                return;
            }

            // Read the file
            string json = System.IO.File.ReadAllText(fileName);

            // Deserialize the JSON into a segment array
            _segmentFile = JsonConvert.DeserializeObject<_SegmentFile>(json);

            if (_segmentFile == null)
            {
                _segmentFile = new _SegmentFile();
            }
        }

        /// <summary>
        /// Saves label data to a JSON file.
        /// </summary>
        /// <param name="fileLocation">The location where the JSON file will be saved.</param>
        /// <returns>True if the JSON file was saved successfully; otherwise, false.</returns>
        public bool SaveLabels(string fileLocation)
        {
            // Serialize the Label lists to json
            string json = JsonConvert.SerializeObject(LabelList.ins);

            fileName = Path.ChangeExtension(fileLocation, ".lbit");

            // Write the JSON to the file
            System.IO.File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName), json);
            return System.IO.File.Exists(fileName);

        }

        /// <summary>
        /// Loads label data from a JSON file.
        /// </summary>
        /// <param name="fileName">The path of the JSON file to load.</param>
        public void LoadLabels(string fileName)
        {

            if (!System.IO.File.Exists(fileName)) // If the file isn't exist, then make new states
            {
                return;
            }

            // Read the file
            string json = System.IO.File.ReadAllText(fileName);

            // Deserialize the JSON into a segment array
            LabelList labels = JsonConvert.DeserializeObject<LabelList>(json);

            if (labels == null)
            {
                return;
            }

            LabelList.ins.UpdateLabels(labels.Labels, labels.Colors);
        }

        /// <summary>
        /// Stores the current state of segment data.
        /// </summary>
        public void StoreCurrentState()
        {
            _storedState = _segmentFile;
        }

        /// <summary>
        /// Loads the previously stored state of segment data.
        /// </summary>
        public void LoadCurrentState()
        {
            _segmentFile = _storedState;
            LabelList.ins.UpdateLabels(Labels, Colors); // bug might be here
        }

    }
}
