using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hadoop.New.Library.WebHdfs.Client
{
    /// <summary>
    /// https://hadoop.apache.org/docs/r2.8.0/hadoop-project-dist/hadoop-hdfs/WebHDFS.html#FileStatuses_JSON_Schema
    /// </summary>
    public class WebHdfsFileStatusesClass
    {
        /// <summary>
        /// Gets or sets the file statuses.
        /// </summary>
        /// <value>The file statuses.</value>
        public WebHdfsFileStatuses FileStatuses { get; set; }
    }

    /// <summary>
    /// File statuses.
    /// </summary>
    public class WebHdfsFileStatuses
    {
        /// <summary>
        /// Gets or sets the file status.
        /// </summary>
        /// <value>The file status.</value>
        public List<WebHdfsFileStatus> FileStatus { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:WebHDFS.FileStatuses"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:WebHDFS.FileStatuses"/>.</returns>
        public override string ToString()
        {
            return string.Join("\n", FileStatus);
        }

       
    }
}