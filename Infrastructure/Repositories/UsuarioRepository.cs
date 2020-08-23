using Dapper;
using SegurancaBC.Domain.DTO;
using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.Repositories;
using SharedKernel.Repositories;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ISharedUnitOfWork _UoW;

        public UsuarioRepository(ISharedUnitOfWork sharedUnitOfWork)
        {
            _UoW = sharedUnitOfWork;
        }

        public async Task AtivarUsuario(Email nomeDeUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioDTO> CarregarUsuario(Email nomeDeUsuario)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@NomeDeUsuario", nomeDeUsuario.Endereco, System.Data.DbType.String);
            return await _UoW.Connection.QueryFirstOrDefaultAsync<UsuarioDTO>(
                "SELECT * FROM USUARIO WHERE NOMEDEUSUARIO = @NomeDeUsuario", parameters, transaction: _UoW.Transaction);
        }

        public async Task InativarUsuario(Email nomeDeUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task InserirUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
