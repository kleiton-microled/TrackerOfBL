using ApiTrakingOfBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrakingOfBl.Business
{
    public interface ITrakingBLBusiness
    {
        List<BL> ListarBls();
        BL FindByNumberBL(string numberBl);
        string IniciarRastreioLogComex(BL bl);
        BL CadastrarTokenBl(BL bl);
        object DetalheRastreio(string token);

    }
}
