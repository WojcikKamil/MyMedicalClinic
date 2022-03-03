using AutoMapper;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Extensions;
using ClinicAPIv1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Controllers
{
    [Authorize(Policy = "RequireDoctorRole")]
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public PhotoController(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPhotoService photoService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _photoService = photoService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDTO>> AddPhoto(IFormFile file)
        {
            var email = User.GetUserName();
            var user = await _userRepository.GetDoctorByEmail(email);

            if (user.Photos.Count != 0)
            {
                return BadRequest("Firstly delete old photo");
            }

            var result = await _photoService.AddPhoto(file);

            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            user.Photos.Add(photo);

            if (await _unitOfWork.Complete())
                return _mapper.Map<PhotoDTO>(photo);

            return BadRequest("Problem with adding photo");
        }

        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var email = User.GetUserName();
            var user = await _userRepository.GetDoctorByEmail(email);
            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null) return NotFound();

            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhoto(photo.PublicId);
                if (result.Error != null) return BadRequest(result.Error.Message);
            }

            user.Photos.Remove(photo);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to deleted");
        }
    }
}
