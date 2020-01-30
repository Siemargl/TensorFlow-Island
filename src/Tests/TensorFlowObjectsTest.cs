﻿// MIT License
// Copyright (c) 2019-2020 Wuping Xin.
//
// Permission is hereby  granted, free of charge, to any  person obtaining a copy
// of this software and associated  documentation files (the "Software"), to deal
// in the Software  without restriction, including without  limitation the rights
// to  use, copy,  modify, merge,  publish, distribute,  sublicense, and/or  sell
// copies  of  the Software,  and  to  permit persons  to  whom  the Software  is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE  IS PROVIDED "AS  IS", WITHOUT WARRANTY  OF ANY KIND,  EXPRESS OR
// IMPLIED,  INCLUDING BUT  NOT  LIMITED TO  THE  WARRANTIES OF  MERCHANTABILITY,
// FITNESS FOR  A PARTICULAR PURPOSE AND  NONINFRINGEMENT. IN NO EVENT  SHALL THE
// AUTHORS  OR COPYRIGHT  HOLDERS  BE  LIABLE FOR  ANY  CLAIM,  DAMAGES OR  OTHER
// LIABILITY, WHETHER IN AN ACTION OF  CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE  OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using RemObjects.Elements.EUnit;
using TensorFlow;
using TensorFlow.Island.Classes;

namespace TensorFlow.Island.Tests
{
    public class TensorFlowObjectsTest: Test
    {
        // Called before each test method.
        public override void Setup()
        {
        	
        }

        // Called after each test method.
        public override void Teardown()
        {
        	
        }

        // Called before first test method.
        public override void SetupTest()
        {
        	
        }

        // Called after last test method.
        public override void TeardownTest()
        {
        	
        }

        public void When_ReferencingDisposedObject_Expect_ObjectDisposedException()
        {
            Int64[] dims = {1, 5, 10};
            var shp = new Shape withDimensions(dims);
            shp.Dispose();
       	    Assert.Throws(()=>shp.NumDims, typeof(ObjectDisposedException));
        }
      
        public void When_UsingInvalidShapeDimIndex_Expect_InvalidShapeDimIndexExpection()
        {
            Int64[] dims = {1, 5, 10};
            var shp = new Shape withDimensions(dims);
            Assert.AreEqual(shp.NumDims, 3);
            Assert.AreEqual(shp.Dim[0], 1);
            Assert.AreEqual(shp.Dim[1], 5);
            Assert.AreEqual(shp.Dim[2], 10);
            Assert.Throws(()=>shp.Dim[5], typeof(InvalidShapeDimIndexException));
        }
    }
}