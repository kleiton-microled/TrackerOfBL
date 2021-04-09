using ApiTrakingOfBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrakingOfBl.Repository
{
    public interface ITrakingBLRepository
    {
        List<BL> ListarBls();
        BL FindByNumberBL(string numberBl);
        BL CadastroTokenBl(BL bl);

    }
}
