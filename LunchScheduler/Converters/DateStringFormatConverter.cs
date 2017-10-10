﻿//  ---------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//
//  Microsoft License for use of Images
//
//  Microsoft grants you a worldwide, non-exclusive, non-transferrable, revocable, 
//  royalty-free license to use the Microsoft photographs or images contained in this
//  Microsoft sample project, Lunch Scheduler, (“Images”) solely for your purposes
//  of internal using or testing the sample application.You may not copy, modify,
//  reproduce, distribute, publicly display, offer for sale,
//  sell, market, or promote the Microsoft Images.
//  ---------------------------------------------------------------------------------

using System;
using Windows.UI.Xaml.Data;

namespace LunchScheduler.Converters
{

    /// <summary>
    /// Converts a string to a date string. 
    /// </summary>
    class DateStringFormatConverter : IValueConverter
    {
        /// <summary>
        /// Converts a string to a date string.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType.Equals(typeof(System.String)))
            {
                DateTime dt = new DateTime();
                bool gotDate = DateTime.TryParse(value.ToString(), out dt);

                if (gotDate == true)
                {
                    if (parameter == null || parameter.ToString() == "d")
                    {
                        return dt.Date.ToString("d");
                    }
                    else if (parameter.ToString() == "D")
                    {
                        return dt.Date.ToString("D");
                    }
                    else if (parameter.ToString() == "dd MMM yyyy")
                    {
                        return dt.Date.ToString("dd MMM yyyy");
                    }
                    else if (parameter.ToString() == "t")
                    {
                        return dt.ToString("t");
                    }
                    else if (parameter.ToString() == "g")
                    {
                        return dt.ToString("g");
                    }
                }

                return value;
            }
            else
            {
                throw new ArgumentException("Unsuported type {0}", targetType.FullName);
            }
        }

        /// <summary>
        /// No need to implement converting back on a one-way binding.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}