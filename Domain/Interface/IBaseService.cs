using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        //Serviço responsável por salvar a publicação pesquisada na automação
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        //Serviço responsável por deletar
        void Delete(int id);

        //Serviço responsável por Buscar todas as automações cadastradas
        IEnumerable<TOutputModel> Get<TOutputModel>() where TOutputModel : class;

        //Serviço responsável por Buscar por id a automações cadastradas
        TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class;

        //Serviço responsável por Atualizar as automações cadastradas
        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
    }
}
