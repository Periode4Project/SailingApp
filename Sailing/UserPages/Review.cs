using System;
using System.Collections.Generic;
using System.Text;

namespace Sailing
{
    /// <summary>
    /// class van wat een review is
    /// </summary>
    public class Review
    {
        public int ReviewID { get; set; }
        public string ReviewTitle { get; set; }
        public double Rating { get; set; }
        public string ReviewDESC { get; set; }
        public int ReviewWriter { get; set; }
        public string ReviewWriterName { get; set; }
        public int Activity { get; set; }
    }
}
