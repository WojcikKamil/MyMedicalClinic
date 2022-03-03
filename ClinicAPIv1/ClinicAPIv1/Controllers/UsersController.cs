using AutoMapper;
using ClinicAPIv1.Data;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Extensions;
using ClinicAPIv1.Helpers;
using ClinicAPIv1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPIv1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        private readonly UserManager<ClinicUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly SignInManager<ClinicUser> _signInManager;
        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;


        public UsersController(UserManager<ClinicUser> userManager, SignInManager<ClinicUser> signInManager, 
            ITokenService tokenService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DataContext context
            )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _signInManager = signInManager;
            _context = context;
            
        }

        //[HttpGet("{TestGetUserByEmail}", Name ="Heheszki")]
        //    public async Task<ActionResult<ClinicUser>> TestGetUserByEmail(string email)
        //    {
        //        return await _userRepository.GetUserByEmail(email);
        //    }

    [HttpGet("GenerateAccesCode")]
    public async Task<ActionResult<CreateAccesCodeDTO>> CreateAccesCode()
        {
            var rnd = new Random();
                int x = rnd.Next(100000, 999999);

            var code = new AccesCode
            {
                Code = x,
            };

            _unitOfWork.CodeAcessRepository.AddCode(code);

            if (await _unitOfWork.CodeAcessRepository.SaveAllAsync())
                return Ok(x);

            return BadRequest("Failed to generate acces code");
        }

    [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {

            if (await UserExists(registerDTO.UserName)) return BadRequest("Email is taken.");

            var status = await CodeExists(registerDTO.AccesCode);

            if (status == false) return BadRequest("You are not allowed to create an account");

            var code = await _unitOfWork.CodeAcessRepository.GetCode(registerDTO.AccesCode);

            _unitOfWork.CodeAcessRepository.DeleteCode(code);

            var user = _mapper.Map<ClinicUser>(registerDTO);

            user.UserName = registerDTO.UserName.ToLower();

            user.Email = user.UserName;

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Patient");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            //return new UserDTO
            //{
            //    UserName = user.UserName,
            //    Token = await _tokenService.CreateTokenAsync(user),
            //};
            return Ok();
        }


        [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDTO.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid email adress");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new UserDTO
            {
                UserName = user.UserName,
                Name = user.Name,
                LastName = user.LastName,
                Token = await _tokenService.CreateTokenAsync(user)
            };
        }

    private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

    private async Task<bool> CodeExists(int AccesCode)
        {
            return await _context.AccesCodes.AnyAsync(x => x.Code == AccesCode);
        }

    }

}
