﻿using System;

namespace EudoraCinema.Models
{
    public class HoadonEntity
    {
        private string m_sTenphim;
        private string m_sThoiluong;
        private DateTime m_tNgaybatdau;
        private string m_hGiochieu;
        private int m_FK_iPhongchieuID;
        private int m_FK_iGheID;
        private string m_sTenghe;

        public string sTenphim { get => m_sTenphim; set => m_sTenphim = value; }
        public string sThoiluong { get => m_sThoiluong; set => m_sThoiluong = value; }
        public DateTime tNgaybatdau { get => m_tNgaybatdau; set => m_tNgaybatdau = value; }
        public string hGiochieu { get => m_hGiochieu; set => m_hGiochieu = value; }
        public int FK_iPhongchieuID { get => m_FK_iPhongchieuID; set => m_FK_iPhongchieuID = value; }
        public int FK_iGheID { get => m_FK_iGheID; set => m_FK_iGheID = value; }
        public string sTenghe { get => m_sTenghe; set => m_sTenghe = value; }
        // private int 
    }
}