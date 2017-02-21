﻿/*
' Copyright (c) 2017 NM
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;

namespace NM.Modules.FlexEventsUpcoming.Models
{
    [Cacheable("FlexEventsUpcomingItems", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Item
    {
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public int ItemId { get; set; } = -1;
        ///<summary>
        /// A string with the name of the ItemName
        ///</summary>
        public string Title { get; set; }

        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public DateTime StartDate { get; set; }

        ///<summary>
        /// An integer with the user id of the assigned user for the object
        ///</summary>
        public string Location { get; set; }

        ///<summary>
        /// The ModuleId of where the object was created and gets displayed
        ///</summary>
        public int ModuleId { get; set; }

        public string Url { get; set; }
    }
}
