using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Metric
{
    public class Conversion
    {
        public string Metric { get; set; }
        public string ConversionValue { get; set; }
    }

    public class ConversionGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Conversion> Conversions { get; set; }
    }

    public class ConversionGroupService : IConversionGroupService
    {

        private List<ConversionGroup> _groups = new List<ConversionGroup>()
        {
            new ConversionGroup
            {
                Id = 1,
                Name = "Cup",
                Conversions = new List<Conversion>
                {
                    new Conversion
                    {
                        Metric = "1/8",
                        ConversionValue = "16g"
                    },
                     new Conversion
                    {
                        Metric = "1/4",
                        ConversionValue = "32g"
                    },
                    new Conversion
                    {
                        Metric = "1/3",
                        ConversionValue = "43g"
                    },
                     new Conversion
                    {
                        Metric = "1/2",
                        ConversionValue = "64g"
                    },
                    new Conversion
                    {
                        Metric = "2/3",
                        ConversionValue = "85g"
                    },
                    new Conversion
                    {
                        Metric = "3/4",
                        ConversionValue = "96g"
                    },
                    new Conversion
                    {
                        Metric = "1",
                        ConversionValue = "128g"
                    },

                }
            }

        };

        public ConversionGroup GetById(int id)
        {
            return _groups.Where(g => g.Id == id).FirstOrDefault();
        }
    }

    public interface IConversionGroupService
    {
        ConversionGroup GetById(int id);
    }
}