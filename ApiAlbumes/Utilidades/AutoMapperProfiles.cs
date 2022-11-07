using AutoMapper;
using ApiAlbumes.DTOs;
using ApiAlbumes.Entidades;

namespace ApiAlbumes.Utilidades
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<AlbumDTO, Album>();
            CreateMap<Album, GetAlbumDTO>();
        }

        
    }
}
