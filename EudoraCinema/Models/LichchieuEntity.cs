using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EudoraCinema.Models
{
    public class LichchieuEntity
    {
        private long m_PK_iLichchieuID;
        private long m_FK_iPhongchieuID;
        //  private long m_FK_iVeID;
        private long m_FK_iPhimID;
        private DateTime m_tNgaybatdau;
        private String m_hGiochieu;

        public long PK_iLichchieuID { get => m_PK_iLichchieuID; set => m_PK_iLichchieuID = value; }
        public long FK_iPhongchieuID { get => m_FK_iPhongchieuID; set => m_FK_iPhongchieuID = value; }
        //  public long FK_iVeID { get => m_FK_iVeID; set => m_FK_iVeID = value; }
        public long FK_iPhimID { get => m_FK_iPhimID; set => m_FK_iPhimID = value; }
        public DateTime tNgaybatdau { get => m_tNgaybatdau; set => m_tNgaybatdau = value; }
        public String hGiochieu { get => m_hGiochieu; set => m_hGiochieu = value; }
    }
}