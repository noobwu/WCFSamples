using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Artech.VideoMall.Common;
using System.ComponentModel.DataAnnotations;

namespace Artech.VideoMall.Products.BusinessEntity
{
    [DataContract(Namespace = Constants.DataContractNamespace)]
    public class Movie
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        [Display(Name = "片名")]
        public string Name { get; set; }
        [DataMember]
        [Display(Name = "类型")]
        public string Categogy { get; set; }
        [DataMember]
        [Display(Name = "主演")]
        public string Starring { get; set; }
        [DataMember]
        [Display(Name = "导演")]
        public string Director { get; set; }
        [DataMember]
        [Display(Name = "片长")]
        public int RuningTime { get; set; }
        [DataMember]
        [Display(Name = "海报")]
        public string Poster { get; set; }
        [DataMember]
        [Display(Name = "剧情介绍")]
        public string Story { get; set; }
        [DataMember]
        [Display(Name = "价格")]
        public decimal Price { get; set; }
        [DataMember]
        [Display(Name = "上映日期")]
        public DateTime? ReleaseYear { get; set; }
    }
}