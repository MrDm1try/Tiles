using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiles
{
    class Tile
    {
        public byte Up { get; set; }
        public byte Down { get; set; }

        public Tile(byte up, byte down)
        {
            Up = up;
            Down = down;
        }

        public void Turn()
        {
            byte temp = Up;
            Up = Down;
            Down = temp;
        }

        override
        public string ToString()
        {
            return Up + "/" + Down;
        }

        override
        public bool Equals(object obj)
        {
            var other = obj as Tile;

            if (other == null)
                return false;

            return Up == other.Up && Down == other.Down;
            
        }
    }

    class TileField
    {
        public Tile[] tileSet;
        private Tile[] tileField;
        private byte height;
        private byte length;
        private int setPointer;
        private int fieldPointer;

        public TileField(byte height, byte length)
        {
            tileSet = new Tile[28];
            setPointer = 0;
            for (byte i = 0; i < 7; i++)
                for (byte j = i; j < 7; j++)
                    tileSet[setPointer++] = new Tile(i, j);
            setPointer = 0;
            fieldPointer = 0;
            this.height = height;
            this.length = length;
            tileField = new Tile[height * length];

            tileField[fieldPointer++] = tileSet[0];
            tileField[fieldPointer++] = tileSet[0];
            tileField[fieldPointer++] = tileSet[0];
            tileField[fieldPointer++] = tileSet[0];
            tileField[fieldPointer++] = tileSet[0];
            tileField[fieldPointer++] = tileSet[0];

            tileField[fieldPointer++] = tileSet[1];
            tileField[fieldPointer++] = tileSet[1];
            tileField[fieldPointer++] = tileSet[1];
            tileField[fieldPointer++] = tileSet[1];
            tileField[fieldPointer++] = tileSet[1];
            tileField[fieldPointer++] = tileSet[1];

            tileField[fieldPointer++] = tileSet[2];
            tileField[fieldPointer++] = tileSet[2];
            tileField[fieldPointer++] = tileSet[2];
            //tileField[fieldPointer++] = tileSet[2];
            //tileField[fieldPointer++] = tileSet[2];
            //tileField[fieldPointer++] = tileSet[2];


        }

        public bool Check()
        {
            ////Check horizontal sums
            //int horizontNumber = fieldPointer / length;
            //Console.WriteLine(horizontNumber);
            //int sum = -1;
            //for (int i = 0; i < horizontNumber; i++)
            //{
            //    int sumUp = 0;
            //    int sumDown = 0;
            //    for (int j = i * length; j < ((i + 1) * length); j++)
            //    {
            //        sumUp += tileField[j].Up;
            //        sumDown += tileField[j].Down;
            //    }
            //    if (sumUp == sumDown)
            //    {
            //        if (sum == -1)
            //            sum = sumUp;
            //        else if (sum != sumUp)
            //            return false;
            //    }
            //    else
            //        return false;
            //}

            //Check vertical sums
            //if (fieldPointer > tileField.Length - length)
            //{
            //    for (int i = 0; i < fieldPointer - (tileField.Length - length); i++)
            //    {
            //        int sumVert = 0;
            //        for (int j = i; j < tileField.Length; j += length)
            //        {
            //            sumVert += tileField[j].Up + tileField[j].Down;
            //        }
            //        if (sumVert != sum)
            //            return false;
            //    }
            //}

            //Check diagonal 1


            return true;
        }

        private bool Contains(Tile tile)
        {
            for (int i = 0; i < fieldPointer; i++)
                if (tileField[i].Equals(tile))
                    return true;
            return false;
        }

        override
        public string ToString()
        {
            string toReturn = "";
            for (int i = 0; i < tileField.Length; i++)
            {
                if (tileField[i] != null)
                    toReturn += tileField[i].ToString() + " ";
                else
                    toReturn += "-/- ";
                if ((i + 1) != tileField.Length && (i + 1) % length == 0)
                    toReturn += "\n";
            }

            return toReturn;
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            TileField t = new TileField(3, 6);

            Console.WriteLine(t.ToString());
            Console.WriteLine(t.Check());

            Console.ReadKey();
        }
    }
}
