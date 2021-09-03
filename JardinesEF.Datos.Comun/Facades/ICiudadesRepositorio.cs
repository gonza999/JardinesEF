﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Comun.Facades
{
    public interface ICiudadesRepositorio : IRepositorio<Ciudad>
    {
        List<Ciudad> GetLista();
        List<Ciudad> GetLista(int paisId);
    }
}
