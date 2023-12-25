using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJsonSerializer.Models
{
    public class RootClass
    {
        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public Coordinate coordinates { get; set; }
        public Timezone timezone { get; set; }
        public string test { get; set; }
    }
    public class Name
    {
        public string first { get; set; }
        public string title { get; set; }
        public string last { get; set; }
    }
    public class Location
    {
        public Street street { get; set; }
    }
    public class Street
    {
        public string number { get; set; }
        public string name{ get; set; }
    }
    public class Coordinate
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
    public class Timezone
    {
        public string offset { get; set; }
        public string description { get; set; }
    }
    public class Author
    {
        public string lastname { get; set; }
        public string firstname { get; set; }
    }

    public class Editor
    {
        public string lastname { get; set; }
        public string firstname { get; set; }
    }

    public class Root
    {
        public string isbn { get; set; }
        public Author author { get; set; }
        public Editor editor { get; set; }
        public string title { get; set; }
        public List<string> category { get; set; }
    }

}
