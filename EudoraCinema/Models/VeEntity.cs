using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EudoraCinema.Models
{
    public class VeEntity
    {
        private int m_PK_iVeID;
        private string m_FK_HoadonID;
        private int m_FK_iGheID;
        private int m_FK_iPhongchieuID;

        public int PK_iVeID { get => m_PK_iVeID; set => m_PK_iVeID = value; }
        public string FK_HoadonID { get => m_FK_HoadonID; set => m_FK_HoadonID = value; }
        public int FK_iGheID { get => m_FK_iGheID; set => m_FK_iGheID = value; }
        public int FK_iPhongchieuID { get => m_FK_iPhongchieuID; set => m_FK_iPhongchieuID = value; }
    }
}