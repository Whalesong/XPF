#region License
/* The MIT License
 *
 * Copyright (c) 2011 Red Badger Consulting
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/
#endregion

using System;

namespace RedBadger.Xpf
{
    public class HorizontalAlignment:RefEnum
    {
        private HorizontalAlignment(string txt, int id):base(txt,id){}

        public static HorizontalAlignment Stretch{get{return new HorizontalAlignment("Stretch",1);}}
        public static HorizontalAlignment Left { get { return new HorizontalAlignment("Left", 2); } }
        public static HorizontalAlignment Center { get { return new HorizontalAlignment("Center", 4); } }
        public static HorizontalAlignment Right { get { return new HorizontalAlignment("Right", 8); } }
    }
    //public enum HorizontalAlignment
    //{
    //    Stretch,
    //    Left,
    //    Center,
    //    Right
    //}
}
