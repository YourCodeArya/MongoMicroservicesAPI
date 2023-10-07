using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly AppDbcontext dbcontext;
        private ResponseDto response;
        private IMapper _mapper; 
        public CouponsController(AppDbcontext db, IMapper mapper)
        {
            dbcontext = db;
            response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public object Get() 
        {
            try
            { IEnumerable<Coupons> objlist= dbcontext.Coupons.ToList();
                response.Result = objlist; 
                
                
            }
            catch (Exception ex) 
            {
                response.IsSuccess = false; 
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupons objlist = dbcontext.Coupons.FirstOrDefault(x=>x.CouponId==id);
                response.Result =  _mapper.Map<CouponsDto>(objlist);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetByCode/:{code}")]
        public object GetByCode(string code)
        {
            try
            {
                Coupons objlist = dbcontext.Coupons.FirstOrDefault(x => x.CouponCode.ToLower() == code.ToLower());
                response.Result = _mapper.Map<CouponsDto>(objlist);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]      
        public ResponseDto Post([FromBody] CouponsDto coupondto)
        {
            try
            {
                Coupons obj = _mapper.Map<Coupons>(coupondto);
                dbcontext.Add(obj);
                dbcontext.SaveChanges();
                response.Result = _mapper.Map<CouponsDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }


    }
}
