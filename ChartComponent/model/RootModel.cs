﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using ChartComponent.model;
using ChartComponent.dto;

namespace ChartComponent
{
    [JsonObject]
    [Serializable]
    public class RootModel : TreeNode
    {

        protected List<ChartModel> children;

        public RootModel()
        {
            Text = "root";
            Children = new List<ChartModel>();
        }

        public RootModel(RootModelDTO dto)
        {
            FromDTO(dto);
        }

        [DataMember]
        public List<ChartModel> Children
        {
            set
            {
                children = value;
            }
            get
            {
                return children;
            }
        }

        public RootModelDTO ToDTO()
        {
            var dto = new RootModelDTO
            {
                ChartName = Text
            };
            var children = new List<ChartModelDTO>();
            foreach(ChartModel child in Nodes)
            {
                children.Add(child.ToDTO());
            }
            dto.Children = children;
            return dto;
        }

        public void FromDTO(RootModelDTO dto)
        {
            Text = dto.ChartName;
            Text = dto.ChartName;
            foreach(ChartModelDTO child in dto.Children)
            {
                Nodes.Add(new ChartModel(child));
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
