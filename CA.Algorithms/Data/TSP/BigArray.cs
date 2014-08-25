using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.TSP
{
    class BigArray
    {
        private int lines;
        private int rows;
        private int typeSize;
        private MemoryMappedFile mmf;
        private float[] buffer;
        private int bufferLineStart = -1;
       // private int sets, gets;
        public BigArray(int lines, int rows, int typeSize)
        {
            this.lines = lines;
            this.rows = rows;
            this.typeSize = typeSize;
            buffer = new float[rows];
            mmf = MemoryMappedFile.CreateNew("big array", lines * rows * typeSize);
        }

        public float GetElement(int line, int row)
        {
            //Console.WriteLine(gets++);
            if (bufferLineStart == line)
            {
                return buffer[row];
            }

            using (var accessor = mmf.CreateViewAccessor(line * rows * typeSize, rows* typeSize))
            {
                accessor.ReadArray(0, buffer, 0, rows);
                
                return buffer[row];
            }
        }
        
        //public float GetElement(int line, int row)
        //{
        //    using (var accessor = mmf.CreateViewAccessor(line * rows * typeSize + row * typeSize, typeSize))
        //    {
        //        float item;
        //        accessor.Read(0, out item);

        //        return item;
        //    }
        //}

        public void SetElement(int line, int row, float item)
        {
            
           // Console.WriteLine("sets {0})",sets++);
            if (line == bufferLineStart)
                bufferLineStart = -1;

            using (var accessor = mmf.CreateViewAccessor(line * rows * typeSize + row * typeSize, typeSize))
            {
                accessor.Write(0, item);
            }
        }
    }
}
