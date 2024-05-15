
using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;


namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class AutomapperConfig
    {

        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {

                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();

            });

        }


    }
}