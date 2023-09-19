namespace LearnSystemIO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Has100Byte()
        {
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = i;
            }
            //arrange- create 100 loop to build Memory Stream 0x01 0x02 ..
            Stream streamTest = new MemoryStream(byteArr);

            byte[] bufferToPopulate = new byte[5];
            int bytesRead = streamTest.Read(bufferToPopulate, 0, 5);

            Assert.AreEqual(bufferToPopulate[0], 0x00);
            Assert.AreEqual(bufferToPopulate[1], 0x01);
            Assert.AreEqual(bufferToPopulate[2], 0x02);
            Assert.AreEqual(bufferToPopulate[3], 0x03);
            Assert.AreEqual(bufferToPopulate[4], 0x04);
            Assert.AreEqual(bytesRead, 5);
        }
        [TestMethod]
        public void CreateANewMemoryStreamFromBytes()
        {
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = i;
            }
            Stream streamTest = new MemoryStream();

            //Position at 100 due to writing 100 bytes
            streamTest.Write(byteArr, 0, 100);

            //Reset position to beginning so tested as if looking at data not just wrote
            streamTest.Position = 0;

            Assert.IsTrue(streamTest.CanWrite);
            Assert.IsTrue(streamTest.CanRead);
            Assert.IsTrue(streamTest.CanSeek);
            Assert.AreEqual(100, streamTest.Length);

            Assert.AreEqual(0, streamTest.Position);
            Assert.AreEqual(0, streamTest.ReadByte());

            Assert.AreEqual(1, streamTest.ReadByte());
            Assert.AreEqual(2, streamTest.Position);

            Assert.AreEqual(10, streamTest.Seek(10, 0));
            Assert.AreEqual(10, streamTest.ReadByte());
        }
        [TestMethod]
        public void CreateANewFileStreamFromBytes()
        {
            //arrange: create a 100 loop to build MemoryStream 0x00,0x01,0x02,0x03,....
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = (i);
            }
            Stream s = new FileStream("out.bin", FileMode.OpenOrCreate);//the Stream s is empty
            //Act write to Stream s using data in byteArr
            s.Write(byteArr, 0, 100);
            s.Position = 0;//reset the stream to the beginning of the stream
            //the position of stream is at 100 because we just Wrote 100 bytes
            Assert.IsTrue(s.CanWrite);
            Assert.IsTrue(s.CanSeek);
            Assert.IsTrue(s.CanRead);
            Assert.AreEqual(100, s.Length);
            Assert.AreEqual(0, s.Position);

            Assert.AreEqual(0, s.ReadByte());
            Assert.AreEqual(1, s.Position);
            Assert.AreEqual(1, s.ReadByte());
            Assert.AreEqual(10, s.Seek(10, 0));
            Assert.AreEqual(10, s.ReadByte());
            s.Flush();
            s.Close();
        }
        [TestMethod]
        public void WritePrimitiveData()
        {
            //Arrange:
            //1 create a file stream to store data at binarybin
            //2 construct BinaryWriter with above stream

            Stream streamTest = new FileStream("binary.bin", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(streamTest);


            //Act: write char decimal int64 int 32 and write a double
            //dont forget to flush and close file

            decimal a = 2.0m;
            Int32 b = Int32.MaxValue;
            Int64 c = Int64.MaxValue;
            char d = 'v';
            string e = "abc";


            bw.Write(a);
            bw.Write(b);
            bw.Write(c);
            bw.Write(d);
            bw.Write(e);
            bw.Flush();
            bw.Close();

            //Assert
            int inputDataByteCount = 33;
            var testFile = new FileInfo("binary.bin");

            Assert.AreEqual(inputDataByteCount, testFile.Length);
            Stream streamTest2 = new FileStream("binary.bin", FileMode.OpenOrCreate);
            BinaryReader br = new BinaryReader(streamTest2);

            Assert.AreEqual(a, br.ReadDecimal());
            Assert.AreEqual(b, br.ReadInt32());
            Assert.AreEqual(c, br.ReadInt64());
            Assert.AreEqual(d, br.ReadChar());
            Assert.AreEqual(e, br.ReadString());
            br.Close();

        }

        //C:\Users\bradl\Pictures\Screenshots\a.png
        [TestMethod]
        public void CopyPrimitiveData()
        {
            //Arrange:
            //1 create a file stream to store data at binarybin
            //2 construct BinaryWriter with above stream
            string original = @"C:\Test\a.png";
            string copy = @"C:\Test\a-copy.png";
            var streamTest = new BinaryReader(new FileStream(original, FileMode.Open));
            var streamCopy = new BinaryWriter(new FileStream(copy, FileMode.OpenOrCreate));

            streamCopy.Write(original);
            streamCopy.Flush();
            streamCopy.Close();

            Assert.AreNotEqual(streamCopy, streamTest);
        }
        [TestMethod]
        public void TestParsingStringToWinnerInstance()
        {
            string input = @"1, 1928, 44, ""Emil Jennings"", ""The Last Command, The Way of All Flesh""";
            Winner w = new Winner(input);

            Assert.AreEqual(1, w.Index);
            Assert.AreEqual(1928, w.Year);
            Assert.AreEqual(44, w.Age);

        }
        [TestMethod]
        public void CreateListOfWinners()
        {
            List<Winner> winners = new List<Winner>();
            using (StreamReader sr = new StreamReader(@"C:\Test\oscar_age_male.csv"))
            {
                string line;

                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length == 0) break;
                    winners.Add(new Winner(line));
                }
            }

            Assert.AreEqual(89, winners.Count);
            Assert.AreEqual(76, winners.Max(w => w.Age));
            Assert.AreEqual(29, winners.Min(w => w.Age));
            Assert.AreEqual(1928, winners.Min(w => w.Year));

            var multiYearWinner =
                winners.GroupBy(winner => winner.Name)
                .Select(g => new { Actor = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ToList();
            ;
            Assert.AreEqual(79, multiYearWinner.Count);
            Assert.AreEqual(@"""Daniel Day-Lewis""", multiYearWinner[0].Actor);

            var sw = new StreamWriter(@"C:\Test\oscar_age_male.csv");
           
            sw.WriteLine($"{"Actor",20}{"Number Of Awards",20}");
            foreach ( var item in multiYearWinner)
            {
                sw.WriteLine($"{item.Actor,20}{item.Count,20}");
            }
            
        }
    }

    public class KRadiusAverage
    {
        [TestMethod]
        public void Tester()
        {

        }

        public int KAverage(int[] input, int i, int k)
        {
            if ((input[(i + -k)] < input[k]) || (input[i] > input[k]))
            {
                return k;
            }
            return k;
        }
        public int KAverage2(int[] input, int i, int k)
        {
            if((i* k > input.Length-1) || (i-k<0)) {return -1;}
            return (int) Math.Floor(input[(i - k)..(i + k + 1)].Average());
        }
    }
}

