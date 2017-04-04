using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class FrequenciaDTO
    {
        private int _presente;
        public int Presente
        {
            get { return _presente; }
            set { _presente = value; }
        }
        private int _ausente;
        public int Ausente
        {
            get { return _ausente; }
            set { _ausente = value; }
        }
        private string _decisao;
        public string Decisao
        {
            get { return _decisao; }
            set { _decisao = value; }
        }
    }
}
