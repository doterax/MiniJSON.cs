using System;
using System.Collections;
using MiniJSON;
using NUnit.Framework;

namespace jsonrpc.test
{
    public class MiniJsonTest
    {
        [Test]
        public void TestNullDeserialize()
        {
            Assert.IsNull(Json.Deserialize(null));
        }
        [Test]
        public void TestEmptyDeserialize()
        {
            Assert.IsNull(Json.Deserialize(""));
        }
        [Test]
        public void TestAllWhiteSpaceDeserialize()
        {
            Assert.IsNull(Json.Deserialize("            \n\n\n\n\n\t\n\n\n\n\t  \r\f\n   "));
        }
        [Test]
        public void TestWrongDeserialize()
        {
            Assert.IsNull(Json.Deserialize("Hello world!"));
        }
        [Test]
        public void TestWrongArray()
        {
            Assert.IsNull(Json.Deserialize("[1,2,3"));
        }
        [Test]
        public void TestWrongKeyValueSeparator()
        {
            Assert.IsNull(Json.Deserialize("{\"key\"-\"value\""));
        }
        [Test]
        public void TestEmptyObject()
        {
            Assert.IsNotNull(Json.Deserialize("{}"));
        }
        [Test]
        public void TestMissingKey()
        {
            Assert.IsNull(Json.Deserialize("{:\"value\""));
        }
        [Test]
        public void TestMissingValue()
        {
            Assert.IsNull(Json.Deserialize("{\"key\":"));
        }
        [Test]
        public void TestMissingKey1()
        {
            Assert.IsNull(Json.Deserialize("{\""));
        }
        [Test]
        public void TestUnexpectedEnd()
        {
            Assert.IsNull(Json.Deserialize("[\"\\"));
        }
        [Test]
        public void TestWrongObject()
        {
            Assert.IsNull(Json.Deserialize("{key:123"));
        }
        [Test]
        public void TestArrayWithWhileApaceAtEnd()
        {
            IList arr = (IList)Json.Deserialize("[42]   ");
            Assert.IsNotNull(arr);
            Assert.AreEqual(1, arr.Count);
            Assert.AreEqual(42, arr[0]);
        }
        [Test]
        public void TestArrayWithWhileApaceAtStart()
        {
            IList arr = (IList)Json.Deserialize("   [42]");
            Assert.IsNotNull(arr);
            Assert.AreEqual(1, arr.Count);
            Assert.AreEqual(42, arr[0]);
        }
        [Test]
        public void TestArrayWithWhileSpace()
        {
            IList arr = (IList)Json.Deserialize("         [42]          ");
            Assert.IsNotNull(arr);
            Assert.AreEqual(1, arr.Count);
            Assert.AreEqual(42, arr[0]);
        }

        [Test]
        public void TestSerializeChar()
        {
            JsonObject obj = new JsonObject();

            obj["key"] = 'A';

            obj = new JsonObject(obj.ToString());

            Assert.AreEqual("A", obj["key"]);
        }

        [Test]
        public void TestSpecialCharB()
        {
            JsonObject obj = new JsonObject();

            char c = '\b';

            obj["key"] = c;

            obj = new JsonObject(obj.ToString());

            Assert.AreEqual(c.ToString(), obj["key"]);
        }
        [Test]
        public void TestSpecialCharQ()
        {
            JsonObject obj = new JsonObject();

            char c = '\"';

            obj["key"] = c;

            obj = new JsonObject(obj.ToString());

            Assert.AreEqual(c.ToString(), obj["key"]);
        }
        [Test]
        public void TestSpecialCharF()
        {
            JsonObject obj = new JsonObject();

            char c = '\f';

            obj["key"] = c;

            obj = new JsonObject(obj.ToString());

            Assert.AreEqual(c.ToString(), obj["key"]);
        }
        [Test]
        public void TestSpecialCaseForNonSerializables()
        {
            JsonObject obj = new JsonObject();

            Random rnd = new Random();

            obj["key"] = rnd;

            obj = new JsonObject(obj.ToString());

            Assert.AreEqual(rnd.ToString(), obj["key"]);
        }
        
    }
}