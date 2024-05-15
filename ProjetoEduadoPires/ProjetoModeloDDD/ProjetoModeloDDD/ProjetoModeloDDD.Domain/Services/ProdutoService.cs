
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {


        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtorepository)

            : base(produtorepository)
        {

             _produtoRepository = produtorepository;

        }
    public IEnumerable<Produto> BuscarPorNome(string nome)
    {
        return _produtoRepository.BuscarPorNome(nome);
    }



    }
}
